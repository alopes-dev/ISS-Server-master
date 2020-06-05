using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OperacoesRecebimentoType : ObjectGraphType<OperacoesRecebimento>
    {
        public OperacoesRecebimentoType()
        {
            // Defining the name of the object
            Name = "operacoesRecebimento";

            Field(x => x.IdOperacoesRecebimento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodigoOperacoesRecebimento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.HistoricoPadraoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<HistoricoPadraoType>("historicoPadrao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HistoricoPadrao>(c.Source.HistoricoPadraoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class OperacoesRecebimentoInputType : InputObjectGraphType
	{
		public OperacoesRecebimentoInputType()
		{
			// Defining the name of the object
			Name = "operacoesRecebimentoInput";
			
            //Field<StringGraphType>("idOperacoesRecebimento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codigoOperacoesRecebimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("historicoPadraoId");
			Field<StringGraphType>("planoProdutoId");
			Field<EstadoInputType>("estado");
			Field<HistoricoPadraoInputType>("historicoPadrao");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}