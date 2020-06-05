using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OutrosSegurosType : ObjectGraphType<OutrosSeguros>
    {
        public OutrosSegurosType()
        {
            // Defining the name of the object
            Name = "outrosSeguros";

            Field(x => x.IdOutrosSeguros, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.OutraSeguradora, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NumeroApolice, nullable: true, type: typeof(IntGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<BoletimAdesaoSaudeType>>("boletimAdesaoSaude", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BoletimAdesaoSaude>(x => x.Where(e => e.HasValue(c.Source.IdOutrosSeguros)))));
            
        }
    }

    public class OutrosSegurosInputType : InputObjectGraphType
	{
		public OutrosSegurosInputType()
		{
			// Defining the name of the object
			Name = "outrosSegurosInput";
			
            //Field<StringGraphType>("idOutrosSeguros");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("outraSeguradora");
			Field<StringGraphType>("estadoId");
			Field<IntGraphType>("numeroApolice");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<BoletimAdesaoSaudeInputType>>("boletimAdesaoSaude");
			
		}
	}
}