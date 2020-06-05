using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FuncaoType : ObjectGraphType<Funcao>
    {
        public FuncaoType()
        {
            // Defining the name of the object
            Name = "funcao";

            Field(x => x.IdFuncao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFuncao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NivelAcessoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NivelAcessoType>("nivelAcesso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelAcesso>(c.Source.NivelAcessoId)));
            FieldAsync<ListGraphType<ActividadeType>>("actividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Actividade>(x => x.Where(e => e.HasValue(c.Source.IdFuncao)))));
            FieldAsync<ListGraphType<FuncaoDependenteType>>("funcaoDependenteFuncaoDependenteNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FuncaoDependente>(x => x.Where(e => e.HasValue(c.Source.IdFuncao)))));
            FieldAsync<ListGraphType<FuncaoDependenteType>>("funcaoDependenteFuncaoMae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FuncaoDependente>(x => x.Where(e => e.HasValue(c.Source.IdFuncao)))));
            FieldAsync<ListGraphType<FuncionarioType>>("funcionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(x => x.Where(e => e.HasValue(c.Source.IdFuncao)))));
            FieldAsync<ListGraphType<LimiteCompetenciaType>>("limiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdFuncao)))));
            FieldAsync<ListGraphType<OperacoesCrudpessoaType>>("operacoesCrudpessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesCrudpessoa>(x => x.Where(e => e.HasValue(c.Source.IdFuncao)))));
            FieldAsync<ListGraphType<PessoaProfissaoType>>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(x => x.Where(e => e.HasValue(c.Source.IdFuncao)))));
            FieldAsync<ListGraphType<PosicaoType>>("posicao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Posicao>(x => x.Where(e => e.HasValue(c.Source.IdFuncao)))));
            FieldAsync<ListGraphType<SeccaoType>>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(x => x.Where(e => e.HasValue(c.Source.IdFuncao)))));
            
        }
    }

    public class FuncaoInputType : InputObjectGraphType
	{
		public FuncaoInputType()
		{
			// Defining the name of the object
			Name = "funcaoInput";
			
            //Field<StringGraphType>("idFuncao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFuncao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("nivelAcessoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<NivelAcessoInputType>("nivelAcesso");
			Field<ListGraphType<ActividadeInputType>>("actividade");
			Field<ListGraphType<FuncaoDependenteInputType>>("funcaoDependenteFuncaoDependenteNavigation");
			Field<ListGraphType<FuncaoDependenteInputType>>("funcaoDependenteFuncaoMae");
			Field<ListGraphType<FuncionarioInputType>>("funcionario");
			Field<ListGraphType<LimiteCompetenciaInputType>>("limiteCompetencia");
			Field<ListGraphType<OperacoesCrudpessoaInputType>>("operacoesCrudpessoa");
			Field<ListGraphType<PessoaProfissaoInputType>>("pessoaProfissao");
			Field<ListGraphType<PosicaoInputType>>("posicao");
			Field<ListGraphType<SeccaoInputType>>("seccao");
			
		}
	}
}