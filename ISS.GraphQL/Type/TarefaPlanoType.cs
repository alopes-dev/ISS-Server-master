using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarefaPlanoType : ObjectGraphType<TarefaPlano>
    {
        public TarefaPlanoType()
        {
            // Defining the name of the object
            Name = "tarefaPlano";

            Field(x => x.IdTarefaPlano, nullable: true);
            Field(x => x.TarefaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TarefaType>("tarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarefa>(c.Source.TarefaId)));
            
        }
    }

    public class TarefaPlanoInputType : InputObjectGraphType
	{
		public TarefaPlanoInputType()
		{
			// Defining the name of the object
			Name = "tarefaPlanoInput";
			
            //Field<StringGraphType>("idTarefaPlano");
			Field<StringGraphType>("tarefaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("planoProdutoId");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TarefaInputType>("tarefa");
			
		}
	}
}