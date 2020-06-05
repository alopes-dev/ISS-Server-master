using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SectorActividadeComissionamentoType : ObjectGraphType<SectorActividadeComissionamento>
    {
        public SectorActividadeComissionamentoType()
        {
            // Defining the name of the object
            Name = "sectorActividadeComissionamento";

            Field(x => x.IdSectorActividadeComissionamento, nullable: true);
            Field(x => x.CodSectorActividadeComissionamento, nullable: true);
            Field(x => x.LimitesComissionamentoProdutorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.SectorActividadeId, nullable: true);
            Field(x => x.ComissionamentoId, nullable: true);
            FieldAsync<ComissionamentoType>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(c.Source.ComissionamentoId)));
            FieldAsync<LimiteComissionamentoProdutorType>("limitesComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoProdutor>(c.Source.LimitesComissionamentoProdutorId)));
            FieldAsync<SectorActividadeType>("sectorActividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividade>(c.Source.SectorActividadeId)));
            
        }
    }

    public class SectorActividadeComissionamentoInputType : InputObjectGraphType
	{
		public SectorActividadeComissionamentoInputType()
		{
			// Defining the name of the object
			Name = "sectorActividadeComissionamentoInput";
			
            //Field<StringGraphType>("idSectorActividadeComissionamento");
			Field<StringGraphType>("codSectorActividadeComissionamento");
			Field<StringGraphType>("limitesComissionamentoProdutorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("sectorActividadeId");
			Field<StringGraphType>("comissionamentoId");
			Field<ComissionamentoInputType>("comissionamento");
			Field<LimiteComissionamentoProdutorInputType>("limitesComissionamentoProdutor");
			Field<SectorActividadeInputType>("sectorActividade");
			
		}
	}
}