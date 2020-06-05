using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MoedaType : ObjectGraphType<Moeda>
    {
        public MoedaType()
        {
            // Defining the name of the object
            Name = "moeda";

            Field(x => x.IdMoeda, nullable: true);
            Field(x => x.CodMoeda, nullable: true);
            Field(x => x.Simbolo, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<AgravamentoType>>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<AtosMedicosType>>("atosMedicos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AtosMedicos>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<AutomovelType>>("automovelMoeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<AutomovelType>>("automovelMoedaValorActual", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<BemAfectadoType>>("bemAfectado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BemAfectado>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<BemSalvadoType>>("bemSalvado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BemSalvado>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<BonusType>>("bonus", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Bonus>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<CambioType>>("cambioMoeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cambio>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<CambioType>>("cambioMoedaBase", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cambio>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<CapitalSeguroAutomovelType>>("capitalSeguroAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CapitalSeguroAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<CilindragemAutomovelType>>("cilindragemAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CilindragemAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ClassificacaoCaixaType>>("classificacaoCaixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoCaixa>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<CoPagamentoType>>("coPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoPagamento>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<CoberturaType>>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<CoberturaPlanoType>>("coberturaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaPlano>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ComissaoType>>("comissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissao>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ContratoType>>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ContratoMoedaType>>("contratoMoeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoMoeda>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<DespesaType>>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<EncargosType>>("encargos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Encargos>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ExcedenteType>>("excedente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Excedente>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ExportacoesProdutosInstalacoesType>>("exportacoesProdutosInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExportacoesProdutosInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<FacultativoResseguroType>>("facultativoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FacultativoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<HistoricoOfertaType>>("historicoOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HistoricoOferta>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<HistoricoPrecarioProdutoType>>("historicoPrecarioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HistoricoPrecarioProduto>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ImpostoType>>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<InstalacoesType>>("instalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Instalacoes>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<LimiteResponsablidadeCivilAutomovelType>>("limiteResponsablidadeCivilAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteResponsablidadeCivilAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<LimitesAceitacaoType>>("limitesAceitacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimitesAceitacao>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<LimitesRapelType>>("limitesRapel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimitesRapel>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<MargemVendaProdutoType>>("margemVendaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MargemVendaProduto>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ModalidadeAtrasoViagemType>>("modalidadeAtrasoViagem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadeAtrasoViagem>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimentoCodMoedaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimentoCodOutraMoedaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<NivelRiscoCoberturaType>>("nivelRiscoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRiscoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<OfertaPlanoType>>("ofertaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OfertaPlano>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<OperacaoType>>("operacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Operacao>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<PrecarioProdutoType>>("precarioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecarioProduto>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<PrecosAtosMedicosType>>("precosAtosMedicos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecosAtosMedicos>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<PrecosMedicamentosType>>("precosMedicamentos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecosMedicamentos>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<PremiosMinimosType>>("premiosMinimos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PremiosMinimos>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ProdutoType>>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ProdutosInstalacoesType>>("produtosInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProdutosInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ReservasTecnicasType>>("reservasTecnicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReservasTecnicas>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ServicoType>>("servico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Servico>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ServicosAdicionaisType>>("servicosAdicionais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ServicosAdicionais>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ServicosBaseType>>("servicosBase", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ServicosBase>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<SimulacaoType>>("simulacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Simulacao>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<SinistroType>>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<SubFormaResseguroInformacaoType>>("subFormaResseguroInformacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubFormaResseguroInformacao>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<SubscricaoCessaoRetencaoType>>("subscricaoCessaoRetencao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubscricaoCessaoRetencao>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<TerceiroType>>("terceiro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Terceiro>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<TipoComissaoType>>("tipoComissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoComissao>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<TipoRegimeType>>("tipoRegime", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRegime>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            FieldAsync<ListGraphType<ValorCativoType>>("valorCativo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValorCativo>(x => x.Where(e => e.HasValue(c.Source.IdMoeda)))));
            
        }
    }

    public class MoedaInputType : InputObjectGraphType
	{
		public MoedaInputType()
		{
			// Defining the name of the object
			Name = "moedaInput";
			
            //Field<StringGraphType>("idMoeda");
			Field<StringGraphType>("codMoeda");
			Field<StringGraphType>("simbolo");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("subContaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<AgravamentoInputType>>("agravamento");
			Field<ListGraphType<AtosMedicosInputType>>("atosMedicos");
			Field<ListGraphType<AutomovelInputType>>("automovelMoeda");
			Field<ListGraphType<AutomovelInputType>>("automovelMoedaValorActual");
			Field<ListGraphType<BemAfectadoInputType>>("bemAfectado");
			Field<ListGraphType<BemSalvadoInputType>>("bemSalvado");
			Field<ListGraphType<BonusInputType>>("bonus");
			Field<ListGraphType<CambioInputType>>("cambioMoeda");
			Field<ListGraphType<CambioInputType>>("cambioMoedaBase");
			Field<ListGraphType<CapitalSeguroAutomovelInputType>>("capitalSeguroAutomovel");
			Field<ListGraphType<CilindragemAutomovelInputType>>("cilindragemAutomovel");
			Field<ListGraphType<ClassificacaoCaixaInputType>>("classificacaoCaixa");
			Field<ListGraphType<CoPagamentoInputType>>("coPagamento");
			Field<ListGraphType<CoberturaInputType>>("cobertura");
			Field<ListGraphType<CoberturaPlanoInputType>>("coberturaPlano");
			Field<ListGraphType<ComissaoInputType>>("comissao");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceira");
			Field<ListGraphType<ContratoInputType>>("contrato");
			Field<ListGraphType<ContratoMoedaInputType>>("contratoMoeda");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<DespesaInputType>>("despesa");
			Field<ListGraphType<EncargosInputType>>("encargos");
			Field<ListGraphType<ExcedenteInputType>>("excedente");
			Field<ListGraphType<ExportacoesProdutosInstalacoesInputType>>("exportacoesProdutosInstalacoes");
			Field<ListGraphType<FacultativoResseguroInputType>>("facultativoResseguro");
			Field<ListGraphType<HistoricoOfertaInputType>>("historicoOferta");
			Field<ListGraphType<HistoricoPrecarioProdutoInputType>>("historicoPrecarioProduto");
			Field<ListGraphType<ImpostoInputType>>("imposto");
			Field<ListGraphType<InstalacoesInputType>>("instalacoes");
			Field<ListGraphType<LimiteResponsablidadeCivilAutomovelInputType>>("limiteResponsablidadeCivilAutomovel");
			Field<ListGraphType<LimitesAceitacaoInputType>>("limitesAceitacao");
			Field<ListGraphType<LimitesRapelInputType>>("limitesRapel");
			Field<ListGraphType<MargemVendaProdutoInputType>>("margemVendaProduto");
			Field<ListGraphType<ModalidadeAtrasoViagemInputType>>("modalidadeAtrasoViagem");
			Field<ListGraphType<MovimentoInputType>>("movimentoCodMoedaNavigation");
			Field<ListGraphType<MovimentoInputType>>("movimentoCodOutraMoedaNavigation");
			Field<ListGraphType<NivelRiscoCoberturaInputType>>("nivelRiscoCobertura");
			Field<ListGraphType<OfertaPlanoInputType>>("ofertaPlano");
			Field<ListGraphType<OperacaoInputType>>("operacao");
			Field<ListGraphType<PrecarioProdutoInputType>>("precarioProduto");
			Field<ListGraphType<PrecosAtosMedicosInputType>>("precosAtosMedicos");
			Field<ListGraphType<PrecosMedicamentosInputType>>("precosMedicamentos");
			Field<ListGraphType<PremiosMinimosInputType>>("premiosMinimos");
			Field<ListGraphType<ProdutoInputType>>("produto");
			Field<ListGraphType<ProdutosInstalacoesInputType>>("produtosInstalacoes");
			Field<ListGraphType<ReservasTecnicasInputType>>("reservasTecnicas");
			Field<ListGraphType<ServicoInputType>>("servico");
			Field<ListGraphType<ServicosAdicionaisInputType>>("servicosAdicionais");
			Field<ListGraphType<ServicosBaseInputType>>("servicosBase");
			Field<ListGraphType<SimulacaoInputType>>("simulacao");
			Field<ListGraphType<SinistroInputType>>("sinistro");
			Field<ListGraphType<SubFormaResseguroInformacaoInputType>>("subFormaResseguroInformacao");
			Field<ListGraphType<SubscricaoCessaoRetencaoInputType>>("subscricaoCessaoRetencao");
			Field<ListGraphType<TerceiroInputType>>("terceiro");
			Field<ListGraphType<TipoComissaoInputType>>("tipoComissao");
			Field<ListGraphType<TipoRegimeInputType>>("tipoRegime");
			Field<ListGraphType<ValorCativoInputType>>("valorCativo");
			
		}
	}
}