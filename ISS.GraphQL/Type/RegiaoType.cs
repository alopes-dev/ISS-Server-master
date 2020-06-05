using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RegiaoType : ObjectGraphType<Regiao>
    {
        public RegiaoType()
        {
            // Defining the name of the object
            Name = "regiao";

            Field(x => x.IdRegiao, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.CodRegiao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ClausulaType>>("clausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Clausula>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<LocaisCoberturaType>>("locaisCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisCobertura>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<LocaisDescontoType>>("locaisDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisDesconto>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<LocaisEncargoType>>("locaisEncargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisEncargo>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<LocaisFranquiaType>>("locaisFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisFranquia>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<LocaisImpostoType>>("locaisImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisImposto>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<LocaisLimiteCompetenciaType>>("locaisLimiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisLimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<LocaisObjectivosComerciaisType>>("locaisObjectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<LocaisOfertaType>>("locaisOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisOferta>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<PaisType>>("pais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            FieldAsync<ListGraphType<ProvinciaType>>("provincia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(x => x.Where(e => e.HasValue(c.Source.IdRegiao)))));
            
        }
    }

    public class RegiaoInputType : InputObjectGraphType
	{
		public RegiaoInputType()
		{
			// Defining the name of the object
			Name = "regiaoInput";
			
            //Field<StringGraphType>("idRegiao");
			Field<StringGraphType>("nome");
			Field<StringGraphType>("codRegiao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ClausulaInputType>>("clausula");
			Field<ListGraphType<LocaisCoberturaInputType>>("locaisCobertura");
			Field<ListGraphType<LocaisDescontoInputType>>("locaisDesconto");
			Field<ListGraphType<LocaisEncargoInputType>>("locaisEncargo");
			Field<ListGraphType<LocaisFranquiaInputType>>("locaisFranquia");
			Field<ListGraphType<LocaisImpostoInputType>>("locaisImposto");
			Field<ListGraphType<LocaisLimiteCompetenciaInputType>>("locaisLimiteCompetencia");
			Field<ListGraphType<LocaisObjectivosComerciaisInputType>>("locaisObjectivosComerciais");
			Field<ListGraphType<LocaisOfertaInputType>>("locaisOferta");
			Field<ListGraphType<PaisInputType>>("pais");
			Field<ListGraphType<ProvinciaInputType>>("provincia");
			
		}
	}
}