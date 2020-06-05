using ISS.GraphQL.Repository;
using ISS.Application;
using ISS.Application.Dto;
using ISS.Application.Dto.Calculos;
using ISS.Application.Helpers;
using ISS.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ISS.Application.Movimentos;

/*

    Fórmulas dos Calculos, definidas pelo Sr. Eduardo Jeremias e pela Lei.

     * * Premio Base = ( Depende do Tarifário e da linha )
    
     * * Premio de Risco = ( (Quantidade de Sinistro / Unidade Expostas ao Risco) * (Valor Total de Sinistro / Quantidade de Sinistro) ) + Premio Base
    
     * * Premio Simples = Premio de Risco + (Premio de Risco * Margem de Segurança)
    
     * * Sinistro Esperado = (Capital Seguro / Numero de Unidadades Contratadas)
    
     * * Margem Comercial = (Sinistro Esperado / Numero de Unidadades Contratadas) 
                            + (Sinistro Esperado / Numero de Unidadades Contratadas) 
                            + Margem de Segurança
                            + Comissoes 
                            - Despesas 
                            + EncargosAdministrativos

     * * Encargo Administrativo = Premio Simples * Taxa de Encargo Administrativo  
    
     * * Premio Comercial = Premio Simples + Margem Comercial + Margem de Comercial
    
     * * Taxa Comercial = Premio Comericial / Capital Seguro / Numero de Unidades Contratadas
    
     * * Premio Bruto = Premio Comercial + Impostos Indiretos + Custo da Apolice
     
     * * Premio Cobrado = Premio Bruto * Numero de Unidades Contratadas
     * 
     *  Notas:
        Sempre que for pego um registro de uma tabela onde existe ligação com a um tipo de operação, então terá que gerar um movimento dessa registro 
        com base o tipo de operação existente no registro.

    */

namespace ISS.GraphQL.Calculo
{
    public class Calculos 
    {
        #region Variaveis auxiliares
        private ICollection<Pessoa> pessoas;
        private readonly Movimentos _movimentos;
        #endregion

        #region Public Properties
        // Variavel auxiliar para armazenar as moedas que serão utilizadas
        public static List<Moeda> Moedas { get; set; }

        public ISS.Application.Cambio.ConversaoMoedas Conversao { get; set; }
        public Pessoa Tomador { get; set; }

        // Variavel auxiliar para armazenar temporariamente as coberturas do plano que serão utilizadas
        public List<CoberturaPlano> CoberturasPlano { get; set; } = new List<CoberturaPlano>();

        // Variavel auxiliar para armazenar temporariamente as contas contabilistica que serão utilizadas
        public List<PlanoContas> Contas { get; set; }

        // Variavel auxiliar para armazenar temporariamente as plano do produto que serão utilizadas
        public List<PlanoProduto> PlanosProduto { get; set; } = new List<PlanoProduto>();

        public List<PrecarioProduto> PrecariosProduto { get; set; } = new List<PrecarioProduto>();

        // Variavel do context da base de dados
        public DapperContext Db { get; set; }
        private readonly IRepository _repository;

