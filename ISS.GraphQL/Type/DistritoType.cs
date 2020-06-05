using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DistritoType : ObjectGraphType<Distrito>
    {
        public DistritoType()
        {
            // Defining the name of the object
            Name = "distrito";

            Field(x => x.IdDistrito, nullable: true);
            Field(x => x.NomeDistrito, nullable: true);
            Field(x => x.MunicipioId, nullable: true);
            Field(x => x.CodDistrito, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MunicipioType>("municipio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Municipio>(c.Source.MunicipioId)));
            FieldAsync<ListGraphType<BairroType>>("bairro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Bairro>(x => x.Where(e => e.HasValue(c.Source.IdDistrito)))));
            FieldAsync<ListGraphType<BalcaoType>>("balcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Balcao>(x => x.Where(e => e.HasValue(c.Source.IdDistrito)))));
            FieldAsync<ListGraphType<LocaisDescontoType>>("locaisDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisDesconto>(x => x.Where(e => e.HasValue(c.Source.IdDistrito)))));
            FieldAsync<ListGraphType<LocaisEncargoType>>("locaisEncargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisEncargo>(x => x.Where(e => e.HasValue(c.Source.IdDistrito)))));
            FieldAsync<ListGraphType<LocaisFranquiaType>>("locaisFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisFranquia>(x => x.Where(e => e.HasValue(c.Source.IdDistrito)))));
            FieldAsync<ListGraphType<LocaisImpostoType>>("locaisImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisImposto>(x => x.Where(e => e.HasValue(c.Source.IdDistrito)))));
            FieldAsync<ListGraphType<LocaisLimiteCompetenciaType>>("locaisLimiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisLimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdDistrito)))));
            FieldAsync<ListGraphType<LocaisObjectivosComerciaisType>>("locaisObjectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdDistrito)))));
            FieldAsync<ListGraphType<LocaisOfertaType>>("locaisOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisOferta>(x => x.Where(e => e.HasValue(c.Source.IdDistrito)))));
            
        }
    }

    public class DistritoInputType : InputObjectGraphType
	{
		public DistritoInputType()
		{
			// Defining the name of the object
			Name = "distritoInput";
			
            //Field<StringGraphType>("idDistrito");
			Field<StringGraphType>("nomeDistrito");
			Field<StringGraphType>("municipioId");
			Field<StringGraphType>("codDistrito");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<MunicipioInputType>("municipio");
			Field<ListGraphType<BairroInputType>>("bairro");
			Field<ListGraphType<BalcaoInputType>>("balcao");
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