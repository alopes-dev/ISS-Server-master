using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoPrecarioProdutoType : ObjectGraphType<HistoricoPrecarioProduto>
    {
        public HistoricoPrecarioProdutoType()
        {
            // Defining the name of the object
            Name = "historicoPrecarioProduto";

            Field(x => x.IdHistoricoPrecarioProduto, nullable: true);
            Field(x => x.PrecoBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.QtdDiaMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.QtdDiaMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Descricao, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IdPrecarioProduto, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class HistoricoPrecarioProdutoInputType : InputObjectGraphType
	{
		public HistoricoPrecarioProdutoInputType()
		{
			// Defining the name of the object
			Name = "historicoPrecarioProdutoInput";
			
            //Field<StringGraphType>("idHistoricoPrecarioProduto");
			Field<FloatGraphType>("precoBase");
			Field<IntGraphType>("qtdDiaMin");
			Field<IntGraphType>("qtdDiaMax");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("moedaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("idPrecarioProduto");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}