using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubSectorType : ObjectGraphType<SubSector>
    {
        public SubSectorType()
        {
            // Defining the name of the object
            Name = "subSector";

            Field(x => x.IdSubSector, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CaiId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodSubSector, nullable: true);
            FieldAsync<CaeType>("cai", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.CaiId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<SectorActividadeType>>("sectorActividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividade>(x => x.Where(e => e.HasValue(c.Source.IdSubSector)))));
            
        }
    }

    public class SubSectorInputType : InputObjectGraphType
	{
		public SubSectorInputType()
		{
			// Defining the name of the object
			Name = "subSectorInput";
			
            //Field<StringGraphType>("idSubSector");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("caiId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codSubSector");
			Field<CaeInputType>("cai");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<SectorActividadeInputType>>("sectorActividade");
			
		}
	}
}