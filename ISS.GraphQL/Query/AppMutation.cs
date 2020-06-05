using FileSystem.FileSystem;
using GraphQL;
using GraphQL.Types;
using ISS.Application;
using ISS.Application.Dto;
using ISS.Application.Helpers;
using ISS.Application.LinqToDb;
using ISS.Application.Models;
using ISS.Application.Movimentos;
using ISS.Application.ViewModels;
using ISS.GraphQL.Calculo;
using ISS.GraphQL.ISRabbitMQ;
using ISS.GraphQL.ISRabbitMQ.Models;
using ISS.GraphQL.Repository;
using ISS.GraphQL.ServiceExtentions;
using ISS.GraphQL.Type;
using LinqToDB;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ISS.GraphQL.Query
{
    /// <summary>
    /// Abstração da implementação de Mutations no GraphQL
    /// </summary>
    public class AppMutation : AppMutationBase
    {
        public AppMutation(IRepository repository) : base(repository)
        {
            // Lista de end point the devem ser ignorados nomomento da criação das queries
            var ignoreFields = new List<System.Type> {
                typeof(LoginType),
                typeof(UsuarioType),
                typeof(CotacaoType),
                typeof(ApoliceType),
                typeof(PagamentoDtoType),
                typeof(PlanoObjectivoComercialType),
                typeof(CanalType),
                typeof(PessoaType),
                typeof(PessoaSingularType),
                typeof(PessoaColectivaType)
            };

            #region Base Fields

            // Adicionanado as classes a serem ignoradas que são partilhadas
            ignoreFields.AddRange(ignoreTypesShared);

            //// Percorrendo os tipos do graphql
            foreach (var item in GetGraphTypesAndInputTypes())
            {
                var type = item.Item1;
                var inputType = item.Item2;

                // Verificando o nome do tipo
                if (ignoreFields.Any(x => x == type))
                    // Pulando
                    continue;
                if (type.BaseType.Name.EndsWith("Type") && !type.BaseType.Name.EndsWith("GraphType"))
                    typeof(AppMutation).GetMethod(nameof(AppMutation.FieldGenericAsync))
                    .MakeGenericMethod(type, inputType, type.BaseType.BaseType.GenericTypeArguments[0])
                    .Invoke(this, null);
                else
                    // Instanciando
                    typeof(AppMutation).GetMethod(nameof(AppMutation.FieldGenericAsync))
                        .MakeGenericMethod(type, inputType, type.BaseType.GenericTypeArguments[0])
                        .Invoke(this, null);
            }
            #endregion

            FieldNormalAsync<CanalType, CanalInputType, Canal>();

            // --------------------- GraphQL types personalizadas ---------------------
            FieldAsync<UsuarioType, UsuarioInputType, Usuario>(param: new Param<Usuario>
            {
                Add = async (usuario, context) =>
                {
                    return await repository.ExecuteAsync(async provider =>
                    {
                        var userRepo = provider.GetRequiredService<IUsuarioRepository>();
                        return await userRepo.AddUsuarioAsync(usuario);
                    });
                }
            });

            Field<ListGraphType<StringGraphType>>(
                 "upload", arguments: new QueryArguments(
                 new QueryArgument<FileDtoInputType> { Name = "obj" },
                 new QueryArgument<StringGraphType> { Name = "url" }
                 ),

                 resolve: context =>
                 {
                     var url = context.GetArgument<String>("url");
                     var obj = context.GetArgument<FileDto>("obj");
                     FileSystemManager Read = new FileSystemManager();
                     return Read.Upload($"pessoaDocumento/{url}", obj);
                 });

            Field<StringGraphType>(
                "createdir",
                arguments: new QueryArguments(
                new QueryArgument<FileSystInputType> { Name = "obj" }),
                resolve: context =>
                {
                    var obj = context.GetArgument<FileSyst>("obj");
                    FileSystemManager Read = new FileSystemManager();
                    return Read.CreateUserDirStruct(obj.url, obj.dirprincipal);

                });

            Field<StringGraphType>(
                "download",
                arguments: new QueryArguments(new QueryArgument<FileSystInputType> { Name = "obj" }),
                resolve: context =>
                {
                    var obj = context.GetArgument<FileSyst>("obj");
                    FileSystemManager Read = new FileSystemManager();
                    return Read.DownloadFile(obj.url);
                });

            Field<StringGraphType>(
                "removerfile",
                arguments: new QueryArguments(new QueryArgument<FileSystInputType> { Name = "obj" }),
                resolve: context =>
                {
                    var obj = context.GetArgument<FileSyst>("obj");
                    FileSystemManager Read = new FileSystemManager();
                    return Read.DeleteFile(obj.url);
                });

            FieldAsync<StringGraphType>(
              "excelenviado",
              arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "obj" }),
              resolve: async context =>
              {
                  var obj = context.GetArgument<string>("obj");
                  var Read = new Excel();
                  var tr = Read.dt(obj);
                  foreach (var itens in tr)
                  {
                      var pessoa = await Repo.GetAsync<Pessoa>(itens.PROPRETARIO, nameof(Pessoa.IdPessoa));
                      if (pessoa != null)
                      {
                          await Repo.AddAsync(new Automovel()
                          {
                              Matricula = itens.MATRICULA,
                              NumeroChassi = itens.NUMEROCHASSI,
                              ProprietarioId = itens.PROPRETARIO,
                              NumLugares = itens.NUMERODELUGARES,
                              NumMotor = itens.NUMERODOMOTOR,
                              Potencia = itens.POTENCIA,
                              PesoBruto = itens.PESOBRUTO,
                              ValorEmNovo = itens.VALOREMNOVO,
                              ValorActual = itens.VALOREACTUAL,
                              AnoConstrucao = itens.ANODOVEICULO,
                              CilindragemAutomovelId = itens.CILINDRAGEM,
                               //ClassificacaoAutomovelId = itens.CLASSIFICACAO,
                               PaisMatriculaId = itens.PAISDAMATRICULA

                          });
                      }
                      else
                      {
                          await Repo.AddAsync(new Automovel()
                          {
                              Matricula = itens.MATRICULA,
                              NumeroChassi = itens.NUMEROCHASSI,
                              Potencia = itens.POTENCIA,
                              PesoBruto = itens.PESOBRUTO,
                              ValorEmNovo = itens.VALOREMNOVO,
                              Proprietario = new Pessoa()
                              {
                                  NomeCompleto = "testexceltest"
                              },
                              CilindragemAutomovelId = itens.CILINDRAGEM,
                              ClassificacaoAutomovelId = itens.CLASSIFICACAO,
                              MotoristaAutomovel = new List<MotoristaAutomovel>()
                              {
                                    new MotoristaAutomovel
                                    {
                                        MotoristaId = itens.CONDUTOR
                                    }
                              }
                          });
                      }
                  }
                  return "Arquivo Enviado Com sucesso";
              });
            /*Field<StringGraphType>(
                 "excel",
            arguments: new QueryArguments(new QueryArgument<FileSystInputType> { Name = "obj" }),
            resolve: context =>
            {
                var Read = new ISS.GraphQL.Excel.Excel();
            Read.Gerarar(@"D:\ter.xlsx");
                //  var marcas = Read.sqlrt<MarcaAutomovel>(nameof(MarcaAutomovel));
                // var models = Read.sqlrt<ModeloAutomovel>(nameof(ModeloAutomovel));
                // string[] cabecalho = {"MARCA","MODELO","CILINDRAGEM"};
                // string[] valor = {marcas.Select(x => x.Marca).ToString(), models.Select(x => x.Modelo).ToString(), "CILINDRAGEM" };
               
                // Read.CreatePanilha(@"D:\ter.xlsx", "teste", cabecalho,valor);
                return "feito"; s
            });
            */


            FieldAsync<RegisterType>("registrar",
                 arguments: new QueryArguments(Arg<NonNullGraphType<RegisterInputType>>("obj")),
                 resolve: async context =>
                 {
                     var result = await repository.ExecuteAsync(async provider =>
                     {
                         var credenciais = context.GetArgument<RegisterViewModel>("obj");
                         var userRepo = provider.GetService<IUsuarioRepository>();
                         var rs = await userRepo.RegisterAsync(credenciais);
                         return rs;
                     });

                     return context.Resolve(result);
                 });

            // Inserção para movimento com paridade
            FieldListAsync<MovimentoType, Movimento>("addMovimentoPar", async (context, repo) =>
            {
                try
                {
                    var retorno = await repo.ExecuteAsync(async provider =>
                    {
                        return await Task.FromResult(new ISS.Application.Movimentos.Movimentos(provider.GetService<DapperContext>(), provider.GetService<LinqDbContext>()).
                                    CreateMovParidadeContabilidade(context.GetArgument<Movimento>("obj")));
                    });

                    return retorno;
                }
                catch (Exception ex)
                {
                    context.Errors.Add(new ExecutionError(ex.Message));
                    if (ex.InnerException != null)
                        context.Errors.Add(new ExecutionError(ex.InnerException.Message));
                    return null;
                }

            }, Arg<MovimentoInputType>("obj"));

            //// Insercção de movimento impar
            FieldListAsync<MovimentoType, Movimento>("addMovimentoImpar", async (context, repo) =>
            {
                try
                {
                    var retorno = await repo.ExecuteAsync(async provider =>
                    {
                        return await Task.FromResult(new ISS.Application.Movimentos.Movimentos(provider.GetService<DapperContext>(), provider.GetService<LinqDbContext>()).
                                        CreateMovImparidadeContabilidade(context.GetArgument<Movimento>("obj")));
                    });
                    return retorno;
                }
                catch (Exception ex)
                {
                    context.Errors.Add(new ExecutionError(ex.Message));
                    if (ex.InnerException != null)
                        context.Errors.Add(new ExecutionError(ex.InnerException.Message));
                    return null;
                }

            }, Arg<MovimentoInputType>("obj"));

            // Função auxiliar para efectuar o calculo de uma cotacao
            CalculoModel Calcular(Cotacao data, bool movimento = false)
            {
                var qs = Repo.GetAsync<QualidadeSegura>(data.QualidadeEmQueSeguraId, nameof(QualidadeSegura.IdQualidadeSegura)).Await();
                if (qs?.CodQualidadeSegura == "Q005")
                {
                    var membro = new MembroAssegurado { PessoaId = data.TomadorId };
                    if (data.MembroAssegurado == null)
                        data.MembroAssegurado = new MembroAssegurado[] { membro };
                    else
                        data.MembroAssegurado.Add(membro);
                }

                // Efectuando os calculos
                var result = Repo.ExecuteAsync(async provider =>
                {
                    return await Task.FromResult(new Calculos(provider.GetService<DapperContext>(), provider.GetService<IRepository>()));
                }).Await();

                var calculo = result.CalculoGeral(new CalculoModel
                {
                    Cotacao = data
                }, movimento);

                #region Setters
                // Preenchendo os campos do object de cotacao
                data.PremioBase = calculo.PremioBase;
                data.PremioRisco = calculo.PremioRisco;
                data.PremioSimples = calculo.PremioSimples;
                data.PremioComercial = calculo.PremioComercial;
                data.PremioBruto = calculo.PremioBruto;
                data.PremioTotal = calculo.PremioCobrado;

                data.EncargosAdministrativos = calculo.Agravamentos;
                data.Despesas = calculo.Despesas;
                data.Descontos = calculo.Descontos;
                data.Ofertas = calculo.Ofertas;
                data.Comissoes = calculo.Comissoes;
                data.Agravamentos = calculo.Agravamentos;
                data.Impostos = calculo.Impostos;
                #endregion

                data.MembroAssegurado = data.MembroAssegurado.Select(m =>
                {
                    var analiseRisco = calculo.AnaliseRisco.FirstOrDefault(x => x.Pessoa.IdPessoa == m.PessoaId);
                    if (analiseRisco == null) return m;

                    #region Setters
                    m.PremioBase = analiseRisco.PremioBase;
                    m.PremioRisco = analiseRisco.PremioRisco;
                    m.PremioSimples = analiseRisco.PremioSimples;
                    m.PremioComercial = analiseRisco.PremioComercial;
                    m.PremioCobrado = analiseRisco.PremioCobrado;

                    m.Agravamentos = analiseRisco.Agravamentos;
                    m.AgravamentosPorIdade = analiseRisco.AgravamentosPorIdade;
                    m.Arseg = analiseRisco.Arseg;
                    m.CapitalSeguro = analiseRisco.CapitalSeguro;
                    m.EncargoAdministrativo = analiseRisco.EncargosAdministrativos;
                    m.Descontos = analiseRisco.Descontos;
                    m.DescontosPorIdade = analiseRisco.DescontosPorIdade;
                    m.Despesas = analiseRisco.Despesas;
                    m.Impostos = analiseRisco.Impostos;
                    m.Iva = analiseRisco.Iva;
                    m.Ofertas = analiseRisco.Ofertas;
                    m.SinistroEsperado = analiseRisco.SinistroEsperado;
                    #endregion

                    return m;
                }).ToList();

                return calculo;
            }

            // Criação de uma cotação
            FieldAsync<CotacaoType, CotacaoInputType, Cotacao>(param: new Param<Cotacao>
            {
                Add = async (data, context) =>
                {
                    // Efectuando os calculos
                    var cal = Calcular(data);


                    // Verificando se os calculos foram bem feitos
                    if (!cal.Status)
                    {
                        context.Errors.Add(new ExecutionError(cal.Message));
                        return null;
                    }
                    await Repo.AddAsync(data);

                    var rabbit = new RabbitMQClient(Repo);
                    if (rabbit.CheckConn())
                        rabbit.Send(Exchange.MQExchange, "Cotacao", "A", data);

                    return new RepoResponse<Cotacao> { Data = data };
                },
                Update = async (data, id, context) =>
                {
                    var cal = await repository.ExecuteAsync(async provider =>
                    {
                        return await Task.FromResult(new Calculos(provider.GetService<DapperContext>(), provider.GetService<IRepository>())
                            .CalculoGeral(new CalculoModel { Cotacao = data }));

                    });

                    // Verificando se os calculos foram bem feitos
                    if (!cal.Status)
                    {
                        context.Errors.Add(new ExecutionError(cal.Message));
                        return null;
                    }
                    await Repo.UpdateAsync(id, data);
                    return default;
                }
            });

            FieldAsync<ListGraphType<ReciboType>>("addPagamento",
                arguments: new QueryArguments(
                    Arg<ListGraphType<PagamentoDtoInputType>>("obj")),
                resolve: async context =>
                {
                    // Pegar os dados do pagamento passados como argumento.
                    var dtos = context.GetArgument<List<PagamentoDto>>("obj");
                    ICollection<Recibo> recibos = new HashSet<Recibo>();
                    // TODO: Perigo
                    var estado = await Repo.GetAsync<Estado>("E012", nameof(Estado.CodEstado));
                    // TODO: Tem haver com os DapperInclude
                    await Repo.ExecuteAsync( async provider => await Task.FromResult(provider.GetService<DapperContext>()));

                    Debug.Assert(estado != null,"Nulo não permitido");

                    foreach (var dto in dtos)
                    {
                        // Buscar os dados da apólice pela referência.
                        var cotacao = await Repo.GetAsync<Cotacao>(dto.PropostaRef, nameof(Cotacao.ReferenciaCotacao));

                        // Verificar que alguma coisa foi retornada.
                        if (cotacao == null)
                        {
                            context.Errors.Add(new ExecutionError($"{dto.PropostaRef}: Referência da proposta inválida!"));
                            return default;
                        }

                        cotacao.EstadoId = estado.IdEstado;

                        cotacao.DapperInclude(e => e.CoberturaSelecionada);

                        // Operação de depósito na conta financeira.
                        // 1º Depositar o valor a paga na conta do cliente.
                        //  -> S.D = S.D + V.D -> S.D: Saldo disponível, V.D: Valor à Depositar
                        var succeded = await Repo.ExecuteQueryAsync(async (ctx) =>
                        {
                            var query = from c in ctx.Cliente
                                        join p in ctx.Pessoa
                                        on c.PessoaId equals p.IdPessoa
                                        select p;

                        // Verificar se há algum dado após pesquisa.
                        if (!query.Any())
                            {
                                context.Errors.Add(new ExecutionError("Cliente inválido!"));
                                return false;
                            }

                        // Pegar os dados da pessoa encontrada.
                        var pessoa = await query.FirstAsync();

                        // Pegar a conta financeira do cliente.
                        var query2 = from titularidade in ctx.Titularidade
                                         join conta in ctx.ContaFinanceira
                                         on titularidade.ContaFinanceiraId equals conta.IdContaFinanceira
                                         where titularidade.PessoaId == pessoa.IdPessoa
                                         select conta;

                        // Verificar se existe alguma conta financeira para o cliente em questão.
                        if (!query2.Any())
                            {
                                context.Errors.Add(new ExecutionError("Cliente não possui uma conta financeira!"));
                                return false;
                            }

                        // Pegar as informações da conta financeira.
                        var contaFinanceira = await query2.FirstAsync();

                            var query3 = from saldo in ctx.GetTable<Saldo>()
                                         where saldo.ContaFinanceiraId == contaFinanceira.IdContaFinanceira
                                         select saldo;

                            if (!query3.Any())
                            {
                                await ctx.InsertAsync(new Saldo
                                {
                                    IdSaldo = Guid.NewGuid().ToString(),
                                    Saldo1 = dto.ValorAPagar,
                                    SaldoDisponivel = dto.ValorAPagar,
                                    SaldoContabilistico = dto.ValorAPagar,
                                    ContaFinanceiraId = contaFinanceira.IdContaFinanceira
                                });
                            }
                            else
                            {
                            // TODO: É suposto pegar o último registro do saldo
                            var saldo = await query3.FirstAsync();
                                await ctx.InsertAsync(new Saldo
                                {
                                    IdSaldo = Guid.NewGuid().ToString(),
                                    Saldo1 = saldo.Saldo1 + dto.ValorAPagar,
                                    SaldoDisponivel = saldo.SaldoDisponivel + dto.ValorAPagar,
                                    SaldoContabilistico = saldo.SaldoContabilistico + dto.ValorAPagar,
                                    ContaFinanceiraId = contaFinanceira.IdContaFinanceira
                                });
                            }

                            return true;
                        });

                        if (!succeded)
                        {
                            context.Errors.Add(new ExecutionError("Não foi possível concluir a operação!"));
                            return default;
                        }

                        ICollection<PlanoProduto> planos = new List<PlanoProduto>();
                        foreach (var cobPlano in cotacao?.CoberturaSelecionada)
                        {
                            cobPlano?.DapperInclude(e => e.CoberturaPlano);
                            cobPlano?.CoberturaPlano?.DapperInclude(e => e.PlanoProduto);

                            var idPlano = cobPlano?.CoberturaPlano?.PlanoProduto?.IdPlano;
                            if (planos.Any(x => x.IdPlano == idPlano))
                                continue;
                            planos.Add(cobPlano?.CoberturaPlano?.PlanoProduto);
                        }

                        var movimentos = new Movimentos(DapperContext.Instance, null);
                        foreach (var planoProduto in planos)
                        {
                            // Inclusão das operações do plano.
                            planoProduto.DapperInclude(e => e.OperacaoPlano);


                            planoProduto.OperacaoPlano?.For(x =>
                            {
                                x.DapperInclude(o => o.Operacao);
                                var operacao = x.Operacao;
                                operacao.DapperInclude(t => t.TipoOperacao);
                                operacao.TipoOperacao.DapperInclude(x => x.SubContaCredito);
                                operacao.TipoOperacao.DapperInclude(x => x.SubContaDebito);
                                movimentos.CreateMovFromTipoOperacao(new Movimento
                                {
                                    DescricaoMovimento = operacao.Designacao,
                                    IsPago = true,
                                    CodOperacao = operacao.CodOperacao,
                                    Referencia = StringHelper.SetCode("MO_")
                                }, operacao.TipoOperacao);
                            });

                        }

                        // Criação da apólice após pagamento da proposta.
                        var apolice = new Apolice
                        {
                            IdApolice = Guid.NewGuid().ToString(),
                            DataEmissao = DateTime.UtcNow,
                            DataInicio = cotacao.DataInicio,
                            DataExpiracao = cotacao.DataExpiracao,
                            TomadorId = cotacao.TomadorId,
                            ProdutorId = cotacao.ProdutorId
                        };

                        var cotacaoDependente = new CotacaoDependente { CotacaoId = cotacao.IdCotacao, ApoliceId = apolice.IdApolice };

                        // Atribuir os valores necessários para criação de um recibo.
                        var recibo = new Recibo { Designacao = "Apólice", DataEmissao = DateTime.UtcNow, Valor = dto.ValorAPagar, ApoliceId = apolice.IdApolice };

                        // Adicionar as informações do recibo a base de dados.
                        await Repo.UpdateAsync(cotacao.IdCotacao, cotacao);
                        await Repo.AddAsync(apolice);
                        await Repo.AddAsync(cotacaoDependente);
                        await Repo.AddAsync(recibo);

                        // Registrar um novo recibo.
                        recibos.Add(recibo);
                    }

                    // Criar e retornar o recibo pós-pagamento.
                    return recibos;
                });

            FieldAsync<ApoliceType>("addApolice",
                 arguments: new QueryArguments(
                     Arg<NonNullGraphType<StringGraphType>>("cotacaoId"),
                     Arg<NonNullGraphType<ApoliceInputType>>("apolice")),
                 resolve: async context =>
                 {
                     // Pegando os parametros de entrada
                     var cotacaoId = context.GetArgument<string>("cotacaoId");
                     var apolice = context.GetArgument<Apolice>("apolice");

                     // Pegando o repositorio de dados

                     // Variável auxiliar para recuparar os dados de cotacao
                     var cotacaoDb = await Repo.GetAsync<Cotacao>(cotacaoId, $"{nameof(Cotacao.IdCotacao)}, {nameof(Cotacao.CodCotacao)}");
                     Apolice apoliceDb = null;

                     // Verificando se tem um valor válido.
                     if (cotacaoDb == null) return null;

                     var novaCotacaoDependente = new CotacaoDependente { CotacaoId = cotacaoDb.IdCotacao, Apolice = apolice };

                     // Inserindo os dados
                     await Repo.AddAsync(novaCotacaoDependente);
                     var cotacaoDependente = context.Resolve(new RepoResponse<CotacaoDependente> { Data = novaCotacaoDependente });

                     // Verificando se tem um valor valido
                     if (cotacaoDependente == null) return null;

                     // Settando a apolice
                     apoliceDb = await Repo.GetAsync<Apolice>(cotacaoDependente.Apolice.IdApolice, nameof(Apolice.IdApolice));

                     return apoliceDb;
                 });

            FieldAsync<CotacaoType>("updateApolice",
                 arguments: new QueryArguments(
                     Arg<CotacaoInputType>("cotacao"),
                     Arg<StringGraphType>("cotacaoId")),
                 resolve: async context =>
                 {
                     context.Errors.Add(new ExecutionError("Função não implementada!!"));
                     return await Task.FromResult(default(Cotacao));
                 });

            FieldAsync<CotacaoType>("inclusaoApolice",
                arguments: new QueryArguments(Arg<MembroAsseguradoInputType>("membro")),
                resolve: async context =>
                {
                    var obj = context.GetArgument<MembroAssegurado>("obj");

                    await Repo.AddAsync(obj);

                    var res = context.Resolve(new RepoResponse<MembroAssegurado> { Data = obj });
                    var cotacao = await Repo.GetAsync<Cotacao>(res.CotacaoId, nameof(Cotacao.IdCotacao));
                    cotacao.DapperInclude(d => d.MembroAssegurado);

                    Calcular(cotacao);
                    await Repo.UpdateAsync(res.CotacaoId, cotacao);
                    return context.Resolve(new RepoResponse<Cotacao> { Data = cotacao });
                });

            // FieldAsync<StringGraphType>("pagamento",
            //     arguments: new QueryArguments( Arg<NonNullGraphType<PagamentoDtoInputType>>("obj")),
            //     resolve: async context =>
            //     {
            //         var pagamento = context.GetArgument<PagamentoDto>("obj");

            //         var mov = await Repo.ExecuteAsync( async provider => 
            //         {
            //             await Task.Delay(0);
            //             return new Contabilidade.Movimentos.Movimentos(provider.GetService<DapperContext>(),provider.GetService<LinqDbContext>());
            //         });

            //         mov.SetMovimento(new Movimento
            //         { 
            //             Valor = pagamento.ValorAPagar,
            //             CodFormaPagamento = "",
            //             NumeroDocumentoExterno = pagamento.NumeroRefApolice
            //         },null,null);

            //         await Task.Delay(0);

            //         return context.Resolve(new RepoResponse<string>{Data = "Sucesso"});
            //     });


            FieldAsync<CotacaoType>("exclusaoApolice",
                 arguments: new QueryArguments(Arg<StringGraphType>("membroId")),
                 resolve: async context =>
                 {
                     // TODO: Resolver
                     // var membroId = context.GetArgument<string>("membroId");
                     // await Repo.RemoveAsync<MembroAssegurado>(membroId);
                     //  var res = context.Resolve();
                     //  var cotacao = context.Resolve(await Repo.GetAsync<Cotacao>(res.CotacaoId, nameof(Cotacao.IdCotacao)));
                     //  cotacao.DapperInclude(d => d.MembroAssegurado);

                     //  Calcular(cotacao);

                     return await Task.FromResult(default(Cotacao));//context.Resolve(await Repo.UpdateAsync(res.CotacaoId, cotacao));
                 });

            // Criação de uma cotação
            FieldAsync<PessoaSingularType>($"add{nameof(ISS.Application.Dto.Models.PessoaSingular)}",
                   arguments: new QueryArguments(Arg<NonNullGraphType<PessoaSingularInputType>>("obj")),
                   resolve: async context =>
                    {
                        var data = context.GetArgument<Pessoa>("obj");
                        data.TipoPessoaId = (await Repo.GetAsync<TipoPessoa>("T000", nameof(TipoPessoa.CodTipoPessoa)))?.IdTipoPessoa;
                        await Repo.AddAsync(data);
                        new FileSystemManager().CreateUserDirStruct(data.IdPessoa, "Pessoa");
                        return data;
                    });

            // Criação de uma cotação
            FieldAsync<PessoaColectivaType>($"add{nameof(ISS.Application.Dto.Models.PessoaColectiva)}",
                arguments: new QueryArguments(Arg<NonNullGraphType<PessoaColectivaInputType>>("obj")),
                resolve: async context =>
                {
                    var data = context.GetArgument<Pessoa>("obj");
                    data.TipoPessoaId = (await Repo.GetAsync<TipoPessoa>("T001", nameof(TipoPessoa.CodTipoPessoa)))?.IdTipoPessoa;
                    await Repo.AddAsync(data);
                    new FileSystemManager().CreateUserDirStruct(data.IdPessoa, "Pessoa");
                    return data;
                });

            FieldAsync<ListGraphType<PlanoObjectivoComercialType>>("addPlanoObjectivoComercial",
                 arguments: new QueryArguments(
                     Arg<NonNullGraphType<PlanoObjectivoComercialInputType>>("obj"),
                     Arg<StringGraphType>("auto"),
                     Arg<StringGraphType>("planoId")),
                 resolve: async context =>
                 {
                     // A lista que será retornada depois de tudo ser efectuado
                     var retorno = new List<PlanoObjectivoComercial>();
                     // O servico do dapper para realizar as insercões dos dados
                     var db = await repository.ExecuteAsync(async provider =>
                     {
                         return await Task.FromResult(provider.GetService<DapperContext>());
                     });

                     var model = context.GetArgument<PlanoObjectivoComercial>("obj");
                     var planoId = context.GetArgument<string>("planoId");
                     var auto = context.GetArgument<string>("auto");

                     // Função auxiliar para adicionar na base de dados um objecto de plano de objectivo comercial
                     async Task<PlanoObjectivoComercial> AddHierarquia(Parametro obj)
                     {
                         // Copinado o objecto
                         PlanoObjectivoComercial Model = new MapBuilder.Mapper().Copy(obj.Model);

                         // Efectuando os calculos
                         Model.Quantidade = obj.QuantidadeElementos != 0 ? Model.Quantidade / obj.QuantidadeElementos : Model.Quantidade;
                         Model.ValorPlaneado = obj.QuantidadeElementos != 0 ? Model.ValorPlaneado / obj.QuantidadeElementos : Model.ValorPlaneado;
                         Model.ValorProposto = obj.QuantidadeElementos != 0 ? Model.ValorProposto / obj.QuantidadeElementos : Model.ValorPlaneado;

                         // Adicionando as taxas
                         Model.ValorPlaneado += Model.ValorPlaneado * Model.Taxa;
                         Model.ValorProposto += Model.ValorProposto * Model.Taxa;

                         var plano = new PlanoObjectivoComercial
                         {
                             IdPlanoObjectivoComercial = obj.Id,
                             PlanoObjectivoComercialId = obj.Model.IdPlanoObjectivoComercial,
                             CodHierarquia = obj.Codigo,

                             DataPlanoFim = Model.DataPlanoFim,
                             DataPlanoInicio = Model.DataPlanoInicio,
                             EstadoId = Model.EstadoId,
                             TipoObjectivoPlanoId = Model.TipoObjectivoPlanoId,

                             Quantidade = Model.Quantidade,
                             ValorPlaneado = Model.ValorProposto,
                             ValorProposto = Model.ValorProposto
                         };

                         await Repo.AddAsync(plano);

                         // Inserindo os dados da base de dados
                         var res = context.Resolve(new RepoResponse<PlanoObjectivoComercial> { Data = plano });

                         // Adicionando o dado inserido no retorno
                         retorno.Add(res);
                         // Retornando os dados
                         return res;
                     };

                     var id = Guid.NewGuid().ToString();
                     var genCode = model.CodHierarquia;
                     // Senão for mandado o identificador de um plano estrategico, será definido id do plano
                     if (planoId == null)
                         model.IdPlanoObjectivoComercial = id;
                     else
                         // Se for mandado, define simplesmente o plano que foi mandado
                         model.PlanoObjectivoComercialId = planoId;

                     await Repo.AddAsync(model);

                     // Inserindo o plano mandado
                     var retornoDb = context.Resolve(new RepoResponse<PlanoObjectivoComercial> { Data = model });

                     if (retornoDb == null)
                         return null;

                     retorno.Add(retornoDb);

                     // Verificando se deve ser gerada a hierarquia automatica
                     if (auto != null && auto.ToLower().Equals("true"))
                     {
                         // Recuperando a hierarquia toda para que seja automaticamente definido
                         var pais = await db.GetAsync<Pais>(e =>
                         {
                             // Incluindo a provincia
                             e.DapperThenInclude(d => d.Provincia)
                              .For(p =>
                              {
                                  // Incluindo o municipio
                                  p.DapperThenInclude(d => d.Municipio)
                                   .For(m =>
                                   {
                                       // Incluindo o distrito
                                       m.DapperThenInclude(d => d.Distrito)
                                        .For(dt =>
                                        {
                                            // Incluindo o balcao
                                            dt.DapperThenInclude(d => d.Balcao)
                                              .For(b =>
                                              {
                                                  // Incluindo a responsavel
                                                  b.DapperThenInclude(d => d.ResponsavelBalcao)
                                                   .For(rb =>
                                                  {
                                                      // Incluindo os responsaveis e as pessoas
                                                      rb.DapperThenInclude(d => d.Responsavel)
                                                         .DapperInclude(d => d.Pessoa);
                                                      // Incluindo os sectores e os departamento dos responsaveis
                                                      rb.Responsavel?
                                                         .DapperThenInclude(d => d.Sector)
                                                         .DapperThenInclude(d => d.Departamento);
                                                      // Incluindo as pessoas e os seus papeis
                                                      rb.Responsavel?.Pessoa
                                                         .DapperThenInclude(d => d.PapelPessoa)
                                                         .For(pp =>
                                                         {
                                                             pp.DapperInclude(d => d.Papel);
                                                         });

                                                  });
                                              });
                                        });
                                   });
                              });
                         }, model.CodHierarquia, nameof(Pais.CodPais));

                         var provincias = pais.FirstOrDefault()?.Provincia;

                         foreach (var p in provincias)
                         {
                             // Inserindo plano para provincia
                             var pId = Guid.NewGuid().ToString();
                             string p_genCode = genCode + '.' + p.CodProvincia;

                             PlanoObjectivoComercial ProvinciaModel = await AddHierarquia(new Parametro
                             {
                                 Id = pId,
                                 Codigo = p_genCode,
                                 Model = model,
                                 QuantidadeElementos = provincias.Count()
                             });

                             foreach (var m in p.Municipio)
                             {
                                 // Inserindo plano para municipio
                                 var mId = Guid.NewGuid().ToString();
                                 string m_genCode = p_genCode + '.' + m.CodMunicipio;

                                 PlanoObjectivoComercial MunicipioModel = await AddHierarquia(new Parametro
                                 {
                                     Id = mId,
                                     Codigo = m_genCode,
                                     Model = ProvinciaModel,
                                     QuantidadeElementos = p.Municipio.Count
                                 });

                                 foreach (var d in m.Distrito)
                                 {
                                     // Inserindo plano para distrito
                                     var dId = Guid.NewGuid().ToString();
                                     string d_genCode = m_genCode + '.' + d.CodDistrito;

                                     PlanoObjectivoComercial DistritoModel = await AddHierarquia(new Parametro
                                     {
                                         Id = dId,
                                         Codigo = d_genCode,
                                         Model = MunicipioModel,
                                         QuantidadeElementos = m.Distrito.Count
                                     });

                                     foreach (var b in d.Balcao)
                                     {
                                         // Inserindo plano para distrito
                                         var bId = Guid.NewGuid().ToString();
                                         string b_genCode = d_genCode + '.' + b.CodBalcao;

                                         PlanoObjectivoComercial BalcaoModel = await AddHierarquia(new Parametro
                                         {
                                             Id = bId,
                                             Codigo = b_genCode,
                                             Model = DistritoModel,
                                             QuantidadeElementos = d.Balcao.Count
                                         });

                                         var res = b.ResponsavelBalcao.FirstOrDefault(x =>
                                         {
                                             return x.Responsavel.Sector.Departamento.CodDepartamento == "D010" &&
                                                 x.Responsavel.Pessoa.PapelPessoa.Where(y => y.PessoaId == x.Responsavel.Pessoa.IdPessoa)
                                                 .Any(z => z.Papel.IsProdutor == true);
                                         });

                                         if (res != null)
                                         {
                                             var pessoa = res.Responsavel.Pessoa;
                                             // Inserindo plano para distrito
                                             var psId = Guid.NewGuid().ToString();

                                             PlanoObjectivoComercial PessoaModel = await AddHierarquia(new Parametro
                                             {
                                                 Id = psId,
                                                 Codigo = b_genCode + '.' + pessoa.Nif,
                                                 Model = BalcaoModel,
                                                 QuantidadeElementos = d.Balcao.Count
                                             });
                                         }
                                     }
                                 }
                             }
                         }
                     }

                     return retorno;
                 });

        }
    }

}