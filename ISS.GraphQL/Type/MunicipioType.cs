using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MunicipioType : ObjectGraphType<Municipio>
    {
        public MunicipioType()
        {
            // Defining the name of the object
            Name = "municipio";

            Field(x => x.IdMunicipio, nullable: true);
            Field(x => x.NomeMunicipio, nullable: true);
            Field(x => x.ProvinciaId, nullable: true);
            Field(x => x.CodMunicipio, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProvinciaType>("provincia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(c.Source.ProvinciaId)));
            FieldAsync<ListGraphType<DistritoType>>("distrito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Distrito>(x => x.Where(e => e.HasValue(c.Source.IdMunicipio)))));
            FieldAsync<ListGraphType<LocaisDescontoType>>("locaisDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisDesconto>(x => x.Where(e => e.HasValue(c.Source.IdMunicipio)))));
            FieldAsync<ListGraphType<LocaisEncargoType>>("locaisEncargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisEncargo>(x => x.Where(e => e.HasValue(c.Source.IdMunicipio)))));
            FieldAsync<ListGraphType<LocaisFranquiaType>>("locaisFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisFranquia>(x => x.Where(e => e.HasValue(c.Source.IdMunicipio)))));
            FieldAsync<ListGraphType<LocaisImpostoType>>("locaisImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisImposto>(x => x.Where(e => e.HasValue(c.Source.IdMunicipio)))));
            FieldAsync<ListGraphType<LocaisLimiteCompetenciaType>>("locaisLimiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisLimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdMunicipio)))));
            FieldAsync<ListGraphType<LocaisObjectivosComerciaisType>>("locaisObjectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdMunicipio)))));
            FieldAsync<ListGraphType<LocaisOfertaType>>("locaisOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisOferta>(x => x.Where(e => e.HasValue(c.Source.IdMunicipio)))));
            
        }
    }

    public class MunicipioInputType : InputObjectGraphType
	{
		public MunicipioInputType()
		{
			// Defining the name of the object
			Name = "municipioInput";
			
            //Field<StringGraphType>("idMunicipio");
			Field<StringGraphType>("nomeMunicipio");
			Field<StringGraphType>("provinciaId");
			Field<StringGraphType>("codMunicipio");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ProvinciaInputType>("provincia");
			Field<ListGraphType<DistritoInputType>>("distrito");
			Field<ListGraphType<LocaisDescontoInputType>>("locaisDesconto");
			Field<ListGraphType<LocaisEncargoInputType>>("locaisEncargo");
			Field<ListGraphType<LocaisFranquiaInputType>>("locaisFranquia");
			Field<ListGraphType<LocaisImpostoInputType>>("locaisImposto");
			Field<ListGraphType<LocaisLimiteCompetenciaInputType>>("locaisLimiteCompetencia");
			Field<ListGraphType<LocaisObjectivosComerciaisInputType>>("locaisObjectivosComerciais");
			Field<ListGraphType<LocaisOfertaInputType>>("locaisOferta");
			
		}
	}
}