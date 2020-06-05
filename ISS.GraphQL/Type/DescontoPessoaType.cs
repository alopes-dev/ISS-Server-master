using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoPessoaType : ObjectGraphType<DescontoPessoa>
    {
        public DescontoPessoaType()
        {
            // Defining the name of the object
            Name = "descontoPessoa";

            Field(x => x.IdDescontoPessoa, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            Field(x => x.CodDescontoPessoa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IdadeMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.IdadeMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.Obs, nullable: true);
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<DescontoPessoaPlanoType>>("descontoPessoaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoPessoaPlano>(x => x.Where(e => e.HasValue(c.Source.IdDescontoPessoa)))));
            
        }
    }

    public class DescontoPessoaInputType : InputObjectGraphType
	{
		public DescontoPessoaInputType()
		{
			// Defining the name of the object
			Name = "descontoPessoaInput";
			
            //Field<StringGraphType>("idDescontoPessoa");
			Field<StringGraphType>("descontoId");
			Field<StringGraphType>("codDescontoPessoa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<IntGraphType>("idadeMin");
			Field<IntGraphType>("idadeMax");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("obs");
			Field<DescontoInputType>("desconto");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<DescontoPessoaPlanoInputType>>("descontoPessoaPlano");
			
		}
	}
}