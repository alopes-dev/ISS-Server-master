using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ApoliceType : ObjectGraphType<Apolice>
    {
        public ApoliceType()
        {
            // Defining the name of the object
            Name = "apolice";

            Field(x => x.IdApolice, nullable: true);
            Field(x => x.DataEmissao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataExpiracao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataRenovacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.BalcaoId, nullable: true);
            Field(x => x.AssinaturaProponente, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ApoliceCoAssegurada, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.AssinadaLocalPagamento, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ApoliceTransferida, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.RefApolice, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.DataCancelamento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataEstorno, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAnulacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.SeguradoraId, nullable: true);
            Field(x => x.CodApolice, nullable: true);
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.ClienteId, nullable: true);
            Field(x => x.Ambito, nullable: true);
            Field(x => x.ContaFinanceiraId, nullable: true);
            Field(x => x.OperacoesPagamentoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.ModalidadeSeguroId, nullable: true);
            Field(x => x.TipoaApoliceId, nullable: true);
            Field(x => x.NumOrdemApolice, nullable: true, type: typeof(IntGraphType));
            Field(x => x.TomadorId, nullable: true);
            FieldAsync<BalcaoType>("balcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Balcao>(c.Source.BalcaoId)));
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<CentroCustoType>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(c.Source.CentroCustoId)));
            FieldAsync<ClienteType>("cliente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cliente>(c.Source.ClienteId)));
            FieldAsync<ContaFinanceiraType>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<OperacoesPagamentoType>("operacoesPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesPagamento>(c.Source.OperacoesPagamentoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<PessoaType>("seguradora", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.SeguradoraId)));
            FieldAsync<TipoApoliceType>("tipoaApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoApolice>(c.Source.TipoaApoliceId)));
            FieldAsync<PessoaType>("tomador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.TomadorId)));
            FieldAsync<ListGraphType<AgravamentoApoliceType>>("agravamentoApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoApolice>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<BeneficiarioType>>("beneficiario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Beneficiario>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<BoletimAdesaoSaudeType>>("boletimAdesaoSaude", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BoletimAdesaoSaude>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<CoPagamentoType>>("coPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoPagamento>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<CoSeguroType>>("coSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoSeguro>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<CobradorType>>("cobrador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobrador>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ComissaoType>>("comissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissao>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ComissaoSelecionadaType>>("comissaoSelecionada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoSelecionada>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<CondicoesApoliceType>>("condicoesApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicoesApolice>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ConstrucaoType>>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ConsumoPlafondType>>("consumoPlafond", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ConsumoPlafond>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceiraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<CotacaoDependenteType>>("cotacaoDependente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CotacaoDependente>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<DescontoSeleccionadoType>>("descontoSeleccionado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoSeleccionado>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<DespesaSeleccionadaType>>("despesaSeleccionada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DespesaSeleccionada>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<DiasContagemType>>("diasContagem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DiasContagem>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<DocumentoMembroAsseguradoType>>("documentoMembroAssegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentoMembroAssegurado>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<DocumentosAnexosApoliceType>>("documentosAnexosApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosAnexosApolice>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<FornecedorType>>("fornecedor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fornecedor>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<FranquiaSeleccionadoType>>("franquiaSeleccionado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FranquiaSeleccionado>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<GarantiasContratadasType>>("garantiasContratadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GarantiasContratadas>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<InstalacoesType>>("instalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Instalacoes>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<JustificacaoType>>("justificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Justificacao>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<MargemVendaSeleccionadoType>>("margemVendaSeleccionado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MargemVendaSeleccionado>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<MembroAsseguradoType>>("membroAssegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MembroAssegurado>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<PacienteType>>("paciente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Paciente>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<PrestadorType>>("prestador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Prestador>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ReciboType>>("recibo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Recibo>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ReclamacaoType>>("reclamacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reclamacao>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ReembolsoDespesasMedicasType>>("reembolsoDespesasMedicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReembolsoDespesasMedicas>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ReivindicacoesFeitasApoliceType>>("reivindicacoesFeitasApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReivindicacoesFeitasApolice>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<RenovacaoApoliceType>>("renovacaoApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RenovacaoApolice>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<ReservasTecnicasType>>("reservasTecnicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReservasTecnicas>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<SeguradoType>>("segurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Segurado>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<SinistroType>>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<TermoResponsabilidadeType>>("termoResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TermoResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<TestemunhaType>>("testemunha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Testemunha>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            FieldAsync<ListGraphType<TomadorType>>("tomadorNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tomador>(x => x.Where(e => e.HasValue(c.Source.IdApolice)))));
            
        }
    }

    public class ApoliceInputType : InputObjectGraphType
	{
		public ApoliceInputType()
		{
			// Defining the name of the object
			Name = "apoliceInput";
			
            //Field<StringGraphType>("idApolice");
			Field<DateTimeGraphType>("dataEmissao");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataExpiracao");
			Field<DateTimeGraphType>("dataRenovacao");
			Field<StringGraphType>("balcaoId");
			Field<BooleanGraphType>("assinaturaProponente");
			Field<BooleanGraphType>("apoliceCoAssegurada");
			Field<BooleanGraphType>("assinadaLocalPagamento");
			Field<BooleanGraphType>("apoliceTransferida");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("refApolice");
			Field<StringGraphType>("produtorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<DateTimeGraphType>("dataCancelamento");
			Field<DateTimeGraphType>("dataEstorno");
			Field<DateTimeGraphType>("dataAnulacao");
			Field<StringGraphType>("seguradoraId");
			Field<StringGraphType>("codApolice");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("clienteId");
			Field<StringGraphType>("ambito");
			Field<StringGraphType>("contaFinanceiraId");
			Field<StringGraphType>("operacoesPagamentoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("modalidadeSeguroId");
			Field<StringGraphType>("tipoaApoliceId");
			Field<IntGraphType>("numOrdemApolice");
			Field<StringGraphType>("tomadorId");
			Field<BalcaoInputType>("balcao");
			Field<CanalInputType>("canal");
			Field<CentroCustoInputType>("centroCusto");
			Field<ClienteInputType>("cliente");
			Field<ContaFinanceiraInputType>("contaFinanceira");
			Field<EstadoInputType>("estado");
			Field<OperacoesPagamentoInputType>("operacoesPagamento");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<PessoaInputType>("produtor");
			Field<PessoaInputType>("seguradora");
			Field<TipoApoliceInputType>("tipoaApolice");
			Field<PessoaInputType>("tomador");
			Field<ListGraphType<AgravamentoApoliceInputType>>("agravamentoApolice");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			Field<ListGraphType<BeneficiarioInputType>>("beneficiario");
			Field<ListGraphType<BoletimAdesaoSaudeInputType>>("boletimAdesaoSaude");
			Field<ListGraphType<CoPagamentoInputType>>("coPagamento");
			Field<ListGraphType<CoSeguroInputType>>("coSeguro");
			Field<ListGraphType<CobradorInputType>>("cobrador");
			Field<ListGraphType<ComissaoInputType>>("comissao");
			Field<ListGraphType<ComissaoSelecionadaInputType>>("comissaoSelecionada");
			Field<ListGraphType<CondicoesApoliceInputType>>("condicoesApolice");
			Field<ListGraphType<ConstrucaoInputType>>("construcao");
			Field<ListGraphType<ConsumoPlafondInputType>>("consumoPlafond");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceiraNavigation");
			Field<ListGraphType<CotacaoDependenteInputType>>("cotacaoDependente");
			Field<ListGraphType<DescontoSeleccionadoInputType>>("descontoSeleccionado");
			Field<ListGraphType<DespesaSeleccionadaInputType>>("despesaSeleccionada");
			Field<ListGraphType<DiasContagemInputType>>("diasContagem");
			Field<ListGraphType<DocumentoMembroAsseguradoInputType>>("documentoMembroAssegurado");
			Field<ListGraphType<DocumentosAnexosApoliceInputType>>("documentosAnexosApolice");
			Field<ListGraphType<FornecedorInputType>>("fornecedor");
			Field<ListGraphType<FranquiaSeleccionadoInputType>>("franquiaSeleccionado");
			Field<ListGraphType<GarantiasContratadasInputType>>("garantiasContratadas");
			Field<ListGraphType<InstalacoesInputType>>("instalacoes");
			Field<ListGraphType<JustificacaoInputType>>("justificacao");
			Field<ListGraphType<MargemVendaSeleccionadoInputType>>("margemVendaSeleccionado");
			Field<ListGraphType<MembroAsseguradoInputType>>("membroAssegurado");
			Field<ListGraphType<PacienteInputType>>("paciente");
			Field<ListGraphType<PrestadorInputType>>("prestador");
			Field<ListGraphType<ReciboInputType>>("recibo");
			Field<ListGraphType<ReclamacaoInputType>>("reclamacao");
			Field<ListGraphType<ReembolsoDespesasMedicasInputType>>("reembolsoDespesasMedicas");
			Field<ListGraphType<ReivindicacoesFeitasApoliceInputType>>("reivindicacoesFeitasApolice");
			Field<ListGraphType<RenovacaoApoliceInputType>>("renovacaoApolice");
			Field<ListGraphType<ReservasTecnicasInputType>>("reservasTecnicas");
			Field<ListGraphType<SeguradoInputType>>("segurado");
			Field<ListGraphType<SinistroInputType>>("sinistro");
			Field<ListGraphType<TermoResponsabilidadeInputType>>("termoResponsabilidade");
			Field<ListGraphType<TestemunhaInputType>>("testemunha");
			Field<ListGraphType<TomadorInputType>>("tomadorNavigation");
			
		}
	}
}