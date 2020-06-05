using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoberturaType : ObjectGraphType<Cobertura>
    {
        public CoberturaType()
        {
            // Defining the name of the object
            Name = "cobertura";

            Field(x => x.IdCobertura, nullable: true);
            Field(x => x.DescricaoCobertura, nullable: true);
            Field(x => x.DataEfectividadeCobertura, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataTerminoCobertura, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CooPagamentoMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CooPagamentoMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaCooPagamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CoberturaAdicional, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CoberturaRenovavel, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CustoCoberturaQualificado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.NumReivindicacoesPermitidas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CoberturaSujeitaCoSeguro, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CoberturaDeveEstarRenovacao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CoberturaSolicitada, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ForneceValorResgateEmDinheiro, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.SubContratentesCobertos, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PercentagemDentroRede, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PercentagemForaRede, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.CodCoberturaProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Obs, nullable: true);
            Field(x => x.LimiteIndemnizacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsPadrao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.CodDesconto, nullable: true);
            Field(x => x.FranquiaId, nullable: true);
            Field(x => x.Capital, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PercentagemMinimaForaRede, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PercentagemMaximaForaRede, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoCoberturaId, nullable: true);
            Field(x => x.FormaReparacaoId, nullable: true);
            Field(x => x.Selecionavel, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaReparacaoType>("formaReparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaReparacao>(c.Source.FormaReparacaoId)));
            FieldAsync<FranquiaType>("franquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Franquia>(c.Source.FranquiaId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            FieldAsync<ListGraphType<BeneficioCoberturaType>>("beneficioCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BeneficioCobertura>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<CoberturaCosseguroType>>("coberturaCosseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaCosseguro>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<CoberturaPlanoType>>("coberturaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaPlano>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<CoberturaResseguroType>>("coberturaResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaResseguro>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<DespesaType>>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<DespesaPlanoType>>("despesaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DespesaPlano>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<DocumentosCoberturasType>>("documentosCoberturas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosCoberturas>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<ExclusoesCoberturaType>>("exclusoesCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExclusoesCobertura>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<GarantiasCoberturaType>>("garantiasCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GarantiasCobertura>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<LimiteCoberturaType>>("limiteCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteCobertura>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<NivelRiscoCoberturaType>>("nivelRiscoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRiscoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<RiscosExcluidosType>>("riscosExcluidos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RiscosExcluidos>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<ServicosAdicionaisType>>("servicosAdicionais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ServicosAdicionais>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<ServicosBaseType>>("servicosBase", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ServicosBase>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<SobrePremioCoberturaAdicionalType>>("sobrePremioCoberturaAdicionalCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SobrePremioCoberturaAdicional>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            FieldAsync<ListGraphType<SobrePremioCoberturaAdicionalType>>("sobrePremioCoberturaAdicionalCoberturaAdicional", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SobrePremioCoberturaAdicional>(x => x.Where(e => e.HasValue(c.Source.IdCobertura)))));
            
        }
    }

    public class CoberturaInputType : InputObjectGraphType
	{
		public CoberturaInputType()
		{
			// Defining the name of the object
			Name = "coberturaInput";
			
            //Field<StringGraphType>("idCobertura");
			Field<StringGraphType>("descricaoCobertura");
			Field<DateTimeGraphType>("dataEfectividadeCobertura");
			Field<DateTimeGraphType>("dataTerminoCobertura");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<FloatGraphType>("cooPagamentoMin");
			Field<FloatGraphType>("cooPagamentoMax");
			Field<FloatGraphType>("taxaCooPagamento");
			Field<BooleanGraphType>("coberturaAdicional");
			Field<BooleanGraphType>("coberturaRenovavel");
			Field<BooleanGraphType>("custoCoberturaQualificado");
			Field<IntGraphType>("numReivindicacoesPermitidas");
			Field<BooleanGraphType>("coberturaSujeitaCoSeguro");
			Field<BooleanGraphType>("coberturaDeveEstarRenovacao");
			Field<BooleanGraphType>("coberturaSolicitada");
			Field<BooleanGraphType>("forneceValorResgateEmDinheiro");
			Field<BooleanGraphType>("subContratentesCobertos");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("percentagemDentroRede");
			Field<FloatGraphType>("percentagemForaRede");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("codCoberturaProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("obs");
			Field<FloatGraphType>("limiteIndemnizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<BooleanGraphType>("isPadrao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("codDesconto");
			Field<StringGraphType>("franquiaId");
			Field<FloatGraphType>("capital");
			Field<FloatGraphType>("percentagemMinimaForaRede");
			Field<FloatGraphType>("percentagemMaximaForaRede");
			Field<StringGraphType>("tipoCoberturaId");
			Field<StringGraphType>("formaReparacaoId");
			Field<BooleanGraphType>("selecionavel");
			Field<EstadoInputType>("estado");
			Field<FormaReparacaoInputType>("formaReparacao");
			Field<FranquiaInputType>("franquia");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<MoedaInputType>("moeda");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PlanoContasInputType>("subConta");
			Field<TipoCoberturaInputType>("tipoCobertura");
			Field<ListGraphType<BeneficioCoberturaInputType>>("beneficioCobertura");
			Field<ListGraphType<CoberturaCosseguroInputType>>("coberturaCosseguro");
			Field<ListGraphType<CoberturaPlanoInputType>>("coberturaPlano");
			Field<ListGraphType<CoberturaResseguroInputType>>("coberturaResseguro");
			Field<ListGraphType<DespesaInputType>>("despesa");
			Field<ListGraphType<DespesaPlanoInputType>>("despesaPlano");
			Field<ListGraphType<DocumentosCoberturasInputType>>("documentosCoberturas");
			Field<ListGraphType<ExclusoesCoberturaInputType>>("exclusoesCobertura");
			Field<ListGraphType<GarantiasCoberturaInputType>>("garantiasCobertura");
			Field<ListGraphType<LimiteCoberturaInputType>>("limiteCobertura");
			Field<ListGraphType<NivelRiscoCoberturaInputType>>("nivelRiscoCobertura");
			Field<ListGraphType<RiscosExcluidosInputType>>("riscosExcluidos");
			Field<ListGraphType<ServicosAdicionaisInputType>>("servicosAdicionais");
			Field<ListGraphType<ServicosBaseInputType>>("servicosBase");
			Field<ListGraphType<SobrePremioCoberturaAdicionalInputType>>("sobrePremioCoberturaAdicionalCobertura");
			Field<ListGraphType<SobrePremioCoberturaAdicionalInputType>>("sobrePremioCoberturaAdicionalCoberturaAdicional");
			
		}
	}
}