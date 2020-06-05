using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarifaType : ObjectGraphType<Tarifa>
    {
        public TarifaType()
        {
            // Defining the name of the object
            Name = "tarifa";

            Field(x => x.IdTarifa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoTarifaId, nullable: true);
            Field(x => x.ClasseRiscoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.TipoRecebimentoId, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.IsPadrao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<CentroCustoType>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(c.Source.CentroCustoId)));
            FieldAsync<ClasseRiscoType>("classeRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClasseRisco>(c.Source.ClasseRiscoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<TipoRecebimentoType>("tipoRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimento>(c.Source.TipoRecebimentoId)));
            FieldAsync<TipoTarifaType>("tipoTarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTarifa>(c.Source.TipoTarifaId)));
            FieldAsync<ListGraphType<AgravamentoType>>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(x => x.Where(e => e.HasValue(c.Source.IdTarifa)))));
            FieldAsync<ListGraphType<CondicaoTarifaType>>("condicaoTarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoTarifa>(x => x.Where(e => e.HasValue(c.Source.IdTarifa)))));
            
        }
    }

    public class TarifaInputType : InputObjectGraphType
	{
		public TarifaInputType()
		{
			// Defining the name of the object
			Name = "tarifaInput";
			
            //Field<StringGraphType>("idTarifa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoTarifaId");
			Field<StringGraphType>("classeRiscoId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("tipoRecebimentoId");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("produtoId");
			Field<BooleanGraphType>("isPadrao");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("linhaProdutoId");
			Field<CanalInputType>("canal");
			Field<CentroCustoInputType>("centroCusto");
			Field<ClasseRiscoInputType>("classeRisco");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<PapelInputType>("papel");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ProdutoInputType>("produto");
			Field<PlanoContasInputType>("subConta");
			Field<TipoRecebimentoInputType>("tipoRecebimento");
			Field<TipoTarifaInputType>("tipoTarifa");
			Field<ListGraphType<AgravamentoInputType>>("agravamento");
			Field<ListGraphType<CondicaoTarifaInputType>>("condicaoTarifa");
			
		}
	}
}