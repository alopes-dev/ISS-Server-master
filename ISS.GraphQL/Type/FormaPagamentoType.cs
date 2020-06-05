using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormaPagamentoType : ObjectGraphType<FormaPagamento>
    {
        public FormaPagamentoType()
        {
            // Defining the name of the object
            Name = "formaPagamento";

            Field(x => x.IdFormaPagamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CaminhoImagem, nullable: true);
            Field(x => x.CodFormaPagamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoPopUp, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CaminhoImagemWeb, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CaixaType>>("caixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Caixa>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<CoPagamentoType>>("coPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoPagamento>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<ComissionamentoType>>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<ContratoType>>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<ContratoFormaPagamentoType>>("contratoFormaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoFormaPagamento>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<FormaPagamentoPlanoType>>("formaPagamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<ModalidadeReembolsoType>>("modalidadeReembolso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadeReembolso>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<NivelCompetenciaType>>("nivelCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<TipoCartaoType>>("tipoCartao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCartao>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            FieldAsync<ListGraphType<TipoCartaoPagamentoType>>("tipoCartaoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCartaoPagamento>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamento)))));
            
        }
    }

    public class FormaPagamentoInputType : InputObjectGraphType
	{
		public FormaPagamentoInputType()
		{
			// Defining the name of the object
			Name = "formaPagamentoInput";
			
            //Field<StringGraphType>("idFormaPagamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("caminhoImagem");
			Field<StringGraphType>("codFormaPagamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoPopUp");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("caminhoImagemWeb");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CaixaInputType>>("caixa");
			Field<ListGraphType<CoPagamentoInputType>>("coPagamento");
			Field<ListGraphType<ComissionamentoInputType>>("comissionamento");
			Field<ListGraphType<ContratoInputType>>("contrato");
			Field<ListGraphType<ContratoFormaPagamentoInputType>>("contratoFormaPagamento");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<FormaPagamentoPlanoInputType>>("formaPagamentoPlano");
			Field<ListGraphType<ModalidadeReembolsoInputType>>("modalidadeReembolso");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<NivelCompetenciaInputType>>("nivelCompetencia");
			Field<ListGraphType<TipoCartaoInputType>>("tipoCartao");
			Field<ListGraphType<TipoCartaoPagamentoInputType>>("tipoCartaoPagamento");
			
		}
	}
}