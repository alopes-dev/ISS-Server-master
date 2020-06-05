using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoOperacaoType : ObjectGraphType<TipoOperacao>
    {
        public TipoOperacaoType()
        {
            // Defining the name of the object
            Name = "tipoOperacao";

            Field(x => x.IdTipoOperacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoOperacao, nullable: true);
            Field(x => x.TipoMovimento, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorRegraOperacao, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CaminhoIcome, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.SubContaCreditoId, nullable: true);
            Field(x => x.SubContaDebitoId, nullable: true);
            Field(x => x.TipoDocumentoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<PlanoContasType>("subContaCredito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaCreditoId)));
            FieldAsync<PlanoContasType>("subContaDebito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaDebitoId)));
            FieldAsync<TipoDocumentosType>("tipoDocumento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDocumentos>(c.Source.TipoDocumentoId)));
            FieldAsync<ListGraphType<AgravamentoType>>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<BonusType>>("bonus", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Bonus>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<ContratoType>>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<DescontoType>>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<DespesaType>>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<EncargosType>>("encargos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Encargos>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<FraccionamentoType>>("fraccionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fraccionamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<HistoricoOfertaType>>("historicoOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HistoricoOferta>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<ImpostoType>>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<MargemVendaProdutoType>>("margemVendaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MargemVendaProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<OperacaoType>>("operacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Operacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<OperacoesPagamentoType>>("operacoesPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesPagamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<PrecarioProdutoType>>("precarioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecarioProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<ReservasTecnicasType>>("reservasTecnicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReservasTecnicas>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<TipoAgravamentoType>>("tipoAgravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoAgravamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            FieldAsync<ListGraphType<TipoOperacaoProcessoType>>("tipoOperacaoProcesso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacaoProcesso>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacao)))));
            
        }
    }

    public class TipoOperacaoInputType : InputObjectGraphType
	{
		public TipoOperacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoOperacaoInput";
			
            //Field<StringGraphType>("idTipoOperacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoOperacao");
			Field<IntGraphType>("tipoMovimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("valorRegraOperacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("caminhoIcome");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("subContaCreditoId");
			Field<StringGraphType>("subContaDebitoId");
			Field<StringGraphType>("tipoDocumentoId");
			Field<EstadoInputType>("estado");
			Field<PapelInputType>("papel");
			Field<PlanoContasInputType>("subContaCredito");
			Field<PlanoContasInputType>("subContaDebito");
			Field<TipoDocumentosInputType>("tipoDocumento");
			Field<ListGraphType<AgravamentoInputType>>("agravamento");
			Field<ListGraphType<BonusInputType>>("bonus");
			Field<ListGraphType<ContratoInputType>>("contrato");
			Field<ListGraphType<DescontoInputType>>("desconto");
			Field<ListGraphType<DespesaInputType>>("despesa");
			Field<ListGraphType<EncargosInputType>>("encargos");
			Field<ListGraphType<FraccionamentoInputType>>("fraccionamento");
			Field<ListGraphType<HistoricoOfertaInputType>>("historicoOferta");
			Field<ListGraphType<ImpostoInputType>>("imposto");
			Field<ListGraphType<MargemVendaProdutoInputType>>("margemVendaProduto");
			Field<ListGraphType<OperacaoInputType>>("operacao");
			Field<ListGraphType<OperacoesPagamentoInputType>>("operacoesPagamento");
			Field<ListGraphType<PrecarioProdutoInputType>>("precarioProduto");
			Field<ListGraphType<ReservasTecnicasInputType>>("reservasTecnicas");
			Field<ListGraphType<TipoAgravamentoInputType>>("tipoAgravamento");
			Field<ListGraphType<TipoOperacaoProcessoInputType>>("tipoOperacaoProcesso");
			
		}
	}
}