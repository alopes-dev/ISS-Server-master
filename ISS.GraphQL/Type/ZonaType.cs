using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ZonaType : ObjectGraphType<Zona>
    {
        public ZonaType()
        {
            // Defining the name of the object
            Name = "zona";

            Field(x => x.IdZona, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodZona, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Obs, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ImpostoPrecarioType>>("impostoPrecario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoPrecario>(x => x.Where(e => e.HasValue(c.Source.IdZona)))));
            FieldAsync<ListGraphType<ZonaPeriodoCoberturaType>>("zonaPeriodoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ZonaPeriodoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdZona)))));
            
        }
    }

    public class ZonaInputType : InputObjectGraphType
	{
		public ZonaInputType()
		{
			// Defining the name of the object
			Name = "zonaInput";
			
            //Field<StringGraphType>("idZona");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codZona");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("obs");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ImpostoPrecarioInputType>>("impostoPrecario");
			Field<ListGraphType<ZonaPeriodoCoberturaInputType>>("zonaPeriodoCobertura");
			
		}
	}
}