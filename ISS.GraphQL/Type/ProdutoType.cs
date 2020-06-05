using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProdutoType : ObjectGraphType<Produto>
    {
        public ProdutoType()
        {
            // Defining the name of the object
            Name = "produto";

            Field(x => x.IdProduto, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.AmbitoProduto, nullable: true);
            Field(x => x.FinalidadeProduto, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PortfolioProdutoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.CaminhoUrl, nullable: true);
            Field(x => x.ResseguroObrigatorio, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.SeguroObrigatorio, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsentoImposto, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Comissionado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CaminhoWeb, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCancelamento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAnulacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PortfolioProdutoType>("portfolioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PortfolioProduto>(c.Source.PortfolioProdutoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<AgravamentoPessoaType>>("agravamentoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<CategoriaSujeitoDanoType>>("categoriaSujeitoDano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaSujeitoDano>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<ClasseModalidadeSeguroType>>("classeModalidadeSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClasseModalidadeSeguro>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<CondicoesProdutoType>>("condicoesProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicoesProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<CrossSellingType>>("crossSellingProdutoCrossed", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CrossSelling>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<CrossSellingType>>("crossSellingProdutoPrincipal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CrossSelling>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<DocumentosObrigatorioProdutoType>>("documentosObrigatorioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosObrigatorioProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<ExclusoesType>>("exclusoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exclusoes>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<GlossarioType>>("glossario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Glossario>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<ImagemProdutoType>>("imagemProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImagemProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<IncapacidadeTemporariaType>>("incapacidadeTemporaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IncapacidadeTemporaria>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<InformacaoSuporteType>>("informacaoSuporte", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoSuporte>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<InformacoesAdicionaisProdutoType>>("informacoesAdicionaisProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacoesAdicionaisProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<LinhaProdutoType>>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<MapaType>>("mapa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Mapa>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<MetricasProdutoType>>("metricasProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MetricasProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<ObjectivoProdutoType>>("objectivoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectivoProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<ObjectivosComerciaisType>>("objectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<ObrigacoesProdutoType>>("obrigacoesProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObrigacoesProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<PerguntasFrequentesProdutoType>>("perguntasFrequentesProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PerguntasFrequentesProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<PerspicaciaType>>("perspicacia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perspicacia>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<PessoaTarefaType>>("pessoaTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaTarefa>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<PremiosMinimosType>>("premiosMinimos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PremiosMinimos>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<QuadroDanosType>>("quadroDanos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<QuadroDanos>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<RelatorioProdutoType>>("relatorioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RelatorioProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<RiscoType>>("risco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Risco>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<TarifaType>>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<TarifasAutomovelType>>("tarifasAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<TarifasPremioAutoAcidentesTrabalhoType>>("tarifasPremioAutoAcidentesTrabalho", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasPremioAutoAcidentesTrabalho>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<TarifasPremioAutoAt2Type>>("tarifasPremioAutoAt2", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasPremioAutoAt2>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<TipoCoberturaType>>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            FieldAsync<ListGraphType<VantagemProdutoType>>("vantagemProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<VantagemProduto>(x => x.Where(e => e.HasValue(c.Source.IdProduto)))));
            
        }
    }

    public class ProdutoInputType : InputObjectGraphType
	{
		public ProdutoInputType()
		{
			// Defining the name of the object
			Name = "produtoInput";
			
            //Field<StringGraphType>("idProduto");
			Field<StringGraphType>("nome");
			Field<StringGraphType>("ambitoProduto");
			Field<StringGraphType>("finalidadeProduto");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("portfolioProdutoId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("caminhoUrl");
			Field<BooleanGraphType>("resseguroObrigatorio");
			Field<StringGraphType>("codProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("seguroObrigatorio");
			Field<BooleanGraphType>("isentoImposto");
			Field<BooleanGraphType>("comissionado");
			Field<StringGraphType>("caminhoWeb");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<DateTimeGraphType>("dataCancelamento");
			Field<DateTimeGraphType>("dataAnulacao");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PortfolioProdutoInputType>("portfolioProduto");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<AgravamentoPessoaInputType>>("agravamentoPessoa");
			Field<ListGraphType<CategoriaSujeitoDanoInputType>>("categoriaSujeitoDano");
			Field<ListGraphType<ClasseModalidadeSeguroInputType>>("classeModalidadeSeguro");
			Field<ListGraphType<CondicoesProdutoInputType>>("condicoesProduto");
			Field<ListGraphType<CrossSellingInputType>>("crossSellingProdutoCrossed");
			Field<ListGraphType<CrossSellingInputType>>("crossSellingProdutoPrincipal");
			Field<ListGraphType<DocumentosObrigatorioProdutoInputType>>("documentosObrigatorioProduto");
			Field<ListGraphType<ExclusoesInputType>>("exclusoes");
			Field<ListGraphType<GlossarioInputType>>("glossario");
			Field<ListGraphType<ImagemProdutoInputType>>("imagemProduto");
			Field<ListGraphType<IncapacidadeTemporariaInputType>>("incapacidadeTemporaria");
			Field<ListGraphType<InformacaoSuporteInputType>>("informacaoSuporte");
			Field<ListGraphType<InformacoesAdicionaisProdutoInputType>>("informacoesAdicionaisProduto");
			Field<ListGraphType<LinhaProdutoInputType>>("linhaProduto");
			Field<ListGraphType<MapaInputType>>("mapa");
			Field<ListGraphType<MetricasProdutoInputType>>("metricasProduto");
			Field<ListGraphType<ObjectivoProdutoInputType>>("objectivoProduto");
			Field<ListGraphType<ObjectivosComerciaisInputType>>("objectivosComerciais");
			Field<ListGraphType<ObrigacoesProdutoInputType>>("obrigacoesProduto");
			Field<ListGraphType<PerguntasFrequentesProdutoInputType>>("perguntasFrequentesProduto");
			Field<ListGraphType<PerspicaciaInputType>>("perspicacia");
			Field<ListGraphType<PessoaTarefaInputType>>("pessoaTarefa");
			Field<ListGraphType<PremiosMinimosInputType>>("premiosMinimos");
			Field<ListGraphType<QuadroDanosInputType>>("quadroDanos");
			Field<ListGraphType<RelatorioProdutoInputType>>("relatorioProduto");
			Field<ListGraphType<RiscoInputType>>("risco");
			Field<ListGraphType<TarifaInputType>>("tarifa");
			Field<ListGraphType<TarifasAutomovelInputType>>("tarifasAutomovel");
			Field<ListGraphType<TarifasPremioAutoAcidentesTrabalhoInputType>>("tarifasPremioAutoAcidentesTrabalho");
			Field<ListGraphType<TarifasPremioAutoAt2InputType>>("tarifasPremioAutoAt2");
			Field<ListGraphType<TipoCoberturaInputType>>("tipoCobertura");
			Field<ListGraphType<VantagemProdutoInputType>>("vantagemProduto");
			
		}
	}
}