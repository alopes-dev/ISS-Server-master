using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExclusoesSelecionadaApoliceType : ObjectGraphType<ExclusoesSelecionadaApolice>
    {
        public ExclusoesSelecionadaApoliceType()
        {
            // Defining the name of the object
            Name = "exclusoesSelecionadaApolice";

            Field(x => x.IdExclusoesSelecionadaApolice, nullable: true);
            Field(x => x.CodExclusoesSelecionadaApolice, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.ExclusoesId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ExclusoesType>("exclusoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exclusoes>(c.Source.ExclusoesId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class ExclusoesSelecionadaApoliceInputType : InputObjectGraphType
	{
		public ExclusoesSelecionadaApoliceInputType()
		{
			// Defining the name of the object
			Name = "exclusoesSelecionadaApoliceInput";
			
            //Field<StringGraphType>("idExclusoesSelecionadaApolice");
			Field<StringGraphType>("codExclusoesSelecionadaApolice");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("exclusoesId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ExclusoesInputType>("exclusoes");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}