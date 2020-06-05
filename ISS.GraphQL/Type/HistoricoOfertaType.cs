using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoOfertaType : ObjectGraphType<HistoricoOferta>
    {
        public HistoricoOfertaType()
        {
            // Defining the name of the object
            Name = "historicoOferta";

            Field(x => x.IdHistoricoOferta, nullable: true);
            Field(x => x.IdOferta, nullable: true);
            Field(x => x.TaxaOferta, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoOfertaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodOferta, nullable: true);
            Field(x => x.ValorMinPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PapelId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TaxaMaxOferta, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMinOferta, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxOferta, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.PrecarioProdutoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<OfertaLinhaType>>("ofertaLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OfertaLinha>(x => x.Where(e => e.HasValue(c.Source.IdHistoricoOferta)))));
            FieldAsync<ListGraphType<OfertaPlanoType>>("ofertaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OfertaPlano>(x => x.Where(e => e.HasValue(c.Source.IdHistoricoOferta)))));
            
        }
    }

    public class HistoricoOfertaInputType : InputObjectGraphType
	{
		public HistoricoOfertaInputType()
		{
			// Defining the name of the object
			Name = "historicoOfertaInput";
			
            //Field<StringGraphType>("idHistoricoOferta");
			Field<StringGraphType>("idOferta");
			Field<FloatGraphType>("taxaOferta");
			Field<StringGraphType>("tipoOfertaId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codOferta");
			Field<FloatGraphType>("valorMinPremioSimples");
			Field<FloatGraphType>("valorMaxPremioSimples");
			Field<StringGraphType>("papelId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("taxaMaxOferta");
			Field<FloatGraphType>("valorMinOferta");
			Field<FloatGraphType>("valorMaxOferta");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("precarioProdutoId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<MoedaInputType>("moeda");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<ListGraphType<OfertaLinhaInputType>>("ofertaLinha");
			Field<ListGraphType<OfertaPlanoInputType>>("ofertaPlano");
			
		}
	}
}