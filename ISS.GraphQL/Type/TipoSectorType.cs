using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSectorType : ObjectGraphType<TipoSector>
    {
        public TipoSectorType()
        {
            // Defining the name of the object
            Name = "tipoSector";

            Field(x => x.IdTipoSector, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodTipoSector, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<SectorActividadeType>>("sectorActividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividade>(x => x.Where(e => e.HasValue(c.Source.IdTipoSector)))));
            
        }
    }

    public class TipoSectorInputType : InputObjectGraphType
	{
		public TipoSectorInputType()
		{
			// Defining the name of the object
			Name = "tipoSectorInput";
			
            //Field<StringGraphType>("idTipoSector");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codTipoSector");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<SectorActividadeInputType>>("sectorActividade");
			
		}
	}
}