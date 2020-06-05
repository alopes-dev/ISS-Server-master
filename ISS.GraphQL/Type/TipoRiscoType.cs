using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoRiscoType : ObjectGraphType<TipoRisco>
    {
        public TipoRiscoType()
        {
            // Defining the name of the object
            Name = "tipoRisco";

            Field(x => x.IdTipoRisco, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoRisco, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<RiscoType>>("risco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Risco>(x => x.Where(e => e.HasValue(c.Source.IdTipoRisco)))));
            
        }
    }

    public class TipoRiscoInputType : InputObjectGraphType
	{
		public TipoRiscoInputType()
		{
			// Defining the name of the object
			Name = "tipoRiscoInput";
			
            //Field<StringGraphType>("idTipoRisco");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoRisco");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<RiscoInputType>>("risco");
			
		}
	}
}