using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SectorActividadeType : ObjectGraphType<SectorActividade>
    {
        public SectorActividadeType()
        {
            // Defining the name of the object
            Name = "sectorActividade";

            Field(x => x.IdSectorActividade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoSectorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.SubSectorId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodSectorActividade, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SubSectorType>("subSector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubSector>(c.Source.SubSectorId)));
            FieldAsync<TipoSectorType>("tipoSector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSector>(c.Source.TipoSectorId)));
            FieldAsync<ListGraphType<ComissionamentoType>>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(x => x.Where(e => e.HasValue(c.Source.IdSectorActividade)))));
            FieldAsync<ListGraphType<SectorActividadeComissionamentoType>>("sectorActividadeComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadeComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdSectorActividade)))));
            FieldAsync<ListGraphType<SectorActividadePlanoType>>("sectorActividadePlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadePlano>(x => x.Where(e => e.HasValue(c.Source.IdSectorActividade)))));
            
        }
    }

    public class SectorActividadeInputType : InputObjectGraphType
	{
		public SectorActividadeInputType()
		{
			// Defining the name of the object
			Name = "sectorActividadeInput";
			
            //Field<StringGraphType>("idSectorActividade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoSectorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("subSectorId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codSectorActividade");
			Field<EstadoInputType>("estado");
			Field<SubSectorInputType>("subSector");
			Field<TipoSectorInputType>("tipoSector");
			Field<ListGraphType<ComissionamentoInputType>>("comissionamento");
			Field<ListGraphType<SectorActividadeComissionamentoInputType>>("sectorActividadeComissionamento");
			Field<ListGraphType<SectorActividadePlanoInputType>>("sectorActividadePlano");
			
		}
	}
}