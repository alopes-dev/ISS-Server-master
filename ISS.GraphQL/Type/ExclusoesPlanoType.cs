using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExclusoesPlanoType : ObjectGraphType<ExclusoesPlano>
    {
        public ExclusoesPlanoType()
        {
            // Defining the name of the object
            Name = "exclusoesPlano";

            Field(x => x.IdExclusoesPlano, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodExclusoesPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.ExclusaoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ExclusoesType>("exclusao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exclusoes>(c.Source.ExclusaoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class ExclusoesPlanoInputType : InputObjectGraphType
	{
		public ExclusoesPlanoInputType()
		{
			// Defining the name of the object
			Name = "exclusoesPlanoInput";
			
            //Field<StringGraphType>("idExclusoesPlano");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codExclusoesPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("exclusaoId");
			Field<EstadoInputType>("estado");
			Field<ExclusoesInputType>("exclusao");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}