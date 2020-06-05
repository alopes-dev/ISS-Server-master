using ISS.Application.Helpers;
using ISS.Application.LinqToDb;
using ISS.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ISS.Application.Movimentos
{
    /// <summary>
    /// Estruturar com funções necessárias a manipulação de movimentos.
    /// </summary>
    public class Movimentos
    {
        #region Private Members
        /// <summary>
        /// Context para acesso a base de dados via Linq2db
        /// </summary>
        private readonly LinqDbContext _dbContext;

        /// <summary>
        /// Variavel auxiliar onde estarão os meses em português
        /// </summary>
        private readonly Dictionary<int, string> _meses;

        /// <summary>
        /// Instancia do mapper para que se possa mappear ou copiar objectos
        /// </summary>
        private readonly MapBuilder.Mapper Mapper = new MapBuilder.Mapper();
        #endregion

        #region Public Properties
        // Variavel auxiliar onde estará o context da base de dados
        public DapperContext Db { get; set; }
        // Variavel auxiliar para salvar temporáriamente as naturezas
        public static List<NaturezaMovimento> Naturezas { get; set; }
        // Variavel auxiliar onde estará a natureza credito
        public static NaturezaMovimento NaturezaCredito { get; set; }
        // Variavel auxiliar onde estará a natureza debito
        public static NaturezaMovimento NaturezaDebito { get; set; }
        // Variavel auxiliar onde estará o tipo de operação do movimento a ser inserido
        public static TipoOperacao TipoOperacao { get; set; }

        // Variavel aulizar onde estará temporariamente os refiados salvos na base de dados
        public static List<Feriado> Feriados { get; set; }
        #endregion

        #region Constructor Padrão
        /// <summary>
        /// Constructor Padrão 
        /// </summary>
        /// <param name="db">Context para Dapper</param>
        /// <param name="dbContext">Context para Linq2db</param>
        public Movimentos(DapperContext db,LinqDbContext dbContext = null)
        {
            Db = db;
            _dbContext = dbContext;
            _meses =  new Dictionary<int, string> {
                { 1, "Janeiro" }, { 2, "Fevereiro" },
                { 3, "Março" }, { 4, "Abril" },
                { 5, "Maio" }, { 6, "Junho" },
                { 7, "Julho" }, { 8, "Agosto" },
                { 9, "Setembro" }, { 10, "Outubro" },
                { 11, "Novembro" }, { 12, "Dezembro" },
            };
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Função auxiliar para verificar se o dia do movimento antecipa, posticipa ou é válido.
        /// </summary>
        /// <param name="dataCorrente">A data actual.</param>
        /// <param name="numDiasAdicionado">Dias adicionados.</param>
        /// <param name="tipoMovimento">O tipo de movimento.</param>
        /// <returns></returns>
        private int CheckDataProgramada(DateTime dataCorrente, int numDiasAdicionado, int? tipoMovimento)
        {
            int numDias = 0;
            // Pegando a lista de feriados
            Feriados = Feriados ?? _dbContext.GetTable<Feriado>().ToList();

            // Transforma um objecto de feriado em datetime
            DateTime ToDate(Feriado frd)
            {
                int d = (int)frd.Dia;
                int m = (int)frd.Mes;
                int a = (int)frd.Ano == 0 ? DateTime.Now.Year : (int)frd.Ano;

                return new DateTime(a, m, d);
            }

            // Função auxiliar para verificar se uma data é feriado ou não
            Feriado ChecarFeriado(DateTime data)
                => Feriados.FirstOrDefault(x => DataIguais(ToDate(x), data));

            // Alternador dos finais de dias
            int Anticipar_Posticipar(int numDiasAdiantar, int numDiasRecuar)
            {
                return tipoMovimento switch
                {
                    1 => numDiasAdiantar,
                    2 => -numDiasRecuar,
                    _ => numDiasAdiantar
                };
            }

            // Verificador de finais de semana
            int ChecarFinalSemana(DateTime? dataFinalSemana)
            {
                // Verificando se o parametro é válido
                if (dataFinalSemana == null)
                    return 0;

                return dataFinalSemana.Value.DayOfWeek switch
                {
                    DayOfWeek.Saturday => Anticipar_Posticipar(2, 1),
                    DayOfWeek.Sunday => Anticipar_Posticipar(1, 2),
                    _ => 0
                };
            }

            // Verificador de pontes
            int ChecarPonte(DateTime novaData, int diasChecados)
            {
                int n = diasChecados;
                // Verificando se o tipo de movimento é valido
                if (tipoMovimento != null)
                {
                    // Verificando o numero de dias deve ser diminuindo
                    // 0, Significando que os dias vão reduzir
                    if (tipoMovimento == 0)
                    {
                        // Sexta feira, e o feriado é na quinta feira
                        var _data_ = novaData.AddDays(-1);
                        // Verificando se a data corrente é um feriado
                        var frd = ChecarFeriado(_data_);
                        // Checando o valor do feriado
                        n += ChecarValorFeriado(frd, numDiasAdicionado);
                    }
                    // 0, Significando que os dias vão aumentado
                    else if (tipoMovimento == 1)
                    {
                        // Segunda feira, e o feriado é na terça feira
                        var _data_ = novaData.AddDays(1);
                        // Verificando se a data corrente é um feriado
                        var frd = ChecarFeriado(_data_);
                        // Checando o valor do feriado
                        n += ChecarValorFeriado(frd, numDiasAdicionado);
                    }
                }

                return n;
            }
            // Verificador do valor do feriado
            int ChecarValorFeriado(Feriado frd, int _numDiasAdicionado_)
            {
                int n = _numDiasAdicionado_;
                // Verificando se o feriado foi encontrado
                if (frd != null)
                {
                    // Pegando o feriado
                    var dataFeriado = ToDate(frd);

                    // Verificando se é um final de semana
                    var _weekend_ = ChecarFinalSemana(dataFeriado);

                    Func<int> other = () =>
                    {
                        // Adicionando os dias que foram adicionados por causado do final de semana no dia de feriado 
                        dataFeriado = dataFeriado.AddDays(_weekend_);

                        // Verificando a data programada
                        int diasChecados = CheckDataProgramada(dataFeriado, _numDiasAdicionado_, tipoMovimento);
                        // Checar se tem ponte
                        return ChecarPonte(dataFeriado.AddDays(n + diasChecados), diasChecados);
                    };

                    n += _weekend_ switch
                    {
                        0 => Anticipar_Posticipar(1, 1),
                        _ => other()
                    };
                }

                return n;
            }

            // Verificador de datas,
            bool DataIguais(DateTime src, DateTime dst)
                => (src.Day, src.Month, src.Year) == (dst.Day, dst.Month, dst.Year);

            // Verificando se é o dia é um final de semana
            var finalSemana = ChecarFinalSemana(dataCorrente.AddDays(numDiasAdicionado));
            // Verificando se algum dia foi adicionado
            if (finalSemana != 0)
                // Checando novamente o dia que foi adicionado
                numDias += CheckDataProgramada(dataCorrente, (numDiasAdicionado + finalSemana), tipoMovimento);
            else
                numDias += numDiasAdicionado;

            // Adicionando o numero de dias achado
            dataCorrente = dataCorrente.AddDays(numDias);
            // Checando o novo dia
            Feriado feriado = ChecarFeriado(dataCorrente);
            // Checando o feriado que foi encontrado
            numDias = ChecarValorFeriado(feriado, numDias);

            // Retornando o numero de dias encontrado
            return numDias;
        }

        /// <summary>
        /// Função auxiliar para gerar descrição com base um fraccionamento.
        /// </summary>
        /// <param name="fraccionamento">O fraccionamento em questão.</param>
        /// <param name="numDias">O número de dias.</param>
        /// <param name="dataCorrente">A data corrente</param>
        /// <returns></returns>
        private string GetDescricaoFraccionamento(Fraccionamento fraccionamento, int numDias, DateTime dataCorrente)
        {
            // Verificando se a formula base equivale a um mês
            if (fraccionamento.FormulaBase == 30)
                // Retornando o texto do mês em português
                return $"{_meses.First(m => m.Key == dataCorrente.Month).Value}/{dataCorrente.Year}";
            // Verificando se o fraccionamento é restante mas não o Único.
            else if (fraccionamento.CodFraccionamento != "F002")
                // Retornando o texto do fraccionamento
                return (numDias + 1) + ". " + fraccionamento.DesignacaoCurta;

            // Retornando o numero em formato de string
            return (numDias + 1).ToString();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Criar movimento impar.
        /// </summary>
        /// <param name="model">Movimento existente.</param>
        /// <returns></returns>
        public List<Movimento> CreateMovImparidadeContabilidade(Movimento model)
        {
            // Inserindo e configurando o movimento e adicionando na base de dados
            return Create(model, mov =>
            {
                // Instruções extra antes do movimento ser inserido na db
                return new List<Movimento> {
                    Db.InsertAsync(mov).Await()
                };
            });
        }

        /// <summary>
        /// Criação de movimento com paridade.
        /// </summary>
        /// <param name="model">Movimento existente.</param>
        /// <returns></returns>
        public List<Movimento> CreateMovParidadeContabilidade(Movimento model)
        {
            // Pegando a conta financeira
            var _contaFinanceira = Db.GetAsync<ContaFinanceira>(model.CodContaFinanceira, nameof(ContaFinanceira.CodContaFinanceira)).Await();

            // Verificando se a contafinanceira é valida
            _ = _contaFinanceira ?? throw new ArgumentNullException("Conta Financeira inválida.");

            // Adicionando valores em algumas propreidades da contafinanceira
            _contaFinanceira.DapperInclude(d => d.TipoConta);
            _contaFinanceira.DapperInclude(d => d.SubContaContabilistica);
            _contaFinanceira.DapperThenInclude(d => d.TipoConta)
                            .DapperThenInclude(d => d.SubConta);

            if (string.IsNullOrEmpty(model.CodFavorecido))
                throw new ArgumentNullException("Favorecido não informado.");

            var favorecido = Db.GetAsync<Pessoa>(model.CodFavorecido, nameof(Pessoa.CodPessoa)).Await();
            _ = favorecido ?? throw new ArgumentNullException("Favorecido inválido!");

            favorecido?.DapperInclude(e => e.Cae);
            model.CodCae = favorecido.Cae?.CodCae;

            if (!model.Contabliza.HasValue)
                model.Contabliza = default(bool);

            if (!model.IsPago.HasValue)
                model.IsPago = default(bool);

            var tipoConta = _contaFinanceira.TipoConta;

            // Verifiando se o tipo de conta da contafinanceira é válida
            _ = tipoConta ?? throw new ArgumentNullException("Tipo de Conta inválido.");

            // Variáveis auxiliares para obter dados da natureza do movimento corrente e inversa
            NaturezaMovimento naturezaCorrente = null;
            NaturezaMovimento naturezaInversa = null;

            // Executando a função de adicionar os movimentos padrão
            return Create(model, mov =>
            {
                // Configurando o movimento corrente
                naturezaCorrente = naturezaCorrente ?? Naturezas.FirstOrDefault(x => x.IdNaturezaMovimento == tipoConta.NaturezaMovimentoId);
                // Verificando as contas do tipo de operacao para que se possa configurar nas naturezas inversa e corrente
                // Se o tipo de operacao for debito então a natureza do movimento será debito
                if (TipoOperacao.SubContaDebito != null)
                    naturezaInversa = NaturezaDebito;
                // Se o tipo de operacao for debito então a natureza do movimento será credito
                else if (TipoOperacao.SubContaCredito != null)
                    naturezaInversa = NaturezaCredito;
                // Se não existe nenhuma conta definida, então por padrão a natureza será debito
                else
                    naturezaInversa = NaturezaDebito;

                // Configurando o movimento corrente
                var movimentoCorrente = SetMovimento(Mapper.Copy(mov), _contaFinanceira.SubContaContabilistica.NumSubClasse, naturezaCorrente.CodNaturezaMovimento);
                // Configurando o movimento Inverso
                var movimentoInverso = SetMovimento(Mapper.Copy(mov), tipoConta.SubConta.NumSubClasse, naturezaInversa.CodNaturezaMovimento);

                // Instruções extra antes do movimento ser inserido na db
                return new List<Movimento> {
                    Db.InsertAsync(movimentoCorrente).Await(),
                    Db.InsertAsync(movimentoInverso).Await(),
                };
            });
        }

        /// <summary>
        /// Função para configurar o objecto de movimento com alguns valores padrão.
        /// </summary>
        /// <param name="movimento">Movimento a ser configurado.</param>
        /// <param name="contaContabilistica">A conta associada ao movimento.</param>
        /// <param name="naturezaMovimento">A natureza do movimento.</param>
        /// <returns></returns>
        public Movimento SetMovimento(Movimento movimento, string contaContabilistica, string naturezaMovimento)
        {
            // Configurando as propriedades
            movimento.CodConta = contaContabilistica;
            movimento.CodNaturezaMovimento = naturezaMovimento;
            movimento.DataCriacao = DateTime.Now;
            movimento.DataAtualizacao = DateTime.Now;
            return movimento;
        }

        /// <summary>
        /// Função auxiliar para adicionar dois movimentos com base ao tipo de operacao passado como parametro
        /// </summary>
        /// <param name="movimento">O movimento existente.</param>
        /// <param name="tipoOperacao">O tipo de operação a ser registrada no movimento.</param>
        /// <returns></returns>
        public List<Movimento> CreateMovFromTipoOperacao(Movimento movimento, TipoOperacao tipoOperacao)
        {
            // Pegando o context
            var retorno = new List<Movimento>();

            // Verificando o objecto de tipo de operacao
            if (tipoOperacao?.SubContaCredito != null)
            {
                // Criando o movimento inverso
                var mov_tipoOperacao = SetMovimento(Mapper.Copy(movimento), tipoOperacao.SubContaCredito.NumSubClasse, NaturezaCredito?.CodNaturezaMovimento);
                // Adicionando as informações na base de dados
                retorno.Add(Db.InsertAsync((mov_tipoOperacao)).Await());
            }

            // Verificando o objecto de tipo de operacao
            if (tipoOperacao?.SubContaDebito != null)
            {
                // Criando o movimento inverso
                var mov_tipoOperacao = SetMovimento(Mapper.Copy(movimento), tipoOperacao.SubContaDebito.NumSubClasse, NaturezaDebito?.CodNaturezaMovimento);
                // Adicionando as informações na base de dados
                retorno.Add(Db.InsertAsync((mov_tipoOperacao)).Await());
            }

            return retorno;
        }

        /// <summary>
        /// Criar movimentos.
        /// </summary>
        /// <param name="model">Model existente para criação de movimento.</param>
        /// <param name="funcaoPrincipal"></param>
        /// <returns></returns>
        private List<Movimento> Create(Movimento model, Func<Movimento, List<Movimento>> funcaoPrincipal)
        {
            // Pegando o contexto
            var retorno = new List<Movimento>();

            #region Configuraçõe de variaveis

            // Pegando todas as contas do plano de conta para futura verificações
            var _planoContas = _dbContext.GetTable<PlanoContas>().ToList();

            // Pegando todas as naturezas de movimento para futuras verificações
            Naturezas = Naturezas ?? _dbContext.GetTable<NaturezaMovimento>().ToList();
            // Pegando a natureza credito nas naturezas cadastradas
            NaturezaCredito = NaturezaCredito ?? Naturezas.FirstOrDefault(x => x.CodNaturezaMovimento == "C");
            // Pegando a natureza debito nas naturezas cadastradas
            NaturezaDebito = NaturezaDebito ?? Naturezas.FirstOrDefault(x => x.CodNaturezaMovimento == "D");

            // Pegando o respectivo tipo
            var _tipoOperacao = Db.GetAsync<TipoOperacao>(e =>
            {
                e.DapperInclude(d => d.SubContaCredito);
                e.DapperInclude(d => d.SubContaDebito);
            }, null, nameof(TipoOperacao.CodTipoOperacao)).Await().FirstOrDefault();

            // Verificando se o mesmo foi encontrado
            if (_tipoOperacao == null)
                throw new ArgumentNullException("Tipo de operação inválido");

            // Pegando os impostos da base de dados
            var impostos = Db.GetAsync<Imposto>(e =>
            {
                e.TipoOperacao.DapperInclude(d => d.SubContaCredito);
                e.TipoOperacao.DapperInclude(d => d.SubContaDebito);
            }).Await().ToList();

            // Pegando a conta financeira
            var _tipoDocumentos = Db.GetAsync<TipoDocumentos>(e =>
            {
                e.DapperInclude(d => d.ImpostoTipoDocumentos);
                e.ImpostoTipoDocumentos.For(i => i.Imposto = impostos.FirstOrDefault(x => x.IdImposto == i.ImpostoId));
            }, model.CodTipoDocumentos, nameof(TipoDocumentos.CodTipoDocumentos)).Await().FirstOrDefault();

            // Verificando se o tipo de documento foi mando e é válido
            if (_tipoDocumentos == null)
                throw new ArgumentNullException("Tipo de documento inválido.");

            // Pegando o fraccionamento mandado
            var fraccionamento = Db.GetAsync<Fraccionamento>(model.CodFraccionamento, nameof(Fraccionamento.CodFraccionamento)).Await();
            var favorecido = Db.GetAsync<Pessoa>(model.CodFavorecido, nameof(Pessoa.CodPessoa)).Await();
            // Incluindo os dados dos campos das contas contabilisticas 
            fraccionamento.DapperThenInclude(d => d.TipoOperacao).DapperThenInclude(d => d.SubContaCredito);
            fraccionamento.DapperThenInclude(d => d.TipoOperacao).DapperThenInclude(d => d.SubContaDebito);
            favorecido.DapperThenInclude(d => d.Cae);

            #endregion

            // Setando campos estaticos
            model.Identificador = Guid.NewGuid().ToString();
            // Passando o codigo da operacao no codigo do movimento
            // model.CodOperacao = _tipoOperacao.CodTipoOperacao;
            // Configurando uma referencia
            model.Referencia = model.Referencia ?? StringHelper.SetCode("MO_");
            // Definindo o numero de parcelas de por acaso não foi mandado
            model.DocumentoParcelado = model.DocumentoParcelado == null ? 1 : model.DocumentoParcelado;
            // Configurando a descrição do movimento
            model.DescricaoMovimento = $"{ _tipoOperacao.Designacao } { _tipoDocumentos.HistoricoMovimento } { _tipoDocumentos.Designacao } N.: { model.NumeroDocumentoExterno } { fraccionamento?.Designacao }";
            // Atribuir o cae de acordo a pessoa dada como favorecido.
            model.CodCae = !string.IsNullOrEmpty(model.CodCae) ? model.CodCae : favorecido?.Cae?.CodCae;
            // Definindo o tipo de operação seleccionando para o movimento em questão
            TipoOperacao = _tipoOperacao;


            // Armazendo os dados da data programada em uma variavel para que seja feita certas configurações
            var dataProgramanda = model.DataProgramada;
            // Verificando se foi mando uma data programada
            if (dataProgramanda == null)
                // Configurando a data programada como sendo a data corrente
                dataProgramanda = DateTime.Now;

            //TODO:  IVA pelo numero de parcelas

            // Inserindo os movimento com base o numero de parcelas
            for (int i = 0; i < model.DocumentoParcelado; i++)
            {
                // Gerando um novo objecto de movimento com base o que foi passado pelo parametro
                Movimento movParcelado = Mapper.Copy(model);

                #region Configuração do valores e as descrições

                // Divisão do valor com base ao valor parcelado
                movParcelado.Valor /= (int)model.DocumentoParcelado;
                movParcelado.ValorOutraMoeda /= (int)model.DocumentoParcelado;

                // Verificando o numero de parcelas para que se possa adicionar o numero de parcelas nas referencias do movimento
                if (model.DocumentoParcelado > 1)
                    // Adicionando o numero de parcelas na referencia
                    movParcelado.Referencia += $"-{string.Format("{0:00}", (i + 1))}";

                // Verificando se o numero de parcelas é 1 para poder anular o valor que foi passado no movimento
                if (model.DocumentoParcelado == 1)
                    // Anulando o valor passado
                    dataProgramanda = null;
                else
                {
                    // Verificando se o dia é valido
                    int num = CheckDataProgramada(dataProgramanda.Value, (int)fraccionamento.FormulaBase, TipoOperacao.TipoMovimento);
                    // Adicionando o numero de dias
                    dataProgramanda = dataProgramanda.Value.AddDays(num);
                    movParcelado.DataVencimento = dataProgramanda;
                    movParcelado.DescricaoMovimento += ": " + GetDescricaoFraccionamento(fraccionamento, i, (DateTime)dataProgramanda);
                }

                movParcelado.DataProgramada = dataProgramanda;

                #endregion

                // Executando a função principal e adicionando o retorno da função na lista de retorno da funçao principal
                retorno.AddRange(funcaoPrincipal.Invoke(movParcelado));

                #region Movimento do Fraccionamento

                if (fraccionamento != null && fraccionamento.Taxa > 0)
                {
                    // Gerando um novo objecto de movimento com base o que foi passado pelo parametro
                    var movFraccionamento = Mapper.Copy(movParcelado);
                    // Aplicando a taxa do fraccionamento
                    movFraccionamento.Valor = (movFraccionamento.Valor * (fraccionamento.Taxa / 100 ?? 0));
                    movFraccionamento.ValorOutraMoeda = (movFraccionamento.ValorOutraMoeda * (fraccionamento.Taxa / 100 ?? 0));

                    // Configurando a descrição do movimento com base o fraccionamento
                    movFraccionamento.DescricaoMovimento += ",  Fraccionamento: " + fraccionamento.TipoOperacao.Designacao;

                    // Adicionando os movimento na base de dados e adicionando na lista de retorno
                    retorno.AddRange(CreateMovFromTipoOperacao(movFraccionamento, fraccionamento.TipoOperacao));
                }

                #endregion

                #region Movimento de Tipo de Operacao
                // Gerando um novo objecto de movimento com base o que foi passado pelo parametro
                var mov_tipoOperacao = Mapper.Copy(movParcelado);
                // Adicionando os movimentos na base de dados
                retorno.AddRange(CreateMovFromTipoOperacao(mov_tipoOperacao, _tipoOperacao));

                #endregion

                #region Impostos do Documento

                // Adicionando dos impostos
                _tipoDocumentos.ImpostoTipoDocumentos.For(x =>
                {
                    // Gerando um novo objecto de movimento com base o que foi passado pelo parametro
                    var mov_imposto = Mapper.Copy(movParcelado);
                    // Pegando o respectivo imposto
                    var imposto = x.Imposto;
                    // Aplicando a taxa do imposto
                    mov_imposto.Valor = (mov_imposto.Valor * (imposto.TaxaImposto / 100 ?? 0));
                    mov_imposto.ValorOutraMoeda = (mov_imposto.ValorOutraMoeda * (imposto.TaxaImposto / 100 ?? 0));
                    // Adicionando os movimentos na base de dados  e na lista de retorno
                    retorno.AddRange(CreateMovFromTipoOperacao(mov_imposto, imposto.TipoOperacao));

                });

                #endregion
            }

            TipoOperacao = null;

            return retorno;
        }

        /// <summary>
        /// Movimento com paridade geral.
        /// </summary>
        /// <param name="model">Movimento existente.</param>
        /// <returns></returns>
        public List<Movimento> CreateMovParidadeGeral(Movimento model)
        {
            // Executando a função de adicionar os movimentos padrão
            return Create(model, mov =>
            {
                // Instruções extra antes do movimento ser inserido na db
                return new List<Movimento> {
                    // TODO: Falta mais um movimento a ser adicionado
                    Db.InsertAsync(mov).Await()
                };
            });
        }
        #endregion
    }
}