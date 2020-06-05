using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using ISS.GraphQL.Repository;
using ISS.GraphQL.ServiceExtentions;
using ISS.GraphQL.ISRabbitMQ;
using ISS.GraphQL.ISRabbitMQ.Models;
using System;
using ISS.Application.Helpers;
using FileSystem.FileSystem;
using System.Collections.Generic;
using ISS.Application.Dto;
using System.Diagnostics;
using ISS.Application.Models;
using System.Threading.Tasks;
using ISS.GraphQL.Calculo;
using ISS.Application;

namespace ISS.GraphQL.Query
{
    public abstract class AppMutationBase : AppBase
    {
        protected AppMutationBase(IRepository repository) : base(repository) { }

        private ICollection<FileDto> GetFileDto(Dictionary<string, object> obj)
        {

            object fileVal = null;
            obj?.TryGetValue("ficheiro", out fileVal);
            if (fileVal == null)
                return default;

            var collection = new List<FileDto>();
            foreach (Dictionary<string, object> fi in (fileVal as ICollection<object>))
            {
                // Tentativas de pegar valores do dicionário de dados.
                if (!fi.TryGetValue("nome", out object nome)) // Pegando o nome do ficheiro.
                    continue;
                if (!fi.TryGetValue("extensao", out object extensao)) // Pegando a extensão do ficheiro.
                    continue;
                if (!fi.TryGetValue("data", out object data)) // Pegando as informações em base64 do ficheiro.
                    continue;

                collection.Add(new FileDto { Nome = nome as string, Extensao = extensao as string, Data = data as string });
            }

            return collection;
        }

