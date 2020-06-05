using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EncargosType : ObjectGraphType<Encargos>
    {
        public EncargosType()
        {
            // Defining the name of the object
            Name = "encargos";

            Field(x => x.IdEncargo, nullable: true);
            Field(x => x.TipoEncargoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TaxaEncargo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.CodEncargo, nullable: true);
            Field(x => x.ImpostoPrecarioId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ImpostoPrecarioType>("impostoPrecario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoPrecario>(c.Source.ImpostoPrecarioId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<TipoEncargoType>("tipoEncargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEncargo>(c.Source.TipoEncargoId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<EncargoLinhaType>>("encargoLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EncargoLinha>(x => x.Where(e => e.HasValue(c.Source.IdEncargo)))));
            FieldAsync<ListGraphType<EncargoPlanoType>>("encargoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EncargoPlano>(x => x.Where(e => e.HasValue(c.Source.IdEncargo)))));
            FieldAsync<ListGraphType<EncargosTipoContaType>>("encargosTipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EncargosTipoConta>(x => x.Where(e => e.HasValue(c.Source.IdEncargo)))));
            
        }
    }

    public class EncargosInputType : InputObjectGraphType
	{
		public EncargosInputType()
		{
			// Defining the name of the object
			Name = "encargosInput";
			
            //Field<StringGraphType>("idEncargo");
			Field<StringGraphType>("tipoEncargoId");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("taxaEncargo");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("codEncargo");
			Field<StringGraphType>("impostoPrecarioId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<EstadoInputType>("estado");
			Field<ImpostoPrecarioInputType>("impostoPrecario");
			Field<MoedaInputType>("moeda");
			Field<TipoEncargoInputType>("tipoEncargo");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<ListGraphType<EncargoLinhaInputType>>("encargoLinha");
			Field<ListGraphType<EncargoPlanoInputType>>("encargoPlano");
			Field<ListGraphType<EncargosTipoContaInputType>>("encargosTipoConta");
			
		}
	}
}