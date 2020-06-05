using GraphQL.Types;
using ISS.Application.Helpers;
using ISS.Application.Models;
using ISS.GraphQL.ServiceExtentions;
using System.Linq;

namespace ISS.GraphQL.Type
{
    public class CanalType : ObjectGraphType<Canal>
    {
        public CanalType()
        {
            // Defining the name of the object
            Name = "canal";

            Field(x => x.IdCanal, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCanal, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.TipoFacturamentoId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<TipoFacturamentoType>("tipoFacturamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoFacturamento>(c.Source.TipoFacturamentoId)));
            FieldAsync<ListGraphType<ApoliceType>>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<BonusType>>("bonus", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Bonus>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CanalComissionamentoType>>("canalComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CanalComissionamentoProdutorType>>("canalComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CanalContratosType>>("canalContratos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalContratos>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CanalDescontoType>>("canalDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalDesconto>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CanalMenuType>>("canalMenu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalMenu>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CanalPlanoType>>("canalPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalPlano>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CoPagamentoType>>("coPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoPagamento>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<ComissaoPlanoType>>("comissaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<ComissionamentoType>>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CondicaoOperacaoType>>("condicaoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoOperacao>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<ContratoCanaisType>>("contratoCanais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoCanais>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<CriterioComissionamentoType>>("criterioComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CriterioComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<DespesaType>>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<LimiteCompetenciaType>>("limiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<MargemVendaProdutoType>>("margemVendaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MargemVendaProduto>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<PrecarioProdutoType>>("precarioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecarioProduto>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<ReservasTecnicasType>>("reservasTecnicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReservasTecnicas>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<SegmentoOfertaType>>("segmentoOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoOferta>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<TarifaType>>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            FieldAsync<ListGraphType<TipoSegmentoComissionamentoType>>("tipoSegmentoComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdCanal)))));
            
        }
    }

    public class CanalInputType : InputObjectGraphType<Canal>
	{
		public CanalInputType()
		{
			// Defining the name of the object
			Name = "canalInput";

            Field(x => x.Designacao, nullable: true);
			Field(x => x.CodCanal,nullable:true);
			Field(x => x.DataCriacao,nullable:true,type:typeof(DateTimeGraphType));
			Field(x => x.DataAtualizacao,nullable:true,type:typeof(DateTimeGraphType));
			Field(x => x.EstadoId,nullable:true);
			Field(x => x.UltModificacaoPorId,nullable:true);
			Field(x => x.TipoFacturamentoId,nullable:true);
			Field(x => x.NaturezaMovimentoId,nullable:true);
			Field(x => x.SubContaId,nullable:true);
			Field(x => x.Estado,nullable:true,type:typeof(EstadoInputType));
			Field(x => x.NaturezaMovimento,nullable:true,type:typeof(NaturezaMovimentoInputType));
			Field(x => x.SubConta,nullable:true,type:typeof(PlanoContasInputType));
			Field(x => x.TipoFacturamento,nullable:true,type:typeof(TipoFacturamentoInputType));
            Field(x => x.Apolice,nullable:true, type:typeof(ListGraphType<ApoliceInputType>));
            Field(x => x.Bonus,nullable:true, type:typeof(ListGraphType<BonusInputType>));
            Field(x => x.CanalComissionamento,nullable:true, type:typeof(ListGraphType<CanalComissionamentoInputType>));
            Field(x => x.CanalComissionamentoProdutor,nullable:true, type:typeof(ListGraphType<CanalComissionamentoProdutorInputType>));
            Field(x => x.CanalContratos,nullable:true, type:typeof(ListGraphType<CanalContratosInputType>));
            Field(x => x.CanalDesconto,nullable:true, type:typeof(ListGraphType<CanalDescontoInputType>));
            Field(x => x.CanalMenu,nullable:true, type:typeof(ListGraphType<CanalMenuInputType>));
            Field(x => x.CanalPlano,nullable:true, type:typeof(ListGraphType<CanalPlanoInputType>));
            Field(x => x.CoPagamento,nullable:true, type:typeof(ListGraphType<CoPagamentoInputType>));
            Field(x => x.ComissaoPlano,nullable:true, type:typeof(ListGraphType<ComissaoPlanoInputType>));
            Field(x => x.Comissionamento,nullable:true, type:typeof(ListGraphType<ComissionamentoInputType>));
            Field(x => x.CondicaoOperacao,nullable:true, type:typeof(ListGraphType<CondicaoOperacaoInputType>));
            Field(x => x.ContaFinanceira,nullable:true, type:typeof(ListGraphType<ContaFinanceiraInputType>));
            Field(x => x.ContratoCanais,nullable:true, type:typeof(ListGraphType<ContratoCanaisInputType>));
            Field(x => x.Cotacao,nullable:true, type:typeof(ListGraphType<CotacaoInputType>));
            Field(x => x.CriterioComissionamento,nullable:true, type:typeof(ListGraphType<CriterioComissionamentoInputType>));
            Field(x => x.Despesa,nullable:true, type:typeof(ListGraphType<DespesaInputType>));
            Field(x => x.LimiteCompetencia,nullable:true, type:typeof(ListGraphType<LimiteCompetenciaInputType>));
            Field(x => x.MargemVendaProduto,nullable:true, type:typeof(ListGraphType<MargemVendaProdutoInputType>));
            Field(x => x.Pessoa,nullable:true, type:typeof(ListGraphType<PessoaInputType>));
            Field(x => x.PrecarioProduto,nullable:true, type:typeof(ListGraphType<PrecarioProdutoInputType>));
            Field(x => x.ReservasTecnicas,nullable:true, type:typeof(ListGraphType<ReservasTecnicasInputType>));
            Field(x => x.SegmentoOferta,nullable:true, type:typeof(ListGraphType<SegmentoOfertaInputType>));
            Field(x => x.Tarifa,nullable:true, type:typeof(ListGraphType<TarifaInputType>));
            Field(x => x.TipoSegmentoComissionamento,nullable:true, type:typeof(ListGraphType<TipoSegmentoComissionamentoInputType>));
		}
	}
}