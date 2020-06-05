using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrecarioProdutoType : ObjectGraphType<PrecarioProduto>
    {
        public PrecarioProdutoType()
        {
            // Defining the name of the object
            Name = "precarioProduto";

            Field(x => x.IdPrecarioProduto, nullable: true);
            Field(x => x.PrecoBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.QtdDiaMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.QtdDiaMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Descricao, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CanalId, nullable: true);
            Field(x => x.CustoApolice, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCancelamento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataEstorno, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAnulacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.TaxasId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TaxasType>("taxas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Taxas>(c.Source.TaxasId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<ImpostoPrecarioType>>("impostoPrecario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoPrecario>(x => x.Where(e => e.HasValue(c.Source.IdPrecarioProduto)))));
            FieldAsync<ListGraphType<LinhaProdutoImpostoType>>("linhaProdutoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProdutoImposto>(x => x.Where(e => e.HasValue(c.Source.IdPrecarioProduto)))));
            FieldAsync<ListGraphType<TipoTarifaType>>("tipoTarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTarifa>(x => x.Where(e => e.HasValue(c.Source.IdPrecarioProduto)))));
            
        }
    }

    public class PrecarioProdutoInputType : InputObjectGraphType
	{
		public PrecarioProdutoInputType()
		{
			// Defining the name of the object
			Name = "precarioProdutoInput";
			
            //Field<StringGraphType>("idPrecarioProduto");
			Field<FloatGraphType>("precoBase");
			Field<IntGraphType>("qtdDiaMin");
			Field<IntGraphType>("qtdDiaMax");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("moedaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("canalId");
			Field<FloatGraphType>("custoApolice");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCancelamento");
			Field<DateTimeGraphType>("dataEstorno");
			Field<DateTimeGraphType>("dataAnulacao");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("taxasId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<CanalInputType>("canal");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TaxasInputType>("taxas");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<ListGraphType<ImpostoPrecarioInputType>>("impostoPrecario");
			Field<ListGraphType<LinhaProdutoImpostoInputType>>("linhaProdutoImposto");
			Field<ListGraphType<TipoTarifaInputType>>("tipoTarifa");
			
		}
	}
}