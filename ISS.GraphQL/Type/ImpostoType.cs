using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ImpostoType : ObjectGraphType<Imposto>
    {
        public ImpostoType()
        {
            // Defining the name of the object
            Name = "imposto";

            Field(x => x.IdImposto, nullable: true);
            Field(x => x.TaxaImposto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoImpostoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodImposto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsIndirecto, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.OperaccoesPagamentoId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.TipoRamoSeguroId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<OperaccoesPagamentoType>("operaccoesPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperaccoesPagamento>(c.Source.OperaccoesPagamentoId)));
            FieldAsync<TipoImpostoType>("tipoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoImposto>(c.Source.TipoImpostoId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<TipoRamoSeguroType>("tipoRamoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRamoSeguro>(c.Source.TipoRamoSeguroId)));
            FieldAsync<ListGraphType<ImpostoLinhaType>>("impostoLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoLinha>(x => x.Where(e => e.HasValue(c.Source.IdImposto)))));
            FieldAsync<ListGraphType<ImpostoPlanoType>>("impostoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoPlano>(x => x.Where(e => e.HasValue(c.Source.IdImposto)))));
            FieldAsync<ListGraphType<ImpostoPrecarioType>>("impostoPrecario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoPrecario>(x => x.Where(e => e.HasValue(c.Source.IdImposto)))));
            FieldAsync<ListGraphType<ImpostoTipoContaType>>("impostoTipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoTipoConta>(x => x.Where(e => e.HasValue(c.Source.IdImposto)))));
            FieldAsync<ListGraphType<ImpostoTipoDocumentosType>>("impostoTipoDocumentos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoTipoDocumentos>(x => x.Where(e => e.HasValue(c.Source.IdImposto)))));
            FieldAsync<ListGraphType<LinhaProdutoImpostoType>>("linhaProdutoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProdutoImposto>(x => x.Where(e => e.HasValue(c.Source.IdImposto)))));
            FieldAsync<ListGraphType<LocaisImpostoType>>("locaisImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisImposto>(x => x.Where(e => e.HasValue(c.Source.IdImposto)))));
            
        }
    }

    public class ImpostoInputType : InputObjectGraphType
	{
		public ImpostoInputType()
		{
			// Defining the name of the object
			Name = "impostoInput";
			
            //Field<StringGraphType>("idImposto");
			Field<FloatGraphType>("taxaImposto");
			Field<StringGraphType>("tipoImpostoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codImposto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isIndirecto");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("operaccoesPagamentoId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<StringGraphType>("tipoRamoSeguroId");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<OperaccoesPagamentoInputType>("operaccoesPagamento");
			Field<TipoImpostoInputType>("tipoImposto");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<TipoRamoSeguroInputType>("tipoRamoSeguro");
			Field<ListGraphType<ImpostoLinhaInputType>>("impostoLinha");
			Field<ListGraphType<ImpostoPlanoInputType>>("impostoPlano");
			Field<ListGraphType<ImpostoPrecarioInputType>>("impostoPrecario");
			Field<ListGraphType<ImpostoTipoContaInputType>>("impostoTipoConta");
			Field<ListGraphType<ImpostoTipoDocumentosInputType>>("impostoTipoDocumentos");
			Field<ListGraphType<LinhaProdutoImpostoInputType>>("linhaProdutoImposto");
			Field<ListGraphType<LocaisImpostoInputType>>("locaisImposto");
			
		}
	}
}