        public void FieldAsync<TGraphType, TGraphInputType, TModel>(string name = null, Param<TModel> param = null)
            where TGraphType : ObjectGraphType<TModel>
            where TGraphInputType : InputObjectGraphType
            where TModel : class
        {
            var typeName = typeof(TGraphType).Name.Replace("Type", "");
            Debug.Assert(!typeName.Equals("PessoaSingular"));
            // Add Field
            FieldAsync<TGraphType>(
                    name ?? $"add{typeName}",
                    arguments: new QueryArguments(
                        Arg<NonNullGraphType<TGraphInputType>>("obj")
                    ),
                    resolve: async context =>
                    {
                        // Criando o modelo
                        TModel model = context.GetArgument<TModel>("obj");

                        // TODO: Melhorar 
                        if(model is Cotacao cot) 
                        {
                            var result = await Repo.ExecuteAsync(async provider => await Task.FromResult(new Calculos(provider.GetService<DapperContext>(), provider.GetService<IRepository>())));

                            var cal =  result.CalculoGeral(new CalculoModel { Cotacao = context.GetArgument<Cotacao>("obj") });

                            // Configurar váriaveis para o objecto de cotação no retorno.
                            cot.PremioBase = cal.PremioBase;
                            cot.PremioSimples = cal.PremioSimples;
                            cot.PremioRisco = cal.PremioRisco;
                            cot.PremioComercial = cal.PremioComercial;
                            // TODO: cot.PremioTotal = 
                            cot.PremioBruto = cal.PremioBruto;
                            cot.Iva = cal.Iva;
                            cot.Arseg = cal.Arseg;
                            cot.CapitalSeguro = cal.CapitalSeguro;
                            cot.EncargosAdministrativos = cal.EncargosAdministrativos;
                            cot.Impostos = cal.Impostos;
                            cot.Descontos = cal.Descontos;
                            cot.Agravamentos = cal.Agravamentos;
                            cot.Despesas = cal.Despesas;
                            cot.Ofertas = cal.Ofertas;
                            cot.Comissoes = cal.Comissoes;
                            cot.AgravamentosPorIdade = cal.AgravamentosPorIdade;
                            cot.DescontosPorIdade = cal.DescontosPorIdade;
                        }

                        var id = Guid.NewGuid().ToString();
                        var files = GetFileDto((context.Arguments["obj"] as Dictionary<string, object>));

                        // Retornando a resposta
                        if (files != null)
                        {
                            FileSystemManager Read = new FileSystemManager();
                            Read.CreateUserDirStruct(id as string, typeName);
                            Read.Upload($"Documento/{typeName}/{id}", files);
                            var url = $"Documento/{typeName}/{id}/";
                            var modeli = model.SetPropValue("CaminhoFicheiro", url);
                        }
                        // Criando a resposta que será resolvida
                        await Repo.AddAsync(model);
                        // RepoResponse<TModel> response;


                        // Verificando se a função está definida
                        if (param?.Add == null)
                        {
                            var rabbit = new RabbitMQClient(Repo);

                            if (rabbit.CheckConn())
                                rabbit.Send(Exchange.MQExchange, typeName, "A", model);
                        }

                        // Retornando a resposta
                        return context.Resolve(new RepoResponse<TModel> { Data = model });
                    });



            // Update Field
            FieldAsync<TGraphType>(
                    $"update{typeName}",
                    arguments: new QueryArguments(
                        Arg<NonNullGraphType<StringGraphType>>("id"),
                        Arg<NonNullGraphType<TGraphInputType>>("obj")
                    ),
                    resolve: async context =>
                    {
                        // Criando a resposta que será resolvida
                        // Criando o modelo
                        TModel model = context.GetArgument<TModel>("obj");
                        // Pegando o id do elemento
                        string id = context.GetArgument<string>("id");
                        // Verificando se a função está definida
                        await Repo.UpdateAsync(id, model);
                        if (param?.Update == null)
                        {
                            var rabbit = new RabbitMQClient(Repo);
                            if (rabbit.CheckConn())
                                rabbit.Send(Exchange.MQExchange, typeName, "A", model);
                        }
                        return context.Resolve(new RepoResponse<TModel> { Data = model });
                    });

            // Remove Field
            FieldAsync<TGraphType>(
                    $"remove{typeName}",
                    arguments: new QueryArguments(
                        Arg<NonNullGraphType<StringGraphType>>("id")
                    ),
                    resolve: async context =>
                    {
                        // Criando a resposta que será resolvida
                       
                        // Pegando o id do elemento
                        string id = context.GetArgument<string>("id");
                        await Repo.RemoveAsync<TModel>(id);
                        // Verificando se a função está definida
                        if (param?.Remove == null)
                        {
                            var rabbit = new RabbitMQClient(Repo);
                            if (rabbit.CheckConn())
                              rabbit.Send(Exchange.MQExchange, typeName, "D", id);

                        }
                        
                        return context.Resolve(new RepoResponse<TModel> { });
                    });
        }

