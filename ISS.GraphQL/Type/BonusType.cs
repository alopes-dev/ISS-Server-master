using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BonusType : ObjectGraphType<Bonus>
    {
        public BonusType()
        {
            // Defining the name of the object
            Name = "bonus";

            Field(x => x.IdBonus, nullable: true);
            Field(x => x.TaxaBonus, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.ValorMinPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorMinBonus, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxBonus, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.TipoRecebimentoId, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            Field(x => x.CodBonus, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<CentroCustoType>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(c.Source.CentroCustoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<TipoRecebimentoType>("tipoRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimento>(c.Source.TipoRecebimentoId)));
            
        }
    }

    public class BonusInputType : InputObjectGraphType
	{
		public BonusInputType()
		{
			// Defining the name of the object
			Name = "bonusInput";
			
            //Field<StringGraphType>("idBonus");
			Field<FloatGraphType>("taxaBonus");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<FloatGraphType>("valorMinPremioSimples");
			Field<FloatGraphType>("valorMaxPremioSimples");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("valorMinBonus");
			Field<FloatGraphType>("valorMaxBonus");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("tipoRecebimentoId");
			Field<StringGraphType>("produtorId");
			Field<StringGraphType>("codBonus");
			Field<StringGraphType>("tipoOperacaoId");
			Field<CanalInputType>("canal");
			Field<CentroCustoInputType>("centroCusto");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<PessoaInputType>("produtor");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<TipoRecebimentoInputType>("tipoRecebimento");
			
		}
	}
}