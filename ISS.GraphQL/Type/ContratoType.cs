using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoType : ObjectGraphType<Contrato>
    {
        public ContratoType()
        {
            // Defining the name of the object
            Name = "contrato";

            Field(x => x.IdContrato, nullable: true);
            //Field(x => x.NumeroContrato, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Referencia, nullable: true);
            Field(x => x.ContratanteId, nullable: true);
            Field(x => x.DataAssinatura, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataVencimento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumeroPrestacoesPagas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumeroPrestacoesApagar, nullable: true, type: typeof(IntGraphType));
            Field(x => x.TotalValorPago, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TotalValorApagar, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodContrato, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.MoradaCobrancaContratoId, nullable: true);
            Field(x => x.MoradaAssinaturaId, nullable: true);
            Field(x => x.TipoPagamentoId, nullable: true);
            Field(x => x.ContaFinanceiraId, nullable: true);
            Field(x => x.TipoContratoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DuracaoTipoContratoId, nullable: true);
            Field(x => x.NumDias, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.CentroResponsabilidadeId, nullable: true);
            Field(x => x.Cedencia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Retencao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FraccionamentoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.FormaPagamentoId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.FazRetencaoNaFonte, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DiaPagamento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ContaFinanceira, nullable: true);
            Field(x => x.Ano, nullable: true);
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFinal, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataRenovacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PrazoAlteracao, nullable: true);
            Field(x => x.PrazoPreAviso, nullable: true);
            Field(x => x.FormaFacturacao, nullable: true);
            Field(x => x.MoradaAssinatura, nullable: true);
            Field(x => x.MoradaCobranca, nullable: true);
            Field(x => x.ContratadoId, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            FieldAsync<CentroCustoType>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(c.Source.CentroCustoId)));
            FieldAsync<CentroResponsabilidadeType>("centroResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroResponsabilidade>(c.Source.CentroResponsabilidadeId)));
            FieldAsync<ContaFinanceiraType>("contaFinanceira1", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceira)));
            FieldAsync<ContaFinanceiraType>("contaFinanceira2", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<PessoaType>("contratado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ContratadoId)));
            FieldAsync<PessoaType>("contratante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ContratanteId)));
            FieldAsync<DuracaoTipoContratoType>("duracaoTipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DuracaoTipoContrato>(c.Source.DuracaoTipoContratoId)));
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FraccionamentoType>("formaFacturacaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fraccionamento>(c.Source.FormaFacturacao)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            FieldAsync<FraccionamentoType>("fraccionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fraccionamento>(c.Source.FraccionamentoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<EnderecoType>("moradaAssinaturaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.MoradaAssinaturaId)));
            FieldAsync<EnderecoType>("moradaCobrancaContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.MoradaCobrancaContratoId)));
            FieldAsync<FraccionamentoType>("prazoAlteracaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fraccionamento>(c.Source.PrazoAlteracao)));
            FieldAsync<FraccionamentoType>("prazoPreAvisoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fraccionamento>(c.Source.PrazoPreAviso)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<TipoContratoType>("tipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContrato>(c.Source.TipoContratoId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<TipoPagamentoType>("tipoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPagamento>(c.Source.TipoPagamentoId)));
            FieldAsync<ListGraphType<CanalContratosType>>("canalContratos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalContratos>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ComissionamentoType>>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceiraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratadosType>>("contratados", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contratados>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratadosAssinantesType>>("contratadosAssinantes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratadosAssinantes>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratantesAssinantesType>>("contratantesAssinantes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratantesAssinantes>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratoCaeType>>("contratoCae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoCae>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratoClausulaType>>("contratoClausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoClausula>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratoFormaPagamentoType>>("contratoFormaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoFormaPagamento>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratoMoedaType>>("contratoMoeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoMoeda>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratoPlanoType>>("contratoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPlano>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratoResseguroType>>("contratoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<ContratoSegmentosType>>("contratoSegmentos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoSegmentos>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<FidelizacaoContratoType>>("fidelizacaoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FidelizacaoContrato>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<InformacaoBancariaContratoType>>("informacaoBancariaContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancariaContrato>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<LimiteComissionamentoProdutorType>>("limiteComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<PessoaContactoContratadoType>>("pessoaContactoContratado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaContactoContratado>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<PessoaContactoContratanteType>>("pessoaContactoContratante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaContactoContratante>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<TipoComissionamentoResseguroType>>("tipoComissionamentoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoComissionamentoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            FieldAsync<ListGraphType<TipoSegmentoContratoType>>("tipoSegmentoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoContrato>(x => x.Where(e => e.HasValue(c.Source.IdContrato)))));
            
        }
    }

    public class ContratoInputType : InputObjectGraphType
	{
		public ContratoInputType()
		{
			// Defining the name of the object
			Name = "contratoInput";
			
            //Field<StringGraphType>("idContrato");
			//Field<IntGraphType>("numeroContrato");
			Field<StringGraphType>("referencia");
			Field<StringGraphType>("contratanteId");
			Field<DateTimeGraphType>("dataAssinatura");
			Field<DateTimeGraphType>("dataVencimento");
			Field<FloatGraphType>("valor");
			Field<IntGraphType>("numeroPrestacoesPagas");
			Field<IntGraphType>("numeroPrestacoesApagar");
			Field<FloatGraphType>("totalValorPago");
			Field<FloatGraphType>("totalValorApagar");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codContrato");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("moradaCobrancaContratoId");
			Field<StringGraphType>("moradaAssinaturaId");
			Field<StringGraphType>("tipoPagamentoId");
			Field<StringGraphType>("contaFinanceiraId");
			Field<StringGraphType>("tipoContratoId");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("duracaoTipoContratoId");
			Field<IntGraphType>("numDias");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("centroResponsabilidadeId");
			Field<FloatGraphType>("cedencia");
			Field<FloatGraphType>("retencao");
			Field<StringGraphType>("fraccionamentoId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("formaPagamentoId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<BooleanGraphType>("fazRetencaoNaFonte");
			Field<DateTimeGraphType>("diaPagamento");
			Field<StringGraphType>("contaFinanceira");
			Field<StringGraphType>("ano");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFinal");
			Field<DateTimeGraphType>("dataRenovacao");
			Field<StringGraphType>("prazoAlteracao");
			Field<StringGraphType>("prazoPreAviso");
			Field<StringGraphType>("formaFacturacao");
			Field<StringGraphType>("moradaAssinatura");
			Field<StringGraphType>("moradaCobranca");
			Field<StringGraphType>("contratadoId");
			Field<StringGraphType>("produtorId");
			Field<CentroCustoInputType>("centroCusto");
			Field<CentroResponsabilidadeInputType>("centroResponsabilidade");
			Field<ContaFinanceiraInputType>("contaFinanceira1");
			Field<ContaFinanceiraInputType>("contaFinanceira2");
			Field<PessoaInputType>("contratado");
			Field<PessoaInputType>("contratante");
			Field<DuracaoTipoContratoInputType>("duracaoTipoContrato");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<FraccionamentoInputType>("formaFacturacaoNavigation");
			Field<FormaPagamentoInputType>("formaPagamento");
			Field<FraccionamentoInputType>("fraccionamento");
			Field<MoedaInputType>("moeda");
			Field<EnderecoInputType>("moradaAssinaturaNavigation");
			Field<EnderecoInputType>("moradaCobrancaContrato");
			Field<FraccionamentoInputType>("prazoAlteracaoNavigation");
			Field<FraccionamentoInputType>("prazoPreAvisoNavigation");
			Field<PessoaInputType>("produtor");
			Field<TipoContratoInputType>("tipoContrato");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<TipoPagamentoInputType>("tipoPagamento");
			Field<ListGraphType<CanalContratosInputType>>("canalContratos");
			Field<ListGraphType<ComissionamentoInputType>>("comissionamento");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceiraNavigation");
			Field<ListGraphType<ContratadosInputType>>("contratados");
			Field<ListGraphType<ContratadosAssinantesInputType>>("contratadosAssinantes");
			Field<ListGraphType<ContratantesAssinantesInputType>>("contratantesAssinantes");
			Field<ListGraphType<ContratoCaeInputType>>("contratoCae");
			Field<ListGraphType<ContratoClausulaInputType>>("contratoClausula");
			Field<ListGraphType<ContratoFormaPagamentoInputType>>("contratoFormaPagamento");
			Field<ListGraphType<ContratoMoedaInputType>>("contratoMoeda");
			Field<ListGraphType<ContratoPlanoInputType>>("contratoPlano");
			Field<ListGraphType<ContratoResseguroInputType>>("contratoResseguro");
			Field<ListGraphType<ContratoSegmentosInputType>>("contratoSegmentos");
			Field<ListGraphType<FidelizacaoContratoInputType>>("fidelizacaoContrato");
			Field<ListGraphType<InformacaoBancariaContratoInputType>>("informacaoBancariaContrato");
			Field<ListGraphType<LimiteComissionamentoProdutorInputType>>("limiteComissionamentoProdutor");
			Field<ListGraphType<PessoaContactoContratadoInputType>>("pessoaContactoContratado");
			Field<ListGraphType<PessoaContactoContratanteInputType>>("pessoaContactoContratante");
			Field<ListGraphType<TipoComissionamentoResseguroInputType>>("tipoComissionamentoResseguro");
			Field<ListGraphType<TipoSegmentoContratoInputType>>("tipoSegmentoContrato");
			
		}
	}
}