        public void FieldAsyncV2<TGraphType, TGraphInputType, TModel>(string name = null, Param<TModel> param = null)
            where TGraphType : ObjectGraphType<TModel>
            where TGraphInputType : InputObjectGraphType<TModel>
            where TModel : class
        {
            var typeName = typeof(TGraphType).Name.Replace("Type", "");
            Debug.Assert(!typeName.Equals("PessoaSingular"));
            // Add Field
            FieldAsync<TGraphType>(
                    name ?? $"add{typeName}",
                    arguments: new QueryArguments(
                        Arg<NonNullGraphType<TGraphInputType>>("obj")
                    ),
                    resolve: async context =>
                    {
                        // Criando o modelo
                        TModel model = context.GetArgument<TModel>("obj");

                        // TODO: Melhorar 
                        if (model is Cotacao cot)
                        {
                            var result = await Repo.ExecuteAsync(async provider => await Task.FromResult(new Calculos(provider.GetService<DapperContext>(), provider.GetService<IRepository>())));

                            var cal = result.CalculoGeral(new CalculoModel { Cotacao = context.GetArgument<Cotacao>("obj") });

                            // Configurar váriaveis para o objecto de cotação no retorno.
                            cot.PremioBase = cal.PremioBase;
                            cot.PremioSimples = cal.PremioSimples;
                            cot.PremioRisco = cal.PremioRisco;
                            cot.PremioComercial = cal.PremioComercial;
                            // TODO: cot.PremioTotal = 
                            cot.PremioBruto = cal.PremioBruto;
                            cot.Iva = cal.Iva;
                            cot.Arseg = cal.Arseg;
                            cot.CapitalSeguro = cal.CapitalSeguro;
                            cot.EncargosAdministrativos = cal.EncargosAdministrativos;
                            cot.Impostos = cal.Impostos;
                            cot.Descontos = cal.Descontos;
                            cot.Agravamentos = cal.Agravamentos;
                            cot.Despesas = cal.Despesas;
                            cot.Ofertas = cal.Ofertas;
                            cot.Comissoes = cal.Comissoes;
                            cot.AgravamentosPorIdade = cal.AgravamentosPorIdade;
                            cot.DescontosPorIdade = cal.DescontosPorIdade;
                        }

                        var id = Guid.NewGuid().ToString();
                        var files = GetFileDto((context.Arguments["obj"] as Dictionary<string, object>));

                        // Retornando a resposta
                        if (files != null)
                        {
                            FileSystemManager Read = new FileSystemManager();
                            Read.CreateUserDirStruct(id as string, typeName);
                            Read.Upload($"Documento/{typeName}/{id}", files);
                            var url = $"Documento/{typeName}/{id}/";
                            var modeli = model.SetPropValue("CaminhoFicheiro", url);
                        }
                        // Criando a resposta que será resolvida
                        await Repo.AddAsync(model);
                        // RepoResponse<TModel> response;


                        // Verificando se a função está definida
                        if (param?.Add == null)
                        {
                            var rabbit = new RabbitMQClient(Repo);

                            if (rabbit.CheckConn())
                                rabbit.Send(Exchange.MQExchange, typeName, "A", model);
                        }

                        // Retornando a resposta
                        return context.Resolve(new RepoResponse<TModel> { Data = model });
                    });



            // Update Field
            FieldAsync<TGraphType>(
                    $"update{typeName}",
                    arguments: new QueryArguments(
                        Arg<NonNullGraphType<StringGraphType>>("id"),
                        Arg<NonNullGraphType<TGraphInputType>>("obj")
                    ),
                    resolve: async context =>
                    {
                        // Criando a resposta que será resolvida
                        // Criando o modelo
                        TModel model = context.GetArgument<TModel>("obj");
                        // Pegando o id do elemento
                        string id = context.GetArgument<string>("id");
                        // Verificando se a função está definida
                        await Repo.UpdateAsync(id, model);
                        if (param?.Update == null)
                        {
                            var rabbit = new RabbitMQClient(Repo);
                            if (rabbit.CheckConn())
                                rabbit.Send(Exchange.MQExchange, typeName, "A", model);
                        }
                        return context.Resolve(new RepoResponse<TModel> { Data = model });
                    });

            // Remove Field
            FieldAsync<TGraphType>(
                    $"remove{typeName}",
                    arguments: new QueryArguments(
                        Arg<NonNullGraphType<StringGraphType>>("id")
                    ),
                    resolve: async context =>
                    {
                        // Criando a resposta que será resolvida

                        // Pegando o id do elemento
                        string id = context.GetArgument<string>("id");
                        await Repo.RemoveAsync<TModel>(id);
                        // Verificando se a função está definida
                        if (param?.Remove == null)
                        {
                            var rabbit = new RabbitMQClient(Repo);
                            if (rabbit.CheckConn())
                                rabbit.Send(Exchange.MQExchange, typeName, "D", id);

                        }

                        return context.Resolve(new RepoResponse<TModel> { });
                    });
        }

        public void FieldGenericAsync<TGraphType, TGraphInputType, TModel>()
            where TGraphType : ObjectGraphType<TModel>
            where TGraphInputType : InputObjectGraphType
            where TModel : class
            => FieldAsync<TGraphType, TGraphInputType, TModel>();

        public void FieldNormalAsync<TGraphType, TGraphInputType, TModel>()
            where TGraphType : ObjectGraphType<TModel>
            where TGraphInputType : InputObjectGraphType<TModel>
            where TModel : class
            => FieldAsyncV2<TGraphType, TGraphInputType, TModel>();

    }

}