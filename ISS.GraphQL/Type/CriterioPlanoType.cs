using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CriterioPlanoType : ObjectGraphType<CriterioPlano>
    {
        public CriterioPlanoType()
        {
            // Defining the name of the object
            Name = "criterioPlano";

            Field(x => x.IdCriterioPlano, nullable: true);
            Field(x => x.ProvinciaPlanoId, nullable: true);
            Field(x => x.CodCriterioPlano, nullable: true);
            Field(x => x.TipoSegmentoPlanoId, nullable: true);
            Field(x => x.SectorActividadePlano, nullable: true);
            Field(x => x.CanalPlanoId, nullable: true);
            Field(x => x.FormaPagamentoPlano, nullable: true);
            Field(x => x.PremioMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PapelPlanoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CanalPlanoType>("canalPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalPlano>(c.Source.CanalPlanoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoPlanoType>("formaPagamentoPlanoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamentoPlano>(c.Source.FormaPagamentoPlano)));
            FieldAsync<PapelPlanoType>("papelPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPlano>(c.Source.PapelPlanoId)));
            FieldAsync<ProvinciaPlanoType>("provinciaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciaPlano>(c.Source.ProvinciaPlanoId)));
            FieldAsync<SectorActividadePlanoType>("sectorActividadePlanoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadePlano>(c.Source.SectorActividadePlano)));
            FieldAsync<TipoSegmentoPlanoType>("tipoSegmentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoPlano>(c.Source.TipoSegmentoPlanoId)));
            
        }
    }

    public class CriterioPlanoInputType : InputObjectGraphType
	{
		public CriterioPlanoInputType()
		{
			// Defining the name of the object
			Name = "criterioPlanoInput";
			
            //Field<StringGraphType>("idCriterioPlano");
			Field<StringGraphType>("provinciaPlanoId");
			Field<StringGraphType>("codCriterioPlano");
			Field<StringGraphType>("tipoSegmentoPlanoId");
			Field<StringGraphType>("sectorActividadePlano");
			Field<StringGraphType>("canalPlanoId");
			Field<StringGraphType>("formaPagamentoPlano");
			Field<FloatGraphType>("premioMin");
			Field<FloatGraphType>("premioMax");
			Field<StringGraphType>("papelPlanoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CanalPlanoInputType>("canalPlano");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoPlanoInputType>("formaPagamentoPlanoNavigation");
			Field<PapelPlanoInputType>("papelPlano");
			Field<ProvinciaPlanoInputType>("provinciaPlano");
			Field<SectorActividadePlanoInputType>("sectorActividadePlanoNavigation");
			Field<TipoSegmentoPlanoInputType>("tipoSegmentoPlano");
			
		}
	}
}