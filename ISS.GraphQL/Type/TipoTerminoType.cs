using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoTerminoType : ObjectGraphType<TipoTermino>
    {
        public TipoTerminoType()
        {
            // Defining the name of the object
            Name = "tipoTermino";

            Field(x => x.IdTipoTermino, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodTipoTermino, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<FormaTerminoType>>("formaTermino", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaTermino>(x => x.Where(e => e.HasValue(c.Source.IdTipoTermino)))));
            
        }
    }

    public class TipoTerminoInputType : InputObjectGraphType
	{
		public TipoTerminoInputType()
		{
			// Defining the name of the object
			Name = "tipoTerminoInput";
			
            //Field<StringGraphType>("idTipoTermino");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codTipoTermino");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<FormaTerminoInputType>>("formaTermino");
			
		}
	}
}