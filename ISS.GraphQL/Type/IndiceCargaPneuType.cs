using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class IndiceCargaPneuType : ObjectGraphType<IndiceCargaPneu>
    {
        public IndiceCargaPneuType()
        {
            // Defining the name of the object
            Name = "indiceCargaPneu";

            Field(x => x.IdIndiceCargaPneu, nullable: true);
            Field(x => x.Indice, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Carga, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodIndiceCargaPneu, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PneuType>>("pneu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pneu>(x => x.Where(e => e.HasValue(c.Source.IdIndiceCargaPneu)))));
            
        }
    }

    public class IndiceCargaPneuInputType : InputObjectGraphType
	{
		public IndiceCargaPneuInputType()
		{
			// Defining the name of the object
			Name = "indiceCargaPneuInput";
			
            //Field<StringGraphType>("idIndiceCargaPneu");
			Field<IntGraphType>("indice");
			Field<IntGraphType>("carga");
			Field<StringGraphType>("codIndiceCargaPneu");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PneuInputType>>("pneu");
			
		}
	}
}