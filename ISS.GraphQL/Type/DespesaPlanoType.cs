using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DespesaPlanoType : ObjectGraphType<DespesaPlano>
    {
        public DespesaPlanoType()
        {
            // Defining the name of the object
            Name = "despesaPlano";

            Field(x => x.IdDespesaPlano, nullable: true);
            Field(x => x.DespesaId, nullable: true);
            Field(x => x.CoberturaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodDespesaPlano, nullable: true);
            FieldAsync<CoberturaType>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaId)));
            FieldAsync<DespesaType>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(c.Source.DespesaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DespesaPlanoInputType : InputObjectGraphType
	{
		public DespesaPlanoInputType()
		{
			// Defining the name of the object
			Name = "despesaPlanoInput";
			
            //Field<StringGraphType>("idDespesaPlano");
			Field<StringGraphType>("despesaId");
			Field<StringGraphType>("coberturaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codDespesaPlano");
			Field<CoberturaInputType>("cobertura");
			Field<DespesaInputType>("despesa");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}