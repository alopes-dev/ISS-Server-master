using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FraccionamentoType : ObjectGraphType<Fraccionamento>
    {
        public FraccionamentoType()
        {
            // Defining the name of the object
            Name = "fraccionamento";

            Field(x => x.IdFraccionamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.FormulaBase, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodFraccionamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.DesignacaoCurta, nullable: true);
            Field(x => x.DuracaoTipoContratoId, nullable: true);
            Field(x => x.DivisorPremio, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<DuracaoTipoContratoType>("duracaoTipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DuracaoTipoContrato>(c.Source.DuracaoTipoContratoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<ContratoType>>("contratoFormaFacturacaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdFraccionamento)))));
            FieldAsync<ListGraphType<ContratoType>>("contratoFraccionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdFraccionamento)))));
            FieldAsync<ListGraphType<ContratoType>>("contratoPrazoAlteracaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdFraccionamento)))));
            FieldAsync<ListGraphType<ContratoType>>("contratoPrazoPreAvisoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdFraccionamento)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdFraccionamento)))));
            FieldAsync<ListGraphType<FraccionamentoPlanoType>>("fraccionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FraccionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdFraccionamento)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdFraccionamento)))));
            FieldAsync<ListGraphType<SimulacaoType>>("simulacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Simulacao>(x => x.Where(e => e.HasValue(c.Source.IdFraccionamento)))));
            
        }
    }

    public class FraccionamentoInputType : InputObjectGraphType
	{
		public FraccionamentoInputType()
		{
			// Defining the name of the object
			Name = "fraccionamentoInput";
			
            //Field<StringGraphType>("idFraccionamento");
			Field<StringGraphType>("designacao");
			Field<IntGraphType>("formulaBase");
			Field<StringGraphType>("codFraccionamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("taxa");
			Field<StringGraphType>("tipoOperacaoId");
			Field<StringGraphType>("designacaoCurta");
			Field<StringGraphType>("duracaoTipoContratoId");
			Field<FloatGraphType>("divisorPremio");
			Field<DuracaoTipoContratoInputType>("duracaoTipoContrato");
			Field<EstadoInputType>("estado");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<ListGraphType<ContratoInputType>>("contratoFormaFacturacaoNavigation");
			Field<ListGraphType<ContratoInputType>>("contratoFraccionamento");
			Field<ListGraphType<ContratoInputType>>("contratoPrazoAlteracaoNavigation");
			Field<ListGraphType<ContratoInputType>>("contratoPrazoPreAvisoNavigation");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<FraccionamentoPlanoInputType>>("fraccionamentoPlano");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<SimulacaoInputType>>("simulacao");
			
		}
	}
}