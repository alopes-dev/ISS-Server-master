using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComissionamentoType : ObjectGraphType<Comissionamento>
    {
        public ComissionamentoType()
        {
            // Defining the name of the object
            Name = "comissionamento";

            Field(x => x.IdComissionamento, nullable: true);
            Field(x => x.Desconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CanalId, nullable: true);
            Field(x => x.SegmentoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.SectorActividadeId, nullable: true);
            Field(x => x.CapitalMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CapitalMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FormaPagamentoId, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CaixaId, nullable: true);
            Field(x => x.TaxaComissionamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<CaixaType>("caixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Caixa>(c.Source.CaixaId)));
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<SectorActividadeType>("sectorActividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividade>(c.Source.SectorActividadeId)));
            FieldAsync<SegmentoProdutoType>("segmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoProduto>(c.Source.SegmentoId)));
            FieldAsync<ListGraphType<CanaisComissionamentoType>>("canaisComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanaisComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<CanalComissionamentoType>>("canalComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<ComissaoType>>("comissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissao>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<ComissionamentoPlanoType>>("comissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<FidelizacaoComissionamentoType>>("fidelizacaoComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FidelizacaoComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<ProvinciaComissionamentoType>>("provinciaComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciaComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<SectorActividadeComissionamentoType>>("sectorActividadeComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadeComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<SubscricaoCessaoRetencaoType>>("subscricaoCessaoRetencao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubscricaoCessaoRetencao>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<TipoComissionamentoResseguroType>>("tipoComissionamentoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoComissionamentoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<TipoSegmentoComissionamentoType>>("tipoSegmentoComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            FieldAsync<ListGraphType<TipoSegmentosComissionamentoType>>("tipoSegmentosComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentosComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdComissionamento)))));
            
        }
    }

    public class ComissionamentoInputType : InputObjectGraphType
	{
		public ComissionamentoInputType()
		{
			// Defining the name of the object
			Name = "comissionamentoInput";
			
            //Field<StringGraphType>("idComissionamento");
			Field<FloatGraphType>("desconto");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("segmentoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("sectorActividadeId");
			Field<FloatGraphType>("capitalMin");
			Field<FloatGraphType>("capitalMax");
			Field<StringGraphType>("formaPagamentoId");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("caixaId");
			Field<FloatGraphType>("taxaComissionamento");
			Field<StringGraphType>("contratoId");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<StringGraphType>("planoProdutoId");
			Field<CaixaInputType>("caixa");
			Field<CanalInputType>("canal");
			Field<ContratoInputType>("contrato");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoInputType>("formaPagamento");
			Field<PapelInputType>("papel");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<SectorActividadeInputType>("sectorActividade");
			Field<SegmentoProdutoInputType>("segmento");
			Field<ListGraphType<CanaisComissionamentoInputType>>("canaisComissionamento");
			Field<ListGraphType<CanalComissionamentoInputType>>("canalComissionamento");
			Field<ListGraphType<ComissaoInputType>>("comissao");
			Field<ListGraphType<ComissionamentoPlanoInputType>>("comissionamentoPlano");
			Field<ListGraphType<FidelizacaoComissionamentoInputType>>("fidelizacaoComissionamento");
			Field<ListGraphType<ProvinciaComissionamentoInputType>>("provinciaComissionamento");
			Field<ListGraphType<SectorActividadeComissionamentoInputType>>("sectorActividadeComissionamento");
			Field<ListGraphType<SubscricaoCessaoRetencaoInputType>>("subscricaoCessaoRetencao");
			Field<ListGraphType<TipoComissionamentoResseguroInputType>>("tipoComissionamentoResseguro");
			Field<ListGraphType<TipoSegmentoComissionamentoInputType>>("tipoSegmentoComissionamento");
			Field<ListGraphType<TipoSegmentosComissionamentoInputType>>("tipoSegmentosComissionamento");
			
		}
	}
}