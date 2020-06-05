using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgravamentoType : ObjectGraphType<Agravamento>
    {
        public AgravamentoType()
        {
            // Defining the name of the object
            Name = "agravamento";

            Field(x => x.IdAgravamento, nullable: true);
            Field(x => x.TaxaAgravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoAgravamentoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.TaxaBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.TipoRecebimentoId, nullable: true);
            Field(x => x.LocalAplicacaoId, nullable: true);
            Field(x => x.CodAgravamento, nullable: true);
            Field(x => x.TarifaId, nullable: true);
            Field(x => x.IdadeMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.IdadeMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<CentroCustoType>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(c.Source.CentroCustoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LocalAplicacaoPlanoType>("localAplicacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalAplicacaoPlano>(c.Source.LocalAplicacaoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<TarifaType>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(c.Source.TarifaId)));
            FieldAsync<TipoAgravamentoType>("tipoAgravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoAgravamento>(c.Source.TipoAgravamentoId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<TipoRecebimentoType>("tipoRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimento>(c.Source.TipoRecebimentoId)));
            FieldAsync<ListGraphType<AgravamentoApoliceType>>("agravamentoApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoApolice>(x => x.Where(e => e.HasValue(c.Source.IdAgravamento)))));
            FieldAsync<ListGraphType<AgravamentoDespesaType>>("agravamentoDespesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoDespesa>(x => x.Where(e => e.HasValue(c.Source.IdAgravamento)))));
            FieldAsync<ListGraphType<AgravamentoLinhaType>>("agravamentoLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoLinha>(x => x.Where(e => e.HasValue(c.Source.IdAgravamento)))));
            FieldAsync<ListGraphType<AgravamentoPessoaType>>("agravamentoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdAgravamento)))));
            FieldAsync<ListGraphType<AgravamentoPlanoType>>("agravamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdAgravamento)))));
            FieldAsync<ListGraphType<CondicaoAplicacaoAgravamentoType>>("condicaoAplicacaoAgravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoAplicacaoAgravamento>(x => x.Where(e => e.HasValue(c.Source.IdAgravamento)))));
            
        }
    }

    public class AgravamentoInputType : InputObjectGraphType
	{
		public AgravamentoInputType()
		{
			// Defining the name of the object
			Name = "agravamentoInput";
			
            //Field<StringGraphType>("idAgravamento");
			Field<FloatGraphType>("taxaAgravamento");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("tipoAgravamentoId");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<FloatGraphType>("taxaBase");
			Field<FloatGraphType>("taxaMin");
			Field<FloatGraphType>("taxaMax");
			Field<FloatGraphType>("premioBase");
			Field<FloatGraphType>("premioMax");
			Field<FloatGraphType>("premioMin");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("tipoRecebimentoId");
			Field<StringGraphType>("localAplicacaoId");
			Field<StringGraphType>("codAgravamento");
			Field<StringGraphType>("tarifaId");
			Field<IntGraphType>("idadeMin");
			Field<IntGraphType>("idadeMax");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<CentroCustoInputType>("centroCusto");
			Field<EstadoInputType>("estado");
			Field<LocalAplicacaoPlanoInputType>("localAplicacao");
			Field<MoedaInputType>("moeda");
			Field<TarifaInputType>("tarifa");
			Field<TipoAgravamentoInputType>("tipoAgravamento");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<TipoRecebimentoInputType>("tipoRecebimento");
			Field<ListGraphType<AgravamentoApoliceInputType>>("agravamentoApolice");
			Field<ListGraphType<AgravamentoDespesaInputType>>("agravamentoDespesa");
			Field<ListGraphType<AgravamentoLinhaInputType>>("agravamentoLinha");
			Field<ListGraphType<AgravamentoPessoaInputType>>("agravamentoPessoa");
			Field<ListGraphType<AgravamentoPlanoInputType>>("agravamentoPlano");
			Field<ListGraphType<CondicaoAplicacaoAgravamentoInputType>>("condicaoAplicacaoAgravamento");
			
		}
	}
}