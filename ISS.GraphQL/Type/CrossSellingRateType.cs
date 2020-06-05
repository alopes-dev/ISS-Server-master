using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CrossSellingRateType : ObjectGraphType<CrossSellingRate>
    {
        public CrossSellingRateType()
        {
            // Defining the name of the object
            Name = "crossSellingRate";

            Field(x => x.IdCrossSellingRate, nullable: true);
            Field(x => x.Rate, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CrossSellingId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CrossSellingType>("crossSelling", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CrossSelling>(c.Source.CrossSellingId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CrossSellingRateInputType : InputObjectGraphType
	{
		public CrossSellingRateInputType()
		{
			// Defining the name of the object
			Name = "crossSellingRateInput";
			
            //Field<StringGraphType>("idCrossSellingRate");
			Field<FloatGraphType>("rate");
			Field<StringGraphType>("crossSellingId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CrossSellingInputType>("crossSelling");
			Field<EstadoInputType>("estado");
			
		}
	}
}