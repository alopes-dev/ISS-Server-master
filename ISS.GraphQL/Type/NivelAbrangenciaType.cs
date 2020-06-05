using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NivelAbrangenciaType : ObjectGraphType<NivelAbrangencia>
    {
        public NivelAbrangenciaType()
        {
            // Defining the name of the object
            Name = "nivelAbrangencia";

            Field(x => x.IdNivelAbrangencia, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodNivelAbrangencia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CondicaoOperacaoType>>("condicaoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoOperacao>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            FieldAsync<ListGraphType<LocaisCoberturaType>>("locaisCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisCobertura>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            FieldAsync<ListGraphType<LocaisComissaoType>>("locaisComissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisComissao>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            FieldAsync<ListGraphType<LocaisDescontoType>>("locaisDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisDesconto>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            FieldAsync<ListGraphType<LocaisEncargoType>>("locaisEncargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisEncargo>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            FieldAsync<ListGraphType<LocaisFranquiaType>>("locaisFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisFranquia>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            FieldAsync<ListGraphType<LocaisImpostoType>>("locaisImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisImposto>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            FieldAsync<ListGraphType<LocaisLimiteCompetenciaType>>("locaisLimiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisLimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            FieldAsync<ListGraphType<LocaisObjectivosComerciaisType>>("locaisObjectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            FieldAsync<ListGraphType<LocaisOfertaType>>("locaisOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisOferta>(x => x.Where(e => e.HasValue(c.Source.IdNivelAbrangencia)))));
            
        }
    }

    public class NivelAbrangenciaInputType : InputObjectGraphType
	{
		public NivelAbrangenciaInputType()
		{
			// Defining the name of the object
			Name = "nivelAbrangenciaInput";
			
            //Field<StringGraphType>("idNivelAbrangencia");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codNivelAbrangencia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CondicaoOperacaoInputType>>("condicaoOperacao");
			Field<ListGraphType<LocaisCoberturaInputType>>("locaisCobertura");
			Field<ListGraphType<LocaisComissaoInputType>>("locaisComissao");
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