using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CaraterizacaoEventualType : ObjectGraphType<CaraterizacaoEventual>
    {
        public CaraterizacaoEventualType()
        {
            // Defining the name of the object
            Name = "caraterizacaoEventual";

            Field(x => x.IdCaraterizacaoEventual, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCaraterizacaoEventual, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.NumOrdem, nullable: true, type: typeof(IntGraphType));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class CaraterizacaoEventualInputType : InputObjectGraphType
	{
		public CaraterizacaoEventualInputType()
		{
			// Defining the name of the object
			Name = "caraterizacaoEventualInput";
			
            //Field<StringGraphType>("idCaraterizacaoEventual");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCaraterizacaoEventual");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("planoProdutoId");
			Field<IntGraphType>("numOrdem");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}