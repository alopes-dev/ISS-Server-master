using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimiteComissionamentoPlanoType : ObjectGraphType<LimiteComissionamentoPlano>
    {
        public LimiteComissionamentoPlanoType()
        {
            // Defining the name of the object
            Name = "limiteComissionamentoPlano";

            Field(x => x.IdLimiteComissionamentoPlano, nullable: true);
            Field(x => x.PremioMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ProvinciaPlanoId, nullable: true);
            Field(x => x.CanalPlanoId, nullable: true);
            Field(x => x.TipoSegmentoPlanoId, nullable: true);
            Field(x => x.SectorActividadePlanoId, nullable: true);
            Field(x => x.FidelizacaoPlanoId, nullable: true);
            Field(x => x.SectorActividadePlano, nullable: true);
            Field(x => x.TaxaPercentagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCricao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CanalPlanoType>("canalPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalPlano>(c.Source.CanalPlanoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FidelizacaoPlanoType>("fidelizacaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FidelizacaoPlano>(c.Source.FidelizacaoPlanoId)));
            FieldAsync<ProvinciaPlanoType>("provinciaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciaPlano>(c.Source.ProvinciaPlanoId)));
            FieldAsync<SectorActividadePlanoType>("sectorActividadePlano1", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadePlano>(c.Source.SectorActividadePlanoId)));
            FieldAsync<SectorActividadePlanoType>("sectorActividadePlanoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadePlano>(c.Source.SectorActividadePlano)));
            FieldAsync<TipoSegmentoPlanoType>("tipoSegmentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoPlano>(c.Source.TipoSegmentoPlanoId)));
            
        }
    }

    public class LimiteComissionamentoPlanoInputType : InputObjectGraphType
	{
		public LimiteComissionamentoPlanoInputType()
		{
			// Defining the name of the object
			Name = "limiteComissionamentoPlanoInput";
			
            //Field<StringGraphType>("idLimiteComissionamentoPlano");
			Field<FloatGraphType>("premioMin");
			Field<FloatGraphType>("premioMax");
			Field<StringGraphType>("provinciaPlanoId");
			Field<StringGraphType>("canalPlanoId");
			Field<StringGraphType>("tipoSegmentoPlanoId");
			Field<StringGraphType>("sectorActividadePlanoId");
			Field<StringGraphType>("fidelizacaoPlanoId");
			Field<StringGraphType>("sectorActividadePlano");
			Field<FloatGraphType>("taxaPercentagem");
			Field<FloatGraphType>("taxaMin");
			Field<FloatGraphType>("taxaMax");
			Field<DateTimeGraphType>("dataCricao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CanalPlanoInputType>("canalPlano");
			Field<EstadoInputType>("estado");
			Field<FidelizacaoPlanoInputType>("fidelizacaoPlano");
			Field<ProvinciaPlanoInputType>("provinciaPlano");
			Field<SectorActividadePlanoInputType>("sectorActividadePlano1");
			Field<SectorActividadePlanoInputType>("sectorActividadePlanoNavigation");
			Field<TipoSegmentoPlanoInputType>("tipoSegmentoPlano");
			
		}
	}
}