using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocaisImpostoType : ObjectGraphType<LocaisImposto>
    {
        public LocaisImpostoType()
        {
            // Defining the name of the object
            Name = "locaisImposto";

            Field(x => x.IdLocaisImposto, nullable: true);
            Field(x => x.RegiaoId, nullable: true);
            Field(x => x.PaisId, nullable: true);
            Field(x => x.ProvinciaId, nullable: true);
            Field(x => x.MunicipioId, nullable: true);
            Field(x => x.DistritoId, nullable: true);
            Field(x => x.NivelAbrangenciaId, nullable: true);
            Field(x => x.ImpostoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<DistritoType>("distrito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Distrito>(c.Source.DistritoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ImpostoType>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(c.Source.ImpostoId)));
            FieldAsync<MunicipioType>("municipio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Municipio>(c.Source.MunicipioId)));
            FieldAsync<NivelAbrangenciaType>("nivelAbrangencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelAbrangencia>(c.Source.NivelAbrangenciaId)));
            FieldAsync<PaisType>("pais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisId)));
            FieldAsync<ProvinciaType>("provincia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(c.Source.ProvinciaId)));
            FieldAsync<RegiaoType>("regiao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Regiao>(c.Source.RegiaoId)));
            
        }
    }

    public class LocaisImpostoInputType : InputObjectGraphType
	{
		public LocaisImpostoInputType()
		{
			// Defining the name of the object
			Name = "locaisImpostoInput";
			
            //Field<StringGraphType>("idLocaisImposto");
			Field<StringGraphType>("regiaoId");
			Field<StringGraphType>("paisId");
			Field<StringGraphType>("provinciaId");
			Field<StringGraphType>("municipioId");
			Field<StringGraphType>("distritoId");
			Field<StringGraphType>("nivelAbrangenciaId");
			Field<StringGraphType>("impostoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<DistritoInputType>("distrito");
			Field<EstadoInputType>("estado");
			Field<ImpostoInputType>("imposto");
			Field<MunicipioInputType>("municipio");
			Field<NivelAbrangenciaInputType>("nivelAbrangencia");
			Field<PaisInputType>("pais");
			Field<ProvinciaInputType>("provincia");
			Field<RegiaoInputType>("regiao");
			
		}
	}
}