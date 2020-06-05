using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SectorAtividadeEconomicaType : ObjectGraphType<SectorAtividadeEconomica>
    {
        public SectorAtividadeEconomicaType()
        {
            // Defining the name of the object
            Name = "sectorAtividadeEconomica";

            Field(x => x.IdSectorAtividadeEconomica, nullable: true);
            Field(x => x.CodSectorAtividadeEconomica, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.TipoEntidadeId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoEntidadeType>("tipoEntidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEntidade>(c.Source.TipoEntidadeId)));
            FieldAsync<ListGraphType<CaeType>>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(x => x.Where(e => e.HasValue(c.Source.IdSectorAtividadeEconomica)))));
            FieldAsync<ListGraphType<SectorActividadesProdutorType>>("sectorActividadesProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadesProdutor>(x => x.Where(e => e.HasValue(c.Source.IdSectorAtividadeEconomica)))));
            
        }
    }

    public class SectorAtividadeEconomicaInputType : InputObjectGraphType
	{
		public SectorAtividadeEconomicaInputType()
		{
			// Defining the name of the object
			Name = "sectorAtividadeEconomicaInput";
			
            //Field<StringGraphType>("idSectorAtividadeEconomica");
			Field<StringGraphType>("codSectorAtividadeEconomica");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("tipoEntidadeId");
			Field<EstadoInputType>("estado");
			Field<TipoEntidadeInputType>("tipoEntidade");
			Field<ListGraphType<CaeInputType>>("cae");
			Field<ListGraphType<SectorActividadesProdutorInputType>>("sectorActividadesProdutor");
			
		}
	}
}