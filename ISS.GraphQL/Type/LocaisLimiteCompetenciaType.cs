using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocaisLimiteCompetenciaType : ObjectGraphType<LocaisLimiteCompetencia>
    {
        public LocaisLimiteCompetenciaType()
        {
            // Defining the name of the object
            Name = "locaisLimiteCompetencia";

            Field(x => x.IdLocaisLimiteCompetencia, nullable: true);
            Field(x => x.RegiaoId, nullable: true);
            Field(x => x.PaisId, nullable: true);
            Field(x => x.ProvinciaId, nullable: true);
            Field(x => x.MunicipioId, nullable: true);
            Field(x => x.DistritoId, nullable: true);
            Field(x => x.NivelAbrangenciaId, nullable: true);
            Field(x => x.LimiteCompetenciaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<DistritoType>("distrito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Distrito>(c.Source.DistritoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LimiteCompetenciaType>("limiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteCompetencia>(c.Source.LimiteCompetenciaId)));
            FieldAsync<MunicipioType>("municipio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Municipio>(c.Source.MunicipioId)));
            FieldAsync<NivelAbrangenciaType>("nivelAbrangencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelAbrangencia>(c.Source.NivelAbrangenciaId)));
            FieldAsync<PaisType>("pais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisId)));
            FieldAsync<ProvinciaType>("provincia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(c.Source.ProvinciaId)));
            FieldAsync<RegiaoType>("regiao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Regiao>(c.Source.RegiaoId)));
            
        }
    }

    public class LocaisLimiteCompetenciaInputType : InputObjectGraphType
	{
		public LocaisLimiteCompetenciaInputType()
		{
			// Defining the name of the object
			Name = "locaisLimiteCompetenciaInput";
			
            //Field<StringGraphType>("idLocaisLimiteCompetencia");
			Field<StringGraphType>("regiaoId");
			Field<StringGraphType>("paisId");
			Field<StringGraphType>("provinciaId");
			Field<StringGraphType>("municipioId");
			Field<StringGraphType>("distritoId");
			Field<StringGraphType>("nivelAbrangenciaId");
			Field<StringGraphType>("limiteCompetenciaId");
			Field<StringGraphType>("estadoId");
			Field<DistritoInputType>("distrito");
			Field<EstadoInputType>("estado");
			Field<LimiteCompetenciaInputType>("limiteCompetencia");
			Field<MunicipioInputType>("municipio");
			Field<NivelAbrangenciaInputType>("nivelAbrangencia");
			Field<PaisInputType>("pais");
			Field<ProvinciaInputType>("provincia");
			Field<RegiaoInputType>("regiao");
			
		}
	}
}