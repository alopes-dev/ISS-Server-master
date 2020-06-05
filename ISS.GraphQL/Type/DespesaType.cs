using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DespesaType : ObjectGraphType<Despesa>
    {
        public DespesaType()
        {
            // Defining the name of the object
            Name = "despesa";

            Field(x => x.IdDespesa, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoDespesaId, nullable: true);
            Field(x => x.CodDespesa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.TipoRecebimentoId, nullable: true);
            Field(x => x.LocalAplicacaoId, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            Field(x => x.CoberturaId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NivelRiscoId, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<CentroCustoType>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(c.Source.CentroCustoId)));
            FieldAsync<CoberturaType>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LocalAplicacaoPlanoType>("localAplicacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalAplicacaoPlano>(c.Source.LocalAplicacaoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<TipoDespesaType>("tipoDespesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDespesa>(c.Source.TipoDespesaId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<TipoRecebimentoType>("tipoRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimento>(c.Source.TipoRecebimentoId)));
            FieldAsync<ListGraphType<AgravamentoDespesaType>>("agravamentoDespesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoDespesa>(x => x.Where(e => e.HasValue(c.Source.IdDespesa)))));
            FieldAsync<ListGraphType<DespesaLinhaType>>("despesaLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DespesaLinha>(x => x.Where(e => e.HasValue(c.Source.IdDespesa)))));
            FieldAsync<ListGraphType<DespesaPlanoType>>("despesaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DespesaPlano>(x => x.Where(e => e.HasValue(c.Source.IdDespesa)))));
            FieldAsync<ListGraphType<DespesaSeleccionadaType>>("despesaSeleccionada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DespesaSeleccionada>(x => x.Where(e => e.HasValue(c.Source.IdDespesa)))));
            FieldAsync<ListGraphType<DespesasCoberturaType>>("despesasCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DespesasCobertura>(x => x.Where(e => e.HasValue(c.Source.IdDespesa)))));
            FieldAsync<ListGraphType<DespesasTipoContaType>>("despesasTipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DespesasTipoConta>(x => x.Where(e => e.HasValue(c.Source.IdDespesa)))));
            
        }
    }

    public class DespesaInputType : InputObjectGraphType
	{
		public DespesaInputType()
		{
			// Defining the name of the object
			Name = "despesaInput";
			
            //Field<StringGraphType>("idDespesa");
			Field<FloatGraphType>("valorMin");
			Field<StringGraphType>("tipoDespesaId");
			Field<StringGraphType>("codDespesa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("valorMax");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("tipoRecebimentoId");
			Field<StringGraphType>("localAplicacaoId");
			Field<StringGraphType>("produtorId");
			Field<StringGraphType>("coberturaId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("taxa");
			Field<StringGraphType>("nivelRiscoId");
			Field<CanalInputType>("canal");
			Field<CentroCustoInputType>("centroCusto");
			Field<CoberturaInputType>("cobertura");
			Field<EstadoInputType>("estado");
			Field<LocalAplicacaoPlanoInputType>("localAplicacao");
			Field<MoedaInputType>("moeda");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<PessoaInputType>("produtor");
			Field<TipoDespesaInputType>("tipoDespesa");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<TipoRecebimentoInputType>("tipoRecebimento");
			Field<ListGraphType<AgravamentoDespesaInputType>>("agravamentoDespesa");
			Field<ListGraphType<DespesaLinhaInputType>>("despesaLinha");
			Field<ListGraphType<DespesaPlanoInputType>>("despesaPlano");
			Field<ListGraphType<DespesaSeleccionadaInputType>>("despesaSeleccionada");
			Field<ListGraphType<DespesasCoberturaInputType>>("despesasCobertura");
			Field<ListGraphType<DespesasTipoContaInputType>>("despesasTipoConta");
			
		}
	}
}