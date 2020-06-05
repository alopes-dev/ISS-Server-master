using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LinhaProdutoType : ObjectGraphType<LinhaProduto>
    {
        public LinhaProdutoType()
        {
            // Defining the name of the object
            Name = "linhaProduto";

            Field(x => x.IdLinhaProduto, nullable: true);
            Field(x => x.AmbitoLinhaProduto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CaminhoUrl, nullable: true);
            Field(x => x.CodLinhaProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoUniExpostaRisco, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CaminhoWeb, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.IsSite, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.NumOrdemProdutoSite, nullable: true, type: typeof(IntGraphType));
            Field(x => x.IsParaEmpresa, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<AgravamentoLinhaType>>("agravamentoLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoLinha>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<AgravamentoPessoaType>>("agravamentoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ArtigoType>>("artigo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Artigo>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<CoberturaType>>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<CondicoesProdutoType>>("condicoesProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicoesProduto>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<DescontoLinhaType>>("descontoLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoLinha>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<DespesaLinhaType>>("despesaLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DespesaLinha>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<DocumentosNecessarioPorLinhaType>>("documentosNecessarioPorLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosNecessarioPorLinha>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<DocumentosObrigatorioProdutoType>>("documentosObrigatorioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosObrigatorioProduto>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<EncargoLinhaType>>("encargoLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EncargoLinha>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ExclusoesType>>("exclusoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exclusoes>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ExclusoesPlanoType>>("exclusoesPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExclusoesPlano>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ExclusoesSelecionadaLinhaProdutoType>>("exclusoesSelecionadaLinhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExclusoesSelecionadaLinhaProduto>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<FactorRiscoType>>("factorRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FactorRisco>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<GarantiaPlanoType>>("garantiaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GarantiaPlano>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<GlossarioType>>("glossario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Glossario>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ImagemProdutoType>>("imagemProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImagemProduto>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ImpostoLinhaType>>("impostoLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoLinha>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<IncapacidadeTemporariaType>>("incapacidadeTemporaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IncapacidadeTemporaria>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<InformacaoSuporteType>>("informacaoSuporte", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoSuporte>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<LinhaProdutoImpostoType>>("linhaProdutoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProdutoImposto>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<MapaType>>("mapa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Mapa>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<MediacaoComissaoType>>("mediacaoComissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MediacaoComissao>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<MotivoViagemType>>("motivoViagem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MotivoViagem>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ObjectivoProdutoType>>("objectivoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectivoProduto>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ObjectivosComerciaisType>>("objectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ObrigacoesProdutoType>>("obrigacoesProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObrigacoesProduto>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<OfertaLinhaType>>("ofertaLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OfertaLinha>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<PerguntasType>>("perguntas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perguntas>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<PessoaTarefaType>>("pessoaTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaTarefa>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<PlanoObjectivoComercialType>>("planoObjectivoComercial", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoObjectivoComercial>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<PlanoProdutoType>>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<PontosClausulaType>>("pontosClausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PontosClausula>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<PrazosCurtosType>>("prazosCurtos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrazosCurtos>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<PremiosMinimosType>>("premiosMinimos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PremiosMinimos>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<QuadroDanosType>>("quadroDanos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<QuadroDanos>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ReducoesAutorizadasType>>("reducoesAutorizadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReducoesAutorizadas>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ReservasTecnicasType>>("reservasTecnicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReservasTecnicas>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<RiscoType>>("risco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Risco>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<SubRamoType>>("subRamo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubRamo>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<TarifaType>>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<TarifasAutomovelType>>("tarifasAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<TarifasPremioAutoAcidentesTrabalhoType>>("tarifasPremioAutoAcidentesTrabalho", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasPremioAutoAcidentesTrabalho>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<TarifasPremioAutoAt2Type>>("tarifasPremioAutoAt2", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasPremioAutoAt2>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<TaxaSinistralidadeType>>("taxaSinistralidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TaxaSinistralidade>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<TipoApoliceType>>("tipoApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoApolice>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<TipoCoberturaType>>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<TipoContaType>>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<VantagemProdutoType>>("vantagemProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<VantagemProduto>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            FieldAsync<ListGraphType<ZonaPeriodoCoberturaType>>("zonaPeriodoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ZonaPeriodoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdLinhaProduto)))));
            
        }
    }

    public class LinhaProdutoInputType : InputObjectGraphType
	{
		public LinhaProdutoInputType()
		{
			// Defining the name of the object
			Name = "linhaProdutoInput";
			
            //Field<StringGraphType>("idLinhaProduto");
			Field<StringGraphType>("ambitoLinhaProduto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("caminhoUrl");
			Field<StringGraphType>("codLinhaProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("tipoUniExpostaRisco");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("subContaId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("caminhoWeb");
			Field<StringGraphType>("caminhoIcone");
			Field<BooleanGraphType>("isSite");
			Field<IntGraphType>("numOrdemProdutoSite");
			Field<BooleanGraphType>("isParaEmpresa");
			Field<EstadoInputType>("estado");
			Field<ProdutoInputType>("produto");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<AgravamentoLinhaInputType>>("agravamentoLinha");
			Field<ListGraphType<AgravamentoPessoaInputType>>("agravamentoPessoa");
			Field<ListGraphType<ArtigoInputType>>("artigo");
			Field<ListGraphType<CoberturaInputType>>("cobertura");
			Field<ListGraphType<CondicoesProdutoInputType>>("condicoesProduto");
			Field<ListGraphType<DescontoLinhaInputType>>("descontoLinha");
			Field<ListGraphType<DespesaLinhaInputType>>("despesaLinha");
			Field<ListGraphType<DocumentosNecessarioPorLinhaInputType>>("documentosNecessarioPorLinha");
			Field<ListGraphType<DocumentosObrigatorioProdutoInputType>>("documentosObrigatorioProduto");
			Field<ListGraphType<EncargoLinhaInputType>>("encargoLinha");
			Field<ListGraphType<ExclusoesInputType>>("exclusoes");
			Field<ListGraphType<ExclusoesPlanoInputType>>("exclusoesPlano");
			Field<ListGraphType<ExclusoesSelecionadaLinhaProdutoInputType>>("exclusoesSelecionadaLinhaProduto");
			Field<ListGraphType<FactorRiscoInputType>>("factorRisco");
			Field<ListGraphType<GarantiaPlanoInputType>>("garantiaPlano");
			Field<ListGraphType<GlossarioInputType>>("glossario");
			Field<ListGraphType<ImagemProdutoInputType>>("imagemProduto");
			Field<ListGraphType<ImpostoLinhaInputType>>("impostoLinha");
			Field<ListGraphType<IncapacidadeTemporariaInputType>>("incapacidadeTemporaria");
			Field<ListGraphType<InformacaoSuporteInputType>>("informacaoSuporte");
			Field<ListGraphType<LinhaProdutoImpostoInputType>>("linhaProdutoImposto");
			Field<ListGraphType<MapaInputType>>("mapa");
			Field<ListGraphType<MediacaoComissaoInputType>>("mediacaoComissao");
			Field<ListGraphType<MotivoViagemInputType>>("motivoViagem");
			Field<ListGraphType<ObjectivoProdutoInputType>>("objectivoProduto");
			Field<ListGraphType<ObjectivosComerciaisInputType>>("objectivosComerciais");
			Field<ListGraphType<ObrigacoesProdutoInputType>>("obrigacoesProduto");
			Field<ListGraphType<OfertaLinhaInputType>>("ofertaLinha");
			Field<ListGraphType<PerguntasInputType>>("perguntas");
			Field<ListGraphType<PessoaTarefaInputType>>("pessoaTarefa");
			Field<ListGraphType<PlanoObjectivoComercialInputType>>("planoObjectivoComercial");
			Field<ListGraphType<PlanoProdutoInputType>>("planoProduto");
			Field<ListGraphType<PontosClausulaInputType>>("pontosClausula");
			Field<ListGraphType<PrazosCurtosInputType>>("prazosCurtos");
			Field<ListGraphType<PremiosMinimosInputType>>("premiosMinimos");
			Field<ListGraphType<QuadroDanosInputType>>("quadroDanos");
			Field<ListGraphType<ReducoesAutorizadasInputType>>("reducoesAutorizadas");
			Field<ListGraphType<ReservasTecnicasInputType>>("reservasTecnicas");
			Field<ListGraphType<RiscoInputType>>("risco");
			Field<ListGraphType<SubRamoInputType>>("subRamo");
			Field<ListGraphType<TarifaInputType>>("tarifa");
			Field<ListGraphType<TarifasAutomovelInputType>>("tarifasAutomovel");
			Field<ListGraphType<TarifasPremioAutoAcidentesTrabalhoInputType>>("tarifasPremioAutoAcidentesTrabalho");
			Field<ListGraphType<TarifasPremioAutoAt2InputType>>("tarifasPremioAutoAt2");
			Field<ListGraphType<TaxaSinistralidadeInputType>>("taxaSinistralidade");
			Field<ListGraphType<TipoApoliceInputType>>("tipoApolice");
			Field<ListGraphType<TipoCoberturaInputType>>("tipoCobertura");
			Field<ListGraphType<TipoContaInputType>>("tipoConta");
			Field<ListGraphType<VantagemProdutoInputType>>("vantagemProduto");
			Field<ListGraphType<ZonaPeriodoCoberturaInputType>>("zonaPeriodoCobertura");
			
		}
	}
}