        // O Tomador da Cotacao / Apolice
        public List<Pessoa> Pessoas { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Padrão.
        /// </summary>
        /// <param name="dapperDb">Contexto para acesso a base de dados via Dapper.</param>
        /// <param name="repository">Repositório de dados.</param>
        public Calculos(DapperContext dapperDb, IRepository repository = null)
        {
            // Configurando o context da base de dados
            Db = dapperDb;
            _repository = repository;

            Conversao = new ISS.Application.Cambio.ConversaoMoedas(dapperDb);
            _movimentos = new Movimentos(Db, null);
        } 
        #endregion

        /// <summary>
        /// Limpar propriedades virtuais de um objecto.
        /// </summary>
        /// <param name="model">O model.</param>
        private void LimparPropsVirtuais(CalculoModel model)
        {
            model.ClearVirtual();
            CoberturasPlano.RemoveAll(x => true);
            Contas.RemoveAll(x => true);
            PlanosProduto.RemoveAll(x => true);
        }

        /// <summary>
        /// Configurar as coberturas quando necessário.
        /// </summary>
        /// <param name="model">O model.</param>
        private void SetCoberturas(CalculoModel model)
        {
            /* Filtrando as coberturas seleccionadas */
            // Verificando se já existe cobertudas do plano na lista
            if (CoberturasPlano?.Count == 0)
            {
                // Pegando os tipos de margens
                var tipoMargens = _repository.ExecuteQuery(dbContext => dbContext.GetTable<TipoMargem>().ToList());

                //Pegando os fraccionamentos na base de dados
                var fraccionamentos = _repository.ExecuteQuery(dbContext => dbContext.GetTable<Fraccionamento>().ToList());

                // Pegando as coberturas
                var coberturas = Db.GetAsync<Cobertura>(e =>
                {
                    e.DapperInclude(d => d.Franquia)
                     .DapperInclude(d => d.SubConta);
                }).Await();

                // Pegando as coberturas do plano e incluindo os dados necessários
                var coberturaPlano = Db.GetAsync<CoberturaPlano>(e =>
                {
                    e.DapperThenInclude(d => d.PlanoProduto)
                     .DapperThenInclude(d => d.LinhaProduto)
                     .DapperThenInclude(d => d.Produto);

                    e.DapperThenInclude(d => d.PlanoProduto)
                     .DapperThenInclude(d => d.LinhaProduto)
                     .DapperThenInclude(d => d.Tarifa);

                    e.DapperThenInclude(d => d.PlanoProduto)
                     .DapperThenInclude(d => d.AgravamentoPlano);

                    e.DapperThenInclude(d => d.PlanoProduto)
                     .DapperThenInclude(d => d.FraccionamentoPlano);

                    e.DapperThenInclude(d => d.PlanoProduto)
                     .DapperThenInclude(d => d.PrecarioProduto);

                    e.DapperThenInclude(d => d.PlanoProduto)
                     .DapperThenInclude(d => d.MargemVendaProduto);

                    e.Cobertura = coberturas.FirstOrDefault(x => x.IdCobertura == e.CoberturaId);
                    e.PlanoProduto.FraccionamentoPlano
                     .For(x => x.Fraccionamento = fraccionamentos.FirstOrDefault(f => f.IdFraccionamento == x.FraccionamentoId));

                    e.PlanoProduto.MargemVendaProduto
                     .For(i => i.TipoMargem = tipoMargens.FirstOrDefault(c => c.IdTipoMargem == i.TipoMargemId));
                }).Await();

                // Pegando as moedas
                Moedas ??= _repository.ExecuteQuery(dbContext => dbContext.GetTable<Moeda>().ToList());
                // Pegando os dados do plano de conta
                Contas ??= _repository.ExecuteQuery(dbContext => dbContext.GetTable<PlanoContas>().ToList());

                // Filtrando as coberturas seleccionada
                // TODO: Saber se na simulação as coberturas são selecionaveis
                coberturaPlano.For(c =>
                {
                    if (model.Cotacao == null)
                        return;
                    // Verificando se a corrente cobertuta plano foi mandado pelo usuario
                    if (model.Cotacao.CoberturaSelecionada.Any(x => x.CoberturaPlanoId == c.IdCoberturaPlano))
                    {
                        // Adicionando na lista de coberturas mandadas
                        CoberturasPlano.Add(c);
                        // Verificando se já foi adicionado algum plano que deverá ser utilizado
                        if (!PlanosProduto.Any(p => p.IdPlano == c.PlanoProdutoId))
                            // Adicionando o plano.
                            PlanosProduto.Add(c.PlanoProduto);
                    }
                });
            }

            /* End Filtrando as coberturas seleccionadas */
        }

        /// <summary>
        /// Cálcular os valores das váriaveis adicionais.
        /// </summary>
        /// <param name="model">O model.</param>
        /// <param name="analiseRisco">A análise de risco.</param>
        /// <returns></returns>
        public CalculoModel CalcularVariaveis(CalculoModel model, bool analiseRisco = false)
        {
            model.Agravamentos += Agravamentos(model);
            model.AgravamentosPorIdade += AgravamentosPorIdade(model, analiseRisco);
            model.PremioSimples += PremioSimples(model);
            model.SinistroEsperado += SinistroEsperado(model);

            model.EncargosAdministrativos += EncargoAdmintrativo(model);
            model.Encargos += EncargosPlano(model);
            model.PremioComercial += PremioComercial(model);
            model.Despesas += Despesas(model);
            model.Ofertas += Ofertas(model);
            model.Descontos -= Descontos(model);
            model.DescontosPorIdade -= DescontosPorIdade(model, analiseRisco);

            model.Impostos += Impostos(model);
            model.PremioBruto += PremioBruto(model);
            model.PremioCobrado = PremioCobrado(model);

            return model;
        }

        /// <summary>
        /// Efetua todos os calculos de uma só vez para que não e faca separado
        /// </summary>
        /// <param name="model">O Objecto de entrada onde será de passado o DbContext e a Cotacao</param>
        /// <returns> RetornaO objecto calculo prenchido</returns>
        public CalculoModel CalculoGeral(CalculoModel model, bool CriarMovimento = false)
        {
            try
            {
                // Verificando se o object de cotacoa foi mandado
                if (model.Cotacao == null)
                    // Parando a execuçao
                    throw new Exception("Cotacão inválida");

                #region Configuração Base
                // Configurando o tomador
                Pessoas = _repository.ExecuteQuery(db => db.Pessoa.ToList());
                var cotacaoDependente = Db.GetAsync<CotacaoDependente>(e => e.DapperThenInclude(d => d.Apolice).DapperThenInclude(d => d.Sinistro)).Await();
                Pessoas.For(p => p.DapperThenInclude(d => d.CotacaoCobrador).For(c => c.CotacaoDependente = cotacaoDependente.Where(cd => cd.CotacaoId == c.IdCotacao).ToList()));

                // Definindo o Tomador
                Tomador = Pessoas.FirstOrDefault(x => x.IdPessoa == model.Cotacao.TomadorId);
                var fraccionamento = _repository.ExecuteQuery(db => db.GetTable<Fraccionamento>().FirstOrDefault( x => x.IdFraccionamento == model.Cotacao.FraccionamentoId));

                // Configurando o capital seguro se ele não foi configurado
                model.CapitalSeguro = model.Cotacao.CapitalSeguro == null ? 0 : (double)model.Cotacao.CapitalSeguro;
                // Chamando o metodo de coberturas para que sejam configuradas
                SetCoberturas(model);
                #endregion

                var mapper = new MapBuilder.Mapper();

                // Construindo o preçario base
                foreach (var p in PlanosProduto)
                {
                    // Configurando o plano
                    model.Plano = p;
                    // Obtendo o valor do premio base
                    model.PremioBase += PremioBase(model);
                }

                // Verificando se o premio base foi calculado
                if (model.PremioBase == 0)
                    throw new Exception("Premio base igual a zero, algo deve estar errado com as coberturas seleccionado enviadas.");

                // Copiando o objecto de calculoModel
                var calculoModelTemplate = mapper.Copy(model);

                // Variavel auxiliar que permite controlar se os calculos devem ser feitos com analise de risco.
                bool analiseRisco = true;

                // Verificando se calculo deve ser feito com analise de risco
                if (analiseRisco)
                {
                    // Aplicando analise de risco por pessoa assegurada
                    model.Cotacao.MembroAssegurado.For(m =>
                    {
                        // Criando uma copia do modelo de calculo
                        var modelTemplate = mapper.Copy(calculoModelTemplate);
                        // Calculando o premio de risco de cada pessoa
                        modelTemplate.PremioRisco = PremioRisco(modelTemplate, m.PessoaId);
                        // Calculando todas variaveis
                        modelTemplate = this.CalcularVariaveis(modelTemplate, analiseRisco);
                        // Adicionando os modelos de analise de risco
                        model.AnaliseRisco.Add(modelTemplate);
                    });

                    if (model.AnaliseRisco.Any())
                    {
                        // Somando todos os valores da analise de risco
                        model.PremioRisco = model.AnaliseRisco.Sum(c => c.PremioRisco);
                        model.PremioSimples = model.AnaliseRisco.Sum(c => c.PremioSimples);
                        model.PremioComercial = model.AnaliseRisco.Sum(c => c.PremioComercial);
                        model.PremioBruto = model.AnaliseRisco.Sum(c => c.PremioBruto);
                        model.PremioCobrado = model.AnaliseRisco.Sum(c => c.PremioCobrado);

                        model.Agravamentos = model.AnaliseRisco.Sum(c => c.Agravamentos);
                        model.AgravamentosPorIdade = model.AnaliseRisco.Sum(c => c.AgravamentosPorIdade);
                        model.Arseg = model.AnaliseRisco.Sum(c => c.Arseg);
                        model.CapitalSeguro = model.AnaliseRisco.Sum(c => c.CapitalSeguro);
                        model.EncargosAdministrativos = model.AnaliseRisco.Sum(c => c.EncargosAdministrativos);
                        model.Descontos = model.AnaliseRisco.Sum(c => c.Descontos);
                        model.DescontosPorIdade = model.AnaliseRisco.Sum(c => c.DescontosPorIdade);
                        model.Despesas = model.AnaliseRisco.Sum(c => c.Despesas);
                        model.Impostos = model.AnaliseRisco.Sum(c => c.Impostos);
                        model.Iva = model.AnaliseRisco.Sum(c => c.Iva);
                        model.Ofertas = model.AnaliseRisco.Sum(c => c.Ofertas);
                        model.SinistroEsperado = model.AnaliseRisco.Sum(c => c.SinistroEsperado);
                    }

                    // Verificando o numero de pessoas asseguradas para que possa ser somado todos os premios de risco.
                    if (!model.Cotacao.MembroAssegurado.Any())
                    {
                        // Somando os premios
                        model.PremioRisco += PremioRisco(model, model.Cotacao.TomadorId);

                        // Calculando todas variaveis
                        model = this.CalcularVariaveis(model);
                    }
                }
                else
                {
                    // Verificando o numero de pessoas asseguradas para que possa ser somado todos os premios de risco.
                    if (model.Cotacao.MembroAssegurado.Count > 0)
                        // Somando os premios
                        model.Cotacao.MembroAssegurado.For(p => model.PremioRisco += PremioRisco(model, p.PessoaId));
                    else
                        // Calculando o premio de risco do tomador
                        model.PremioRisco += PremioRisco(model, model.Cotacao.TomadorId);

                    // Calculando todas variaveis
                    model = this.CalcularVariaveis(model);
                }
                model.JurosFraccionamento = model.PremioSimples * (double)fraccionamento.Taxa;
                // Fraccionando os premios
                model.PremiosFraccionado = this.PremioFraccionado(model);

                

                LimparPropsVirtuais(model);

            }
            catch (Exception ex)
            {
                LimparPropsVirtuais(model);
                // Configurando o erro
                model.Status = false;
                model.Message = $"{ex.Message} . {ex.InnerException?.Message}";
            }

            return model;
        }

        /// <summary>
        /// Simular cálculos para qualquer producto em proposta de seguro.
        /// </summary>
        /// <param name="model">Model contendo as variáveis necessárias.await\</param>
        /// <param name="CriarMovimento">Especificar se deve-se criar movimento.</param>
        /// <returns></returns>
        public CalculoModel CalculoSimulacao(CalculoModel model, bool CriarMovimento = false)
        {
            try
            {
                _ = model.Simulacao ?? throw new ArgumentNullException(nameof(model.Simulacao),"Necessário o objecto para simulação");

                #region Configuração Base
                // Pegando todas as pessoas
                Pessoas = _repository.ExecuteQuery(db => db.Pessoa.ToList());

                // Definindo o Tomador
                // TODO: Buscar pelo tomador na base de dados.
                Tomador = Pessoas.FirstOrDefault(x => x.IdPessoa == model.Simulacao.PessoaId);

                // Configurando o capital seguro se ele não foi configurado
                // model.CapitalSeguro = model.Simulacao.CapitalSeguro == null ? 0 : (double)model.Cotacao.CapitalSeguro;

                // Chamando o metodo de coberturas para que sejam configuradas
                SetCoberturas(model);
                #endregion

                var mapper = new MapBuilder.Mapper();

                // Pegar o plano do producto selecionado.
                model.Plano = _repository.ExecuteQuery(db => db.PlanoProduto.FirstOrDefault(x => x.IdPlano == model.Simulacao.PlanoProdutoId));
                if (model.Plano != null)
                    model.Plano.DapperInclude(e => e.LinhaProduto);
                    
                // Obtendo o valor do premio base
                model.PremioBase += PremioBaseSimulacao(model);

                // Verificando se o premio base foi calculado
                if (model.PremioBase == 0)
                    throw new Exception("Premio base igual a zero, algo deve estar errado com as coberturas seleccionado enviadas.");

                // Copiando o objecto de calculoModel
                var calculoModelTemplate = mapper.Copy(model);

                // Variavel auxiliar que permite controlar se os calculos devem ser feitos com analise de risco.
                bool analiseRisco = true;

                // Verificando se calculo deve ser feito com analise de risco
                if (analiseRisco)
                {
                    if (model.AnaliseRisco.Any())
                    {
                        // Somando todos os valores da analise de risco
                        model.PremioRisco = model.AnaliseRisco.Sum(c => c.PremioRisco);
                        model.PremioSimples = model.AnaliseRisco.Sum(c => c.PremioSimples);
                        model.PremioComercial = model.AnaliseRisco.Sum(c => c.PremioComercial);
                        model.PremioBruto = model.AnaliseRisco.Sum(c => c.PremioBruto);
                        model.PremioCobrado = model.AnaliseRisco.Sum(c => c.PremioCobrado);

                        model.Agravamentos = model.AnaliseRisco.Sum(c => c.Agravamentos);
                        model.AgravamentosPorIdade = model.AnaliseRisco.Sum(c => c.AgravamentosPorIdade);
                        model.Arseg = model.AnaliseRisco.Sum(c => c.Arseg);
                        model.CapitalSeguro = model.AnaliseRisco.Sum(c => c.CapitalSeguro);
                        model.EncargosAdministrativos = model.AnaliseRisco.Sum(c => c.EncargosAdministrativos);
                        model.Descontos = model.AnaliseRisco.Sum(c => c.Descontos);
                        model.DescontosPorIdade = model.AnaliseRisco.Sum(c => c.DescontosPorIdade);
                        model.Despesas = model.AnaliseRisco.Sum(c => c.Despesas);
                        model.Impostos = model.AnaliseRisco.Sum(c => c.Impostos);
                        model.Iva = model.AnaliseRisco.Sum(c => c.Iva);
                        model.Ofertas = model.AnaliseRisco.Sum(c => c.Ofertas);
                        model.SinistroEsperado = model.AnaliseRisco.Sum(c => c.SinistroEsperado);
                    }

                    // Verificando o numero de pessoas asseguradas para que possa ser somado todos os premios de risco.
                    if (model.Simulacao?.NumPessoas > 0)
                    {
                        // Somando os premios
                        model.PremioRisco += PremioRisco(model, model.Simulacao.PessoaId);

                        // Calculando todas variaveis
                        model = this.CalcularVariaveis(model);
                    }
                }
                else
                {
                
                    // Calculando o premio de risco do tomador
                    model.PremioRisco += PremioRisco(model, model.Simulacao.PessoaId);

                    // Calculando todas variaveis
                    model = this.CalcularVariaveis(model);
                }

                // Fraccionando os premios
                model.PremiosFraccionado = PremioFraccionado(model);

                LimparPropsVirtuais(model);

            }
            catch (Exception ex)
            {
                LimparPropsVirtuais(model);
                // Configurando o erro
                model.Status = false;
                model.Message = $"{ex.Message} . {ex.InnerException?.Message}";
            }

            return model;
        }

        #region Calculo de Subscricao
        /// <summary>
        ///  Cálculo do prémio base, baseado na linha de producto e tárifario.
        /// </summary>
        /// <param name="model">Model contendo informações necessárias para o cálculo.</param>
        /// <returns></returns>
        public double PremioBase(CalculoModel model)
        {
            // Pegando a linha em que a cobertura pertence
            var plano = model.Plano;
            var linha = plano.LinhaProduto;

            double valor = 0;
            // Verificando se a linha não está nula
            if (linha != null)
            {
                switch (linha.CodLinhaProduto)
                {
                    case "I33":
                        {
                            // Verificando se as datas mandadas para a cotação são válidas
                            if (model.Cotacao.DataExpiracao == null || model.Cotacao.DataInicio == null)
                                return valor;

                            // Calculando o numero de dias da apolice
                            model.NumDiasApolice = model.Cotacao.DataExpiracao.Value.Subtract((DateTime)model.Cotacao.DataInicio).Days;

                            // Pegando o precario de acordo ao numero de dias
                            var preco = plano.PrecarioProduto.ToList()
                                            .OrderBy(x => x.QtdDiaMax)
                                            .FirstOrDefault(x =>
                                            (x.QtdDiaMin <= model.NumDiasApolice && model.NumDiasApolice <= x.QtdDiaMax));

                            // Verificando se o precario foi encontrado
                            if (preco == null) return 0;

                            PrecariosProduto.Add(preco);

                            // Calculando o cambio e Adicionadono os dados nos movimento
                            var cambio = CambioEMovimento(model, preco.TipoOperacao, preco.MoedaId, (double)preco.PrecoBase);
                            // Pegando o valor convertido
                            valor = (double)cambio.ValorOutraMoeda;

                            return valor;
                        }
                    case "I311":
                        {
                            var pessoaProfissao = Db.GetAsync<PessoaProfissao>(e =>
                                                e.DapperThenInclude(d => d.Profissao)
                                                 .DapperThenInclude(d => d.NivelRisco)).Await().ToList();

                            var caes = Db.GetAsync<Cae>().Await();

                            // Funcão auxiliar para configurar a pessoa que está a ser pego na base de dados
                            void ConfigPessoa(Pessoa e)
                            {
                                e.DapperInclude(d => d.RendimentoPessoaPessoa);
                                e.Cae = caes.FirstOrDefault(c => c.IdCae == e.Caeid);
                                e.PessoaProfissao = pessoaProfissao.Where(pp => pp.PessoaId == e.IdPessoa).ToList();
                            }

                            // Pegando o tomador
                            var tomador = Db.GetAsync<Pessoa>
                                (e => ConfigPessoa(e), Tomador.IdPessoa, nameof(Pessoa.IdPessoa)).
                                Await().FirstOrDefault();

                            // Pegando o CAE do tomador
                            var cae = tomador?.Cae;

                            // Forma de Liquidação
                            var formaLiquidicao = Db.GetAsync<FormaLiquidacaoPremio>
                                (model.Cotacao.FormaLiquidacaoPremioId, nameof(FormaLiquidacaoPremio.IdFormaLiquidacaoPremio)).Await();

                            switch (formaLiquidicao.CodFormaLiquidacaoPremio)
                            {
                                // Variavel
                                case "F000":

                                    //TODO: Ignora-se o número de trabalhadores valor = (double)(model.Cotacao.CapitalSeguro * tomador.NumEmpregados);
                                    valor = (double)(model.Cotacao.CapitalSeguro);
                                    // Aplicando a taxa do cae
                                    valor = (bool)cae.IsTaxa ? (double)(valor * cae.TaxaComercial / 100) : (double)(valor + cae.TaxaComercial);
                                    break;

                                // Fixo
                                case "F001":

                                    // Variavel auxiliar onde estará todas pessoas seleccionada nos membros assegurados
                                    var pessoas = new List<(Pessoa, MembroAssegurado)>();

                                    // Percorrendo os membros assegurados
                                    model.Cotacao.MembroAssegurado.For(m =>
                                    {
                                        // Pegando a pessoa em que o Id equivale o membro assegurado e inserindo na variavle auxilar
                                        var p = Db.GetAsync<Pessoa>(e => ConfigPessoa(e)
                                        , m.PessoaId, nameof(Pessoa.IdPessoa)).Await().FirstOrDefault();

                                        if (p == null) return;

                                        pessoas.Add((p, m));
                                    });

                                    // Percorrenco as pessoas
                                    pessoas.ForEach(pessoa =>
                                    {
                                        double salarioBase = 0.0;
                                        double subsidios = 0.0;
                                        
                                        foreach (var salario in pessoa.Item1.RendimentoPessoaPessoa)
                                        {
                                            salario.DapperInclude(e => e.TipoRendimento);
                                            salario.DapperInclude(e => e.ComponenteSalarialPessoa);
                                            if (salario.TipoRendimento?.CodTipoRendimento != "S002")
                                                continue;
                                            salarioBase = (double)salario.Valor;
                                            subsidios = (double)salario.ComponenteSalarialPessoa?.Sum(x => x.ValorSubsidio);
                                            break;
                                        }

                                        // Salário base vezes os meses, incluindo o 13º
                                        salarioBase *= 13;
                                        subsidios *= 11;
                                        valor += salarioBase + subsidios;
                                        pessoa.Item2.PremioBase = valor;
                                        
                                        //// Pegando a profissaão da pessoa
                                        //var pProfissao = pessoa.Item1.PessoaProfissao.FirstOrDefault(c => c.ProfissaoId == pessoa.Item2.ProfissaoId);

                                        //// Verificando se a profissão foi encontrada
                                        //if (pProfissao == null) return;

                                        //var salario = pProfissao.SalarioLiquido + pProfissao.OutroRendimento;

                                        //// Somando nos valores dos salarios * a taxa do risco da profissão
                                        //valor += (double)(salario + salario * (pProfissao.Profissao.NivelRisco.Taxa / 100 ?? 0));
                                    });

                                    // Aplicando a taxa do cae
                                    valor = (bool)cae.IsTaxa ? (double)(valor * cae.TaxaComercial / 100) : (double)(valor + cae.TaxaComercial);

                                    // Criando a massa salarial liquida
                                    model.CapitalSeguro = (double)valor;

                                    break;
                            }

                            // Percorrenco as coberturas seleccionadas na apolice
                            model.Cotacao.CoberturaSelecionada.For(x =>
                            {
                                // Somando nos valores para o retorno do preco base
                                valor += x.ValorPersonalizado ?? 0;
                            });

                            return valor;
                        }
                    case "II1216":
                        {
                            _ = model.Cotacao?.ObjectoSegurado ?? throw new ArgumentNullException("Automóveis não fora fornecidos");
                            // Pegando as cilindragem
                            var cilinds = Db.GetAsync<CilindragemAutomovel>().Await().ToList();

                            // Percorrendo os automóveis a serem assegurados
                            model.Cotacao.ObjectoSegurado.For(x =>
                            {
                                // Pegando o automóvel.
                                var automovel = Db.GetAsync<Automovel>(x.AutomovelId, nameof(Automovel.IdAutomovel)).Await();

                                // Pegando a cilindragem.
                                automovel?.DapperInclude(e => e.CilindragemAutomovel);

                                // Verificando se a cilindragem foi encontrada
                                if (automovel?.CilindragemAutomovel != null)
                                {
                                    // Calculando o cambio e Adicionadono os dados nos movimento
                                    var cambio = CambioEMovimento(model, default, automovel.CilindragemAutomovel.MoedaId, (double)automovel.CilindragemAutomovel.PremioUcf);

                                    // Somando nos valores para o retorno do preco base
                                    valor += (double)cambio.ValorOutraMoeda;
                                }
                            });

                            // Percorrendo as coberturas seleccionadas na apolice
                            model.Cotacao.CoberturaSelecionada.For(x =>
                            {
                                // Somando os valores personalizados
                                valor += (x.ValorPersonalizado ?? 0);
                            });

                            return valor;

                        }
                    default:
                        {
                            // Pegando o primeiro preco definido para o plano corrente
                            var preco = plano.PrecarioProduto.FirstOrDefault();

                            // Verificando se o precario foi encontrado
                            if (preco == null)
                                return 0;

                            PrecariosProduto.Add(preco);

                            // Pegando valor base
                            valor = (double)preco.PrecoBase;

                            // Percorrendo os valores seleccinados no cobertura da apolice
                            model.Cotacao.CoberturaSelecionada.For(x =>
                            {
                                // Somando os valores
                                valor += (double)x.ValorPersonalizado;
                            });

                            return valor;
                        }
                }
            }
            // Preco Base
            return valor;
        }

        public double PremioBaseSimulacao(CalculoModel model)
        {
            // Pegando a linha em que a cobertura pertence
            var plano = model.Plano;
            var linha = plano.LinhaProduto;

            double? valor = 0;
            // Verificando se a linha não está nula
            if (linha != null)
            {
                switch (linha.CodLinhaProduto)
                {
                    case "I33":
                        {
                            // Verificando se as datas mandadas para a cotação são válidas
                            // TODO: Para simulação não é especificada a data de inicio e fim da proposta ?
                            //if (model.Simulacao.DataExpiracao == null || model.Cotacao.DataInicio == null)
                            //    return valor == null ? 0 : (double)valor;

                            // Calculando o numero de dias da apolice
                            // TODO: Não há necessidade de obter o número de dias para a proposta ?
                            // model.NumDiasApolice = model.Cotacao.DataExpiracao.Value.Subtract((DateTime)model.Cotacao.DataInicio).Days;

                            // Inclusão do preçario do produto.
                            plano.DapperInclude(e => e.PrecarioProduto);
                            // Pegando o precario de acordo ao numero de dias
                            var preco = plano.PrecarioProduto.ToList()
                                            .OrderBy(x => x.QtdDiaMax)
                                            .FirstOrDefault(x =>
                                            (x.QtdDiaMin <= model.Simulacao.NumDias && model.Simulacao.NumDias <= x.QtdDiaMax));

                            // Verificando se o precario foi encontrado
                            if (preco == null) return 0;

                            // Inclusão de moeda e do tipo de operação. 
                            preco.DapperInclude(e => e.TipoOperacao);
                            preco.DapperInclude(e => e.Moeda);
                            
                            // Adicionar a lista de preçarios.
                            PrecariosProduto.Add(preco);

                            // Calculando o cambio e Adicionadono os dados nos movimento
                            var cambio = CambioEMovimento(model, preco.TipoOperacao, preco.MoedaId, (double)preco.PrecoBase);
                            // Pegando o valor convertido
                            valor = cambio.ValorOutraMoeda;

                            return valor == null ? 0 : (double)valor;
                        }
                    case "I311":
                        {
                            var pessoaProfissao = Db.GetAsync<PessoaProfissao>(e =>
                                                e.DapperThenInclude(d => d.Profissao)
                                                 .DapperThenInclude(d => d.NivelRisco)).Await().ToList();

                            var caes = Db.GetAsync<Cae>().Await();

                            // Funcão auxiliar para configurar a pessoa que está a ser pego na base de dados
                            void ConfigPessoa(Pessoa e)
                            {
                                e.DapperInclude(d => d.RendimentoPessoaPessoa);
                                e.Cae = caes.FirstOrDefault(c => c.IdCae == e.Caeid);
                                e.PessoaProfissao = pessoaProfissao.Where(pp => pp.PessoaId == e.IdPessoa).ToList();
                            }

                            // Pegando o tomador
                            var tomador = Db.GetAsync<Pessoa>
                                (e => ConfigPessoa(e), Tomador.IdPessoa, nameof(Pessoa.IdPessoa)).
                                Await().FirstOrDefault();

                            // Pegando o CAE do tomador
                            var cae = tomador?.Cae;

                            // Forma de Liquidação
                            var formaLiquidicao = Db.GetAsync<FormaLiquidacaoPremio>
                                (model.Cotacao.FormaLiquidacaoPremioId, nameof(FormaLiquidacaoPremio.IdFormaLiquidacaoPremio)).Await();

                            switch (formaLiquidicao.CodFormaLiquidacaoPremio)
                            {
                                // Variavel
                                case "F000":

                                    valor = (model.Cotacao.CapitalSeguro * tomador.NumEmpregados);
                                    // Aplicando a taxa do cae
                                    valor = (bool)cae.IsTaxa ? valor * cae.TaxaComercial / 100 : valor + cae.TaxaComercial;
                                    break;

                                // Fixo
                                case "F001":

                                    // Variavel auxiliar onde estará todas pessoas seleccionada nos membros assegurados
                                    var pessoas = new List<(Pessoa, MembroAssegurado)>();

                                    // Percorrendo os membros assegurados
                                    model.Cotacao.MembroAssegurado.For(m =>
                                    {
                                        // Pegando a pessoa em que o Id equivale o membro assegurado e inserindo na variavle auxilar
                                        var p = Db.GetAsync<Pessoa>(e => ConfigPessoa(e)
                                        , m.PessoaId, nameof(Pessoa.IdPessoa)).Await().FirstOrDefault();

                                        if (p == null) return;

                                        pessoas.Add((p, m));
                                    });

                                    // Percorrenco as pessoas
                                    pessoas.ForEach(pessoa =>
                                    {
                                        // Pegando a profissaão da pessoa
                                        var pProfissao = pessoa.Item1.PessoaProfissao.FirstOrDefault(c => c.ProfissaoId == pessoa.Item2.ProfissaoId);

                                        // Verificando se a profissão foi encontrada
                                        if (pProfissao == null) return;

                                        var salario = pProfissao.SalarioLiquido + pProfissao.OutroRendimento;

                                        // Somando nos valores dos salarios * a taxa do risco da profissão
                                        valor += salario + salario * (pProfissao.Profissao.NivelRisco.Taxa / 100 ?? 0);
                                    });

                                    // Aplicando a taxa do cae
                                    valor = (bool)cae.IsTaxa ? valor * cae.TaxaComercial / 100 : valor + cae.TaxaComercial;

                                    // Criando a massa salarial liquida
                                    model.CapitalSeguro = (double)valor * 12;

                                    break;
                            }

                            // Percorrenco as coberturas seleccionadas na apolice
                            model.Cotacao.CoberturaSelecionada.For(x =>
                            {
                                // Somando nos valores para o retorno do preco base
                                valor += x.ValorPersonalizado ?? 0;
                            });

                            return valor == null ? 0 : (double)valor;
                        }
                    case "II1216":
                        {
                            _ = model.Cotacao?.ObjectoSegurado ?? throw new ArgumentNullException("Automóveis não foram fornecidos");
                            // Pegando as cilindragem
                            var cilinds = Db.GetAsync<CilindragemAutomovel>().Await().ToList();

                            // Percorrendo os automóveis a serem assegurados
                            model.Cotacao.ObjectoSegurado.For(x =>
                            {
                                // Pegando o automóvel.
                                var automovel = Db.GetAsync<Automovel>(x.AutomovelId, nameof(Automovel.IdAutomovel)).Await();

                                // Pegando a cilindragem.
                                automovel?.DapperInclude(e => e.CilindragemAutomovel);

                                // Verificando se a cilindragem foi encontrada
                                if (automovel?.CilindragemAutomovel != null)
                                {
                                    // Calculando o cambio e Adicionadono os dados nos movimento
                                    var cambio = CambioEMovimento(model, default, automovel.MoedaId, (double)automovel.CilindragemAutomovel.PremioUcf);

                                    // Somando nos valores para o retorno do preco base
                                    valor += cambio.ValorOutraMoeda;
                                }
                            });

                            // Percorrendo as coberturas seleccionadas na apolice
                            model.Cotacao.CoberturaSelecionada.For(x =>
                            {
                                // Somando os valores personalizados
                                valor += x.ValorPersonalizado;
                            });

                            return valor == null ? 0 : (double)valor;

                        }
                    default:
                        {
                            // Pegando o primeiro preco definido para o plano corrente
                            var preco = plano.PrecarioProduto.FirstOrDefault();

                            // Verificando se o precario foi encontrado
                            if (preco == null)
                                return 0;

                            PrecariosProduto.Add(preco);

                            // Pegando valor base
                            valor = preco.PrecoBase;

                            // Percorrendo os valores seleccinados no cobertura da apolice
                            model.Cotacao.CoberturaSelecionada.For(x =>
                            {
                                // Somando os valores
                                valor += x.ValorPersonalizado;
                            });

                            return valor == null ? 0 : (double)valor;
                        }
                }
            }
            // Preco Base
            return valor == null ? 0 : (double)valor;
        }

        public double PremioRisco(CalculoModel model, string pessoaId)
        {
            // Pegando a quantidade de sinistros
            int QtdSinistros = 0;
            
            // Pegando o valor total dos sinistros
            double ValorTotalSinistros = 0;

            //  Tomador ou Membro Assegurado.
            model.Pessoa = Pessoas.FirstOrDefault(p => p.IdPessoa == pessoaId);
            
            // TODO: Generalizar está estrutura pós tem de servir para simulação e cotação/proposta de seguro.
            // TODO: Temporário
            if(model.Cotacao != null) 
            {
                model.Pessoa.CotacaoTomador.For(ct =>
                {
                    var sinistros = ct.CotacaoDependente
                                    .OrderByDescending(y => y.NumOrdem)
                                    .FirstOrDefault().Apolice.Sinistro;
                    QtdSinistros += sinistros.Count;
                    ValorTotalSinistros += (double)sinistros.Sum(x => x.Indeminizacao);
                });
            }
            else
            {
                model.Pessoa.DapperInclude(e => e.SinistroParticipanteSinistro);
                QtdSinistros = (int)model.Pessoa.SinistroParticipanteSinistro?.Count;
                ValorTotalSinistros = (double)model.Pessoa.SinistroParticipanteSinistro?.Sum(x => x.Indeminizacao);    
            }

            if (model.Plano.LinhaProduto.CodLinhaProduto == "II1216")
            {
                /* UnidadesExpostasRisco */
                model.NumUnidadesContratadas += (model.Cotacao?.ObjectoSegurado.Count ?? 0);
                model.NumUnidadesContratadas = model.NumUnidadesContratadas != 0 ? model.NumUnidadesContratadas : 1;
                /* End UnidadesExpostasRisco */
            }
            else 
            {
                /* UnidadesExpostasRisco */
                model.NumUnidadesContratadas += (model.Cotacao?.MembroAssegurado.Count ?? (int)model.Simulacao.NumPessoas);
                model.NumUnidadesContratadas = model.NumUnidadesContratadas != 0 ? model.NumUnidadesContratadas : 1;
                /* End UnidadesExpostasRisco */
            }

            // Calculando a probabilidade de sinistro
            double probabilidadeSinistros = model.NumUnidadesContratadas != 0 ? (QtdSinistros / model.NumUnidadesContratadas) : 0;

            // Calculando o valor medio dos sinistros
            double valorMedioSinistros = QtdSinistros != 0 ? (ValorTotalSinistros / QtdSinistros) : 0;

            // Calculando o premio de risco com base a formula:
            // PremioRisco = (QuantidadeSinistro / UnidadesExpostasRisco) * (ValorTotalSinistro / QuantidadeSinistro) + PremioBase
            return ((probabilidadeSinistros * valorMedioSinistros) + model.PremioBase);
        }
        public double Agravamentos(CalculoModel model)
        {
            double res = 0;
            // Pegando os agravamentos
            var agravamentos =  Db.GetAsync<Agravamento>(e => e.DapperInclude(d => d.TipoAgravamento)).Await().ToList();

            // Percorrendo todos os planos seleccionados
            PlanosProduto.For(p =>
            {
                // Percorrendo os agravamentos do plano
                p.AgravamentoPlano.For(a =>
                {
                    // Pegando o agravamento
                    var ag = agravamentos.FirstOrDefault(ap => ap.IdAgravamento == a.AgravamentoId);

                    // Verificando o valor é valido
                    if (ag != null)
                    {
                        // Somando na variavel de retorno
                        var value = (bool)ag.IsTaxa ? (double)(model.PremioRisco * ag.TaxaAgravamento / 100) : (double)(model.PremioRisco + ag.TaxaAgravamento);
                        var mov = CambioEMovimento(model, ag.TipoOperacao, ag.MoedaId, value);
                        res += mov.ValorOutraMoeda ?? 0;

                        if(ag.TipoOperacao != null) 
                        {
                            ag.TipoOperacao.DapperInclude(o => o.Operacao);
                            foreach(var operacao in ag.TipoOperacao.Operacao) 
                            {
                                var movimentos = _movimentos.CreateMovFromTipoOperacao(new Movimento
                                {
                                    DescricaoMovimento = operacao.Designacao,
                                    IsPago = false,
                                    DataHoraMovimento = DateTime.UtcNow,
                                    DataValor = DateTime.UtcNow,
                                    Valor = res,
                                    CodMoeda = mov.CodOutraMoeda,
                                    CodOperacao = operacao.CodOperacao,
                                    Referencia = StringHelper.SetCode("MO_")
                                }, ag.TipoOperacao);

                                model.Transacoes.AddRange(movimentos);
                            }
                        }

                        model.AgravamentosDetalhe.Add(new CalculoDetalhe
                        {
                            Descricao = ag.CodAgravamento + " - " + ag.TipoAgravamento.Designacao,
                            Valor = mov.ValorOutraMoeda ?? 0
                        });
                    }

                });
            });

            // Calculando os agravamentos por idade
            //model.AgravamentosPorIdade = AgravamentosPorIdade(model);

            //Adicionar o agravamento por numero de pessoas
            return res;
        }
        public double AgravamentosPorIdade(CalculoModel model, bool analise)
        {
            double res = 0;

            // Pegando todas as pessoas
            pessoas ??= Db.GetAsync<Pessoa>().Await().ToList();
            // Pegando os agravamentos por pessoa
            var agravamentoPessoa = Db.GetAsync<AgravamentoPessoa>(e => e.DapperThenInclude(d => d.Agravamento)
                                      .DapperThenInclude(d => d.TipoAgravamento)).Await().ToList();

            // Função auxiliar para executar o calculo com base uma pessoa
            void Exec(string PessoaId)
            {
                // Pegando a pessoa que foi asseguradaa
                var pessoa = pessoas.FirstOrDefault(p => p.IdPessoa == PessoaId);
                // Verificando se ela tem os dados validos
                if (pessoa != null && pessoa.DataNascimento != null)
                {
                    // Calculando a sua idade
                    var idade = new DateTime(model.Cotacao.DataExpiracao.Value.Subtract((DateTime)pessoa.DataNascimento).Ticks).Year;
                    // Pegando e percorrendo os agravamentos com base a sua idade
                    var filtro = agravamentoPessoa.OrderBy(o => o.IdadeMin).Where(o => o.IdadeMin <= idade && idade <= o.IdadeMax);

                    filtro.For(d =>
                    {
                        // Verificando se objecto é valido
                        if (d.Agravamento != null)
                        {
                            var ag = d.Agravamento;
                            // Somando na variavel de retorno
                            var value = (bool)d.IsTaxa
                            ? (double)(model.PremioRisco * d.Percentagem / 100)
                            : (double)(model.PremioRisco + d.Percentagem);
                            var mov = CambioEMovimento(model, ag.TipoOperacao, ag.MoedaId, value);
                            res += mov.ValorOutraMoeda ?? 0;

                            if (ag.TipoOperacao != null)
                            {
                                ag.TipoOperacao.DapperInclude(o => o.Operacao);
                                foreach (var operacao in ag.TipoOperacao.Operacao)
                                {
                                    var movimentos = _movimentos.CreateMovFromTipoOperacao(new Movimento
                                    {
                                        DescricaoMovimento = operacao.Designacao,
                                        IsPago = false,
                                        DataHoraMovimento = DateTime.UtcNow,
                                        DataValor = DateTime.UtcNow,
                                        Valor = res,
                                        CodMoeda = mov.CodOutraMoeda,
                                        CodOperacao = operacao.CodOperacao,
                                        Referencia = StringHelper.SetCode("MO_")
                                    }, ag.TipoOperacao);

                                    model.Transacoes.AddRange(movimentos);
                                }
                            }

                            model.AgravamentosDetalhe.Add(new CalculoDetalhe
                            {
                                Descricao = ag.CodAgravamento + " - " + ag.TipoAgravamento.Designacao,
                                Valor = mov.ValorOutraMoeda ?? 0
                            });
                        }

                    });
                }
            }
            
            // TODO: Reanalisar pós deve ser generico para simulação ou cotacao/proposta.
            if (analise) 
            {
                Exec(model.Cotacao?.TomadorId ?? model.Simulacao?.PessoaId);
            }
            else 
            {
                // Aplicado apenas para os casos de cotação/proposta e não simulação.
                if(model.Cotacao != null)
                    // Percorrendo os membros assegurados
                    model.Cotacao.MembroAssegurado.For(x =>
                    {
                        Exec(x.PessoaId);
                    });
            }

            return res;
        }
        public double PremioSimples(CalculoModel model)
        {
            // Calculando o Premio Simples com base a formula:
            // Premio Simples = Premio de Risco + Agravamentos
            return model.PremioRisco + model.Agravamentos;
        }
        public double SinistroEsperado(CalculoModel model)
        {
            // TODO: Temporário devido a questão da simulação.
            if (model.Cotacao == null)
                return 0.0;
            // Calculando o sinistro esperado com base a formula:
            // Nota: CapitalSeguro == PremioBase
            // SinistroEsperado = CapitalSeguro / NumeroUnidadesContratadas
            // Retornando o valor do sinistro esperado
            model.Cotacao.CapitalSeguro = model.Cotacao.CapitalSeguro ?? 0;
            return (float)model.Cotacao.CapitalSeguro / model.NumUnidadesContratadas;
        }
        public double PremioComercial(CalculoModel model)
        {
            // Calculo da margem comercial
            double sinistralidadeEsperada = model.SinistroEsperado / model.NumUnidadesContratadas;
            double valorMargemComercial = sinistralidadeEsperada;
            double valorMargemSeguranca = 0;

            PlanosProduto.For(p =>
            {
                // PremioSimples = PremioRisco + (PremioRisco * MargemSeguranca)
                var margemSeguranca = p.MargemVendaProduto.FirstOrDefault(z => z.TipoMargem.CodTipoMargem == "M002");
                if (margemSeguranca != null)
                {
                    var valor = (bool)margemSeguranca.IsTaxa ? (model.PremioSimples * margemSeguranca.Taxa / 100) : margemSeguranca.Taxa;
                    var cambio = CambioEMovimento(model, margemSeguranca.TipoOperacao, margemSeguranca.MoedaId, valor);
                    valorMargemSeguranca += cambio.ValorOutraMoeda ?? 0;
                }

                var margemCommercial = p.MargemVendaProduto.FirstOrDefault(z => z.TipoMargem.CodTipoMargem == "M001");
                if (margemCommercial != null)
                {
                    // Formula da MargemComercial = sinistralidadeEsperada + sinistralidadeEsperada * taxa

                    // Adicionando a taxa do margem comercial
                    var valorCalculadoComBaseATaxa = (bool)margemCommercial.IsTaxa ? (sinistralidadeEsperada * margemCommercial.Taxa / 100) : (sinistralidadeEsperada + margemCommercial.Taxa);

                    // Adicionando o valor calculado com base a taxa ao valor principal
                    var valorCalculado = sinistralidadeEsperada + valorCalculadoComBaseATaxa;

                    // Calculando o valor com base o cambio corrente 
                    var cambio = CambioEMovimento(model, margemSeguranca.TipoOperacao, margemSeguranca.MoedaId, valorCalculado);

                    // Adicionando o valor na variavel principal
                    valorMargemComercial += cambio.ValorOutraMoeda ?? 0;
                }

            });

            // Variaveis auxiliares
            valorMargemComercial += model.Comissoes
                        + model.Despesas
                        + model.EncargosAdministrativos
                        + model.Agravamentos
                        - model.Descontos
                        - model.Ofertas
                        + model.AgravamentosPorIdade
                        - model.DescontosPorIdade;
            // + custoApolice;

            // Calculando o Premio comercial com base a formula:
            // PremioComercial = PremioSimples + MargemSeguranca + MargemComercial
            // TODO: return model.PremioSimples + valorMargemSeguranca + valorMargemComercial;
            // 4- Premio Comercial = Premio Simples + Encargo Administrativo + Fraccionamento
            var fraccionamento = Db.GetAsync<Fraccionamento>(model.Cotacao.FraccionamentoId, nameof(Fraccionamento.IdFraccionamento)).Await() ?? 
                                new Fraccionamento { Taxa = 0.0 };
            return model.PremioSimples + model.EncargosAdministrativos + ((double)model.EncargosAdministrativos * (double)fraccionamento.Taxa);
        }
        public double PremioBruto(CalculoModel model)
        {
            // Calculando o premio bruto
            return model.PremioComercial + model.Impostos;// + custoApolice;
        }
        public double PremioCobrado(CalculoModel model)
        {
            // Calculando o PremioCobrado com base  formula:
            // PremioCobrado = (PremioBruto * NumUnidadesContratadas) * Provisões
            var res = model.PremioBruto * model.NumUnidadesContratadas;
            var reservas = Db.GetAsync<ReservasTecnicas>().Await();

            double premioButo = 0;

            // Percorrendo o plano
            PlanosProduto.For(p =>
            {
                var linhaId = p.LinhaProdutoId;
                // Pegando a reserva tecnica
                var reservasTecnicas = reservas.FirstOrDefault(x => x.LinhaProdutoId == linhaId);
                // Verificando se foi encontrada
                if (reservasTecnicas != null)
                {
                    // Adicionado o valor da provisao
                    var valor = reservasTecnicas?.IsTaxa == true ? res * (double)reservasTecnicas?.ValorMin / 100 : (double)reservasTecnicas?.ValorMin;
                    var cambio = CambioEMovimento(model, reservasTecnicas.TipoOperacao, reservasTecnicas.MoedaId, valor);
                    res += cambio.ValorOutraMoeda ?? 0;
                }
                premioButo = res + model.Impostos;


            });

            // Seleccionando o fraccionamento
            // TODO: Temporário que falta adicionar o fraccionamento para o caso da simulação
            var fraccionamento = Db.GetAsync<Fraccionamento>(model.Cotacao?.FraccionamentoId, nameof(Fraccionamento.IdFraccionamento)).Await();

            if (fraccionamento == null)
                return premioButo;

            var valorFrac = (premioButo * fraccionamento.Taxa / 100 ?? 0);
            var _cambio_ = CambioEMovimento(model, fraccionamento.TipoOperacao, model.Cotacao?.MoedaId, valorFrac);

            return premioButo + _cambio_?.ValorOutraMoeda ?? 0;
        }
        public double Despesas(CalculoModel model)
        {
            double res = 0;
            // Pegando as despesas do plano
            var despesasPlano = Db.GetAsync<DespesaPlano>(e =>
            {
                e.DapperThenInclude(d => d.Despesa)
                 .DapperThenInclude(d => d.TipoOperacao);
                e.Despesa.TipoOperacao.DapperInclude(d => d.SubContaCredito);
                e.Despesa.TipoOperacao.DapperInclude(d => d.SubContaDebito);
            }).Await().ToList();

            // Percorrendo os planos seleccionados
            PlanosProduto.For(x =>
            {
                // Percorrendo a lista de despesas
                despesasPlano.Where(l => l.PlanoProdutoId == x.IdPlano)
                .For(o =>
                {
                    var obj = o.Despesa;
                    // Calculando os valores
                    double valor = obj.IsTaxa ? (double)(model.PremioComercial * obj.Taxa / 100) : (double)(model.PremioComercial + obj.ValorMin);
                    // Calculando o cambio e adicionando dados nos movimentos
                    var cambio = CambioEMovimento(model, obj.TipoOperacao, obj.MoedaId, valor);
                    // Somando so valores
                    res += cambio.ValorOutraMoeda ?? 0;

                    if (obj.TipoOperacao != null)
                    {
                        obj.TipoOperacao.DapperInclude(o => o.Operacao);
                        foreach (var operacao in obj.TipoOperacao.Operacao)
                        {
                            var movimentos = _movimentos.CreateMovFromTipoOperacao(new Movimento
                            {
                                DescricaoMovimento = operacao.Designacao,
                                IsPago = false,
                                DataHoraMovimento = DateTime.UtcNow,
                                DataValor = DateTime.UtcNow,
                                Valor = res,
                                CodMoeda = cambio.CodOutraMoeda,
                                CodOperacao = operacao.CodOperacao,
                                Referencia = StringHelper.SetCode("MO_")
                            }, obj.TipoOperacao);

                            model.Transacoes.AddRange(movimentos);
                        }
                    }

                    model.DespesasDetalhe.Add(new CalculoDetalhe
                    {
                        Descricao = obj.Designacao,
                        Valor = cambio.ValorOutraMoeda ?? 0
                    });
                });

            });

            return res;
        }
        public double Descontos(CalculoModel model)
        {
            double res = 0;
            // Pegando os descontos
            var descontosPlano = Db.GetAsync<DescontoPlano>(e =>
            {
                e.DapperThenInclude(d => d.Desconto);
                e.Desconto.TipoOperacao.DapperInclude(d => d.SubContaCredito);
                e.Desconto.TipoOperacao.DapperInclude(d => d.SubContaDebito);
            }).Await().ToList();
            PlanosProduto.For(p =>
            {
                // Percorrendo a lista de descontos
                descontosPlano.Where(l => l.PlanoProdutoId == p.IdPlano).For(o =>
                {
                    var obj = o.Desconto;
                    // Calculando o valor
                    var valor = (bool)obj.IsTaxa ? (double)(model.PremioComercial * obj.ValorMinDesconto / 100) : (double)(model.PremioComercial * obj.ValorMinDesconto);
                    // Calculando o valor  do cambio e adicionando os dados no movimento
                    var cambio = CambioEMovimento(model, obj.TipoOperacao, obj.MoedaId, valor);
                    // Somando os valores
                    res += cambio.ValorOutraMoeda ?? 0;

                    obj.DapperInclude(t => t.TipoOperacao);

                    if (obj.TipoOperacao != null)
                    {
                        obj.TipoOperacao.DapperInclude(o => o.Operacao);
                        foreach (var operacao in obj.TipoOperacao.Operacao)
                        {
                            var movimentos = _movimentos.CreateMovFromTipoOperacao(new Movimento
                            {
                                DescricaoMovimento = operacao.Designacao,
                                IsPago = false,
                                DataHoraMovimento = DateTime.UtcNow,
                                DataValor = DateTime.UtcNow,
                                Valor = res,
                                CodMoeda = cambio.CodOutraMoeda,
                                CodOperacao = operacao.CodOperacao,
                                Referencia = StringHelper.SetCode("MO_")
                            }, obj.TipoOperacao);

                            model.Transacoes.AddRange(movimentos);
                        }
                    }

                    model.DespesasDetalhe.Add(new CalculoDetalhe
                    {
                        Descricao = "Desconto - " + obj.CodDesconto,
                        Valor = cambio.ValorOutraMoeda ?? 0
                    });
                });
            });

            // Calcculando os descontos por idade
            //model.DescontosPorIdade = DescontosPorIdade(model);

            return res;
        }
        public double DescontosPorIdade(CalculoModel model, bool analise)
        {
            double res = 0;
            // TODO: Temporário devido ao caso da simulação
            if (model.Cotacao == null)
                return 0.0;
            // Pegando as pessoas
            pessoas ??= Db.GetAsync<Pessoa>().Await().ToList();
            // Pegando os descontos por pessoa
            var descontoPessoa =  Db.GetAsync<DescontoPessoa>(e =>
            {
                e.DapperThenInclude(d => d.Desconto);
                e.Desconto.TipoOperacao.DapperInclude(d => d.SubContaCredito);
                e.Desconto.TipoOperacao.DapperInclude(d => d.SubContaDebito);
            }).Await().ToList();

            // Função auxiliar para executar o calculo com base uma pessoa
            void Exec(string PessoaId)
            {
                // Pegando a pessoa assegurada
                var pessoa = pessoas.FirstOrDefault(p => p.IdPessoa == PessoaId);
                // Verificando se ela tem informações válidas
                if (pessoa != null && pessoa.DataNascimento != null)
                {
                    // Calculando a sua idade
                    var idade = new DateTime(model.Cotacao.DataExpiracao.Value.Subtract((DateTime)pessoa.DataNascimento).Ticks).Year;
                    // Percorrendo os descontos por pessoa
                    var filtro = descontoPessoa.OrderBy(o => o.IdadeMin).Where(o => o.IdadeMin <= idade && idade <= o.IdadeMax);

                    filtro.For(d =>
                    {
                        var obj = d.Desconto;

                        if (obj.IsTaxa != null)
                        {
                            // Calculando o valor
                            var valor = (bool)obj.IsTaxa
                            ? (double)(model.PremioComercial * obj.ValorMinDesconto / 100)
                            : (double)(model.PremioComercial * obj.ValorMinDesconto);
                            // Calculando o valor do cambio e adicionando os dados no movimento
                            var cambio = CambioEMovimento(model, obj.TipoOperacao, obj.MoedaId, valor);
                            // Somando os valores
                            res += cambio.ValorOutraMoeda ?? 0;

                            obj.DapperInclude(t => t.TipoOperacao);
                            if (obj.TipoOperacao != null)
                            {
                                obj.TipoOperacao.DapperInclude(o => o.Operacao);
                                foreach (var operacao in obj.TipoOperacao.Operacao)
                                {
                                    var movimentos = _movimentos.CreateMovFromTipoOperacao(new Movimento
                                    {
                                        DescricaoMovimento = operacao.Designacao,
                                        IsPago = false,
                                        DataHoraMovimento = DateTime.UtcNow,
                                        DataValor = DateTime.UtcNow,
                                        Valor = res,
                                        CodMoeda = cambio.CodOutraMoeda,
                                        CodOperacao = operacao.CodOperacao,
                                        Referencia = StringHelper.SetCode("MO_")
                                    }, obj.TipoOperacao);

                                    model.Transacoes.AddRange(movimentos);
                                }
                            }

                            model.DespesasDetalhe.Add(new CalculoDetalhe
                            {
                                Descricao = "Desconto - " + obj.CodDesconto,
                                Valor = cambio.ValorOutraMoeda ?? 0
                            });
                        }
                    });
                }

            }

            if (analise)
                // Percorrendo os membros assegurados
                model.Cotacao.MembroAssegurado.For(x => { Exec(x.PessoaId); });
            else
                Exec(model.Cotacao.TomadorId);

            return res;
        }
        public double Ofertas(CalculoModel model)
        {
            double res = 0;
            // Pegandos as ofertas dos planos
            var ofertasPlano = Db.GetAsync<OfertaPlano>(e =>
            {
                e.DapperThenInclude(d => d.HistoricoOferta);
                e.HistoricoOferta.TipoOperacao.DapperInclude(d => d.SubContaCredito);
                e.HistoricoOferta.TipoOperacao.DapperInclude(d => d.SubContaDebito);
            }).Await().ToList();

            // Percorrendo os planos
            PlanosProduto.For(x =>
            {
                // Percorrendo as ofertas do plano
                ofertasPlano.Where(l => l.PlanoProdutoId == x.IdPlano).
                For(o =>
                {
                    var obj = o.HistoricoOferta;
                    // Calculando o valor
                    double valor = (bool)obj.IsTaxa ? (double)(model.PremioComercial * obj.ValorMinOferta / 100) : (double)(model.PremioComercial + obj.ValorMinOferta);
                    // Calculando o cambio e adicionando od dados no movimento
                    var cambio = CambioEMovimento(model, obj.TipoOperacao, obj.MoedaId, valor);
                    // Somando os valores
                    res += cambio.ValorOutraMoeda ?? 0;

                    if (obj.TipoOperacao != null)
                    {
                        obj.TipoOperacao.DapperInclude(o => o.Operacao);
                        foreach (var operacao in obj.TipoOperacao.Operacao)
                        {
                            var movimentos = _movimentos.CreateMovFromTipoOperacao(new Movimento
                            {
                                DescricaoMovimento = operacao.Designacao,
                                IsPago = false,
                                DataHoraMovimento = DateTime.UtcNow,
                                DataValor = DateTime.UtcNow,
                                Valor = res,
                                CodMoeda = cambio.CodOutraMoeda,
                                CodOperacao = operacao.CodOperacao,
                                Referencia = StringHelper.SetCode("MO_")
                            }, obj.TipoOperacao);

                            model.Transacoes.AddRange(movimentos);
                        }
                    }

                    model.OfertasDetalhe.Add(new CalculoDetalhe
                    {
                        Descricao = "Oferta - " + obj.CodOferta,
                        Valor = cambio.ValorOutraMoeda ?? 0
                    });
                });
            });

            return res;
        }
        public double EncargoAdmintrativo(CalculoModel model)
        {
            double res = 0;
            // Pegando os encargos
            var encargosPlano = Db.GetAsync<EncargoPlano>(e =>
            {
                e.DapperThenInclude(d => d.Encargo);
                e.Encargo.TipoOperacao.DapperInclude(d => d.SubContaCredito);
                e.Encargo.TipoOperacao.DapperInclude(d => d.SubContaDebito);
            }).Await().ToList();

            // Percorrendo os planos
            PlanosProduto.For(x =>
            {
                // Percorrendo os encargos do plano
                encargosPlano.Where(c => c.PlanoProdutoId == x.IdPlano).For(c =>
                {
                    var obj = c.Encargo;

                    // Calculando os valor do encargo
                    double valor = (double)(model.PremioComercial * obj.TaxaEncargo / 100);
                    // Calculando o cambio e adicionando dados no movimento
                    var cambio = CambioEMovimento(model, obj.TipoOperacao, obj.MoedaId, valor);
                    // Somando os valores
                    res += cambio.ValorOutraMoeda ?? 0;

                    if (obj.TipoOperacao != null)
                    {
                        obj.TipoOperacao.DapperInclude(o => o.Operacao);
                        foreach (var operacao in obj.TipoOperacao.Operacao)
                        {
                            var movimentos = _movimentos.CreateMovFromTipoOperacao(new Movimento
                            {
                                DescricaoMovimento = operacao.Designacao,
                                IsPago = false,
                                DataHoraMovimento = DateTime.UtcNow,
                                DataValor = DateTime.UtcNow,
                                Valor = res,
                                CodMoeda = cambio.CodOutraMoeda,
                                CodOperacao = operacao.CodOperacao,
                                Referencia = StringHelper.SetCode("MO_")
                            }, obj.TipoOperacao);

                            model.Transacoes.AddRange(movimentos);
                        }
                    }

                    model.EncargosAdministrativosDetalhe.Add(new CalculoDetalhe
                    {
                        Descricao = obj.Designacao,
                        Valor = cambio.ValorOutraMoeda ?? 0
                    });
                });
            });

            // TODO: Eventualmente voltar return res - model.Descontos - model.Ofertas + model.Agravamentos;
            var encargo = Db.GetAsync<Encargos>("E027", nameof(Encargos.CodEncargo)).Await() ?? new Encargos { TaxaEncargo = 0.0 };
            return model.PremioSimples * (double)encargo.TaxaEncargo / 100.00;
        }

        public double EncargosPlano(CalculoModel model)
        {
            double res = 0;
            // Pegando os encargos
            var encargosPlano = Db.GetAsync<EncargoPlano>(e =>
            {
                e.DapperThenInclude(d => d.Encargo);
                e.Encargo.TipoOperacao.DapperInclude(d => d.SubContaCredito);
                e.Encargo.TipoOperacao.DapperInclude(d => d.SubContaDebito);
            }).Await().ToList();

            // Percorrendo os planos
            PlanosProduto.For(x =>
            {
                // Percorrendo os encargos do plano
                encargosPlano.Where(c => c.PlanoProdutoId == x.IdPlano).For(c =>
                {
                    var obj = c.Encargo;

                    // Calculando os valor do encargo
                    double valor = (double)(model.PremioComercial * obj.TaxaEncargo / 100);
                    // Calculando o cambio e adicionando dados no movimento
                    var cambio = CambioEMovimento(model, obj.TipoOperacao, obj.MoedaId, valor);
                    // Somando os valores
                    res += cambio.ValorOutraMoeda ?? 0;

                    if (obj.TipoOperacao != null)
                    {
                        obj.TipoOperacao.DapperInclude(o => o.Operacao);
                        foreach (var operacao in obj.TipoOperacao.Operacao)
                        {
                            var movimentos = _movimentos.CreateMovFromTipoOperacao(new Movimento
                            {
                                DescricaoMovimento = operacao.Designacao,
                                IsPago = false,
                                DataHoraMovimento = DateTime.UtcNow,
                                DataValor = DateTime.UtcNow,
                                Valor = res,
                                CodMoeda = cambio.CodOutraMoeda,
                                CodOperacao = operacao.CodOperacao,
                                Referencia = StringHelper.SetCode("MO_")
                            }, obj.TipoOperacao);

                            model.Transacoes.AddRange(movimentos);
                        }
                    }

                    model.EncargosDetalhe.Add(new CalculoDetalhe
                    {
                        Descricao = obj.Designacao,
                        Valor = cambio.ValorOutraMoeda ?? 0
                    });
                });
            });

            return res;
        }

        public double Impostos(CalculoModel model)
        {
            double res = 0;
            // Pegando os dados do impostos relacionado a linha
            var impostosLinha =  Db.GetAsync<ImpostoLinha>(e =>
            {
                e.DapperInclude(d => d.Imposto);
                e.Imposto.DapperInclude(d => d.TipoImposto);
                e.Imposto.TipoOperacao.DapperInclude(d => d.SubContaCredito);
                e.Imposto.TipoOperacao.DapperInclude(d => d.SubContaDebito);
            }).Await().ToList();

            // Pegando os impostos do preçario
            var listaIPrecarios = Db.GetAsync<ImpostoPrecario>(e =>
            {
                e.DapperInclude(d => d.Imposto);
                e.Imposto.DapperInclude(d => d.TipoImposto);
                e.Imposto.TipoOperacao.DapperInclude(d => d.SubContaCredito);
                e.Imposto.TipoOperacao.DapperInclude(d => d.SubContaDebito);
            }).Await().ToList();

            // Percorrendno os planos para que possa ser incluido os impostos
            PlanosProduto.For(p =>
            {
                // Percorrendos os impostos relacionando a um determinado plano
                impostosLinha.Where(x => x.LinhaProdutoId == p.LinhaProdutoId).For(x =>
                {
                    var obj = x.Imposto;
                    // Calculando o valor basico
                    var valor = (bool)obj.IsTaxa ? (double)(model.PremioComercial * obj.TaxaImposto / 100) : model.PremioComercial + (double)obj.TaxaImposto;
                    // Convertendo e criando um movimento
                    var cambio = CambioEMovimento(model, obj.TipoOperacao, obj.MoedaId, valor);
                    // Somando no valor de retorno
                    res += cambio.ValorOutraMoeda ?? 0;

                    if (obj.TipoOperacao != null)
                    {
                        obj.TipoOperacao.DapperInclude(o => o.Operacao);
                        foreach (var operacao in obj.TipoOperacao.Operacao)
                        {
                            var movimentos = _movimentos.CreateMovFromTipoOperacao(new Movimento
                            {
                                DescricaoMovimento = operacao.Designacao,
                                IsPago = false,
                                DataHoraMovimento = DateTime.UtcNow,
                                DataValor = DateTime.UtcNow,
                                Valor = res,
                                CodMoeda = cambio.CodOutraMoeda,
                                CodOperacao = operacao.CodOperacao,
                                Referencia = StringHelper.SetCode("MO_")
                            }, obj.TipoOperacao);

                            model.Transacoes.AddRange(movimentos);
                        }
                    }

                    // Adicionando as descrições
                    model.ImpostosDetalhe.Add(new CalculoDetalhe
                    {
                        Descricao = "Impostos - " + obj.TipoImposto.Designacao,
                        Valor = cambio.ValorOutraMoeda ?? 0
                    });
                });
            });

            // Percorrendo os precarios
            PrecariosProduto.For(p =>
            {
                // Percorrendo os impostos relacionados a precario
                listaIPrecarios.Where(lp => lp.PrecarioProdutoId == p.IdPrecarioProduto).
                For(lp =>
                {
                    var obj = lp.Imposto;
                    // Calculando o valor basico
                    var valor = (bool)obj.IsTaxa ? (double)(model.PremioComercial * obj.TaxaImposto / 100) : model.PremioComercial + (double)obj.TaxaImposto;
                    // Convertendo e criando um movimento
                    var cambio = CambioEMovimento(model, obj.TipoOperacao, obj.MoedaId, valor);
                    // Somando no valor de retorno
                    res += cambio.ValorOutraMoeda ?? 0;
                    // Adicionando as descrições
                    model.ImpostosDetalhe.Add(new CalculoDetalhe
                    {
                        Descricao = "Impostos - " + obj.TipoImposto.Designacao,
                        Valor = cambio.ValorOutraMoeda ?? 0
                    });
                });
            });

            return res;
        }
        public List<FraccionamentoModel> PremioFraccionado(CalculoModel model)
        {
            // Efecutuando o calculo final
            var list = new List<FraccionamentoModel>();
            // Buscar pela valor da despesa da ARSEG.
            var despesa = Db.GetAsync<Despesa>("D000", nameof(Despesa.CodDespesa)).Await() ?? new Despesa { Taxa=  0.0 };
            // Buscar pela taxa de imposto do IVA.
            var imposto = Db.GetAsync<Imposto>("I026", nameof(Imposto.CodImposto)).Await() ?? new Imposto { TaxaImposto =  0.0 };

            PlanosProduto.For(p =>
            {

                p.FraccionamentoPlano.For(f =>
                {
                    var fraccionamento = f.Fraccionamento;

                    var obj = new FraccionamentoModel
                    {
                        Taxa = (double)fraccionamento.Taxa,
                        Fraccionamento = fraccionamento.Designacao,
                        FraccionamentoId = fraccionamento.IdFraccionamento,

                        Ofertas = model.Ofertas / (double)fraccionamento.DivisorPremio,
                        Despesas = model.Despesas / (double)fraccionamento.DivisorPremio,
                        Impostos = model.Impostos / (double)fraccionamento.DivisorPremio,
                        Comissoes = model.Comissoes / (double)fraccionamento.DivisorPremio,
                        Descontos = model.Descontos / (double)fraccionamento.DivisorPremio,
                        Agravamentos = model.Agravamentos / (double)fraccionamento.DivisorPremio,
                        EncargosAdminstrativos = model.EncargosAdministrativos / (double)fraccionamento.DivisorPremio,
                        Encargos = model.Encargos / (double)fraccionamento.DivisorPremio,
                        JurosFraccionamento = (model.JurosFraccionamento / (double)fraccionamento.DivisorPremio)/100,
                        PremioBase = model.PremioBase / (double)fraccionamento.DivisorPremio,
                        PremioRisco = model.PremioRisco / (double)fraccionamento.DivisorPremio,
                        PremioSimples = model.PremioSimples / (double)fraccionamento.DivisorPremio,
                        PremioComercial = model.PremioComercial / (double)fraccionamento.DivisorPremio,
                        PremioBruto = model.PremioBruto / (double)fraccionamento.DivisorPremio,
                        PremioCobrado = model.PremioCobrado / (double)fraccionamento.DivisorPremio,
                        Arseg = (model.PremioComercial * (double)despesa.Taxa / 100.00) / (double)fraccionamento.DivisorPremio,
                        Iva = (model.PremioComercial * (double)imposto.TaxaImposto / 100.00) / (double)fraccionamento.DivisorPremio
                    };

                    var fModel = list.FirstOrDefault(l => l.FraccionamentoId == fraccionamento.IdFraccionamento);

                    if (fModel != null)
                    {
                        obj.EncargosAdminstrativos += fModel.EncargosAdminstrativos;
                        obj.Impostos += fModel.Impostos;
                        obj.Descontos += fModel.Descontos;
                        obj.Agravamentos += fModel.Agravamentos;
                        obj.Comissoes += fModel.Comissoes;
                        obj.Despesas += fModel.Despesas;
                        obj.Ofertas += fModel.Ofertas;
                        obj.PremioBase += fModel.PremioBase;
                        obj.PremioRisco += fModel.PremioRisco;
                        obj.PremioSimples += fModel.PremioSimples;
                        obj.PremioComercial += fModel.PremioComercial;
                        obj.PremioBruto += fModel.PremioBruto;
                        obj.PremioCobrado += fModel.PremioCobrado;

                        list.Remove(fModel);
                    }

                    list.Add(obj);

                });

            });

            return list;
        }
        public void Comissoes(CalculoModel model)
        {
            // Pegando todas as pessoas
            var pessoas = Db.GetAsync<Pessoa>(e => e.DapperInclude(d => d.Comissionamento)).Await().ToList();
            // Pegando o produtor seleccionado
            var produtor = pessoas.FirstOrDefault(x => x.IdPessoa == model.Cotacao.ProdutorId);

            // Pegando o mediador seleccionado
            var mediador = pessoas.FirstOrDefault(x => x.IdPessoa == model.Cotacao.CobradorId);

            // Função auxiliar para adicionar a comissao
            void AddComissao(Pessoa pessoa)
            {
                // Verificando se o dado passado é valido
                if (pessoa == null)
                    return;

                // Percorrendo os comissionamentos da pessoa
                pessoa.Comissionamento.OrderBy(x => x.CapitalMin).For(c =>
                {
                    // Verificando o intervalo do capital
                    if (c.CapitalMin <= model.PremioCobrado && model.PremioCobrado <= c.CapitalMax)
                    {
                        // Adicionando dados na tabela de cotação
                        model.Apolice.Comissao.Add(new Comissao
                        {
                            ComissionamentoId = c.IdComissionamento,
                            PessoaId = c.PessoaId,
                            Valor = model.PremioCobrado * c.TaxaComissionamento / 100,
                        });
                    }
                });
            }

            AddComissao(produtor);
            AddComissao(mediador);

            // Resseguros
            PlanosProduto.For(x => { });

            // Cosseguros
            PlanosProduto.For(x => { });

            // TODO: Comissionamento
        }

        ///<sumary>
        /// Função auxiliar para efectuar a converção dos valores e inserção de dados na tabela de movimentos
        /// <param name="model">O modelo onde contem os valores para que inserção dos movimentos sejam feitas</param>
        /// <param name="moeda">A moeda associada ao movimento e a qual será utilizada para a converção dos valores</param>
        /// <param name="operacao">A operação em que o movimento será criado</param>
        /// <param name="valor">O valor que será convertido e posto nos movimentos</param>
        ///</sumary>
        public CambioModel CambioEMovimento(CalculoModel model, TipoOperacao operacao, string moeda, double valor)
        {
            var cambioModel = new CambioModel
            {
                MoedaId = moeda ?? Moedas.FirstOrDefault(x => x.Simbolo == "AOA").IdMoeda,
                OutraMoedaId = model.Cotacao?.MoedaId ?? model.Simulacao.MoedaId,
                Valor = valor
            };
            // Calculando o cambio
            var cambio = Conversao.Calcular(cambioModel);

            // TODO: Adicionar a inserção de movimentos na geração de uma apolice
            return cambio;
        }

        #endregion

        #region Calculo de Cancelamento
        /// <summary>
        /// Cálculo do valor da apólice após cancelamento.
        /// </summary>
        /// <param name="model">Model contendo informações relevantes ao cancelamento.</param>
        public void CancelamentoApolice(CalculoModel model)
        {
            var id = model.Cotacao.IdCotacao;
            // Pegando a cotacao referente a o id passado
            var cotacao = Db.GetAsync<Cotacao>(model.Cotacao.IdCotacao).Await();

            cotacao.DapperInclude(d => d.CotacaoDependente);
            cotacao.CotacaoDependente.For(cd => {
                cd.DapperInclude(a => a.Apolice);
            });
        }
        #endregion
    }
}