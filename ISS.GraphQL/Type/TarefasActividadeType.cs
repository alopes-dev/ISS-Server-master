using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarefasActividadeType : ObjectGraphType<TarefasActividade>
    {
        public TarefasActividadeType()
        {
            // Defining the name of the object
            Name = "tarefasActividade";

            Field(x => x.IdTarefasActividade, nullable: true);
            Field(x => x.ActividadeId, nullable: true);
            Field(x => x.TarefaId, nullable: true);
            Field(x => x.SubTarefaId, nullable: true);
            FieldAsync<ActividadeType>("actividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Actividade>(c.Source.ActividadeId)));
            FieldAsync<SubTarefaType>("subTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTarefa>(c.Source.SubTarefaId)));
            FieldAsync<TarefaType>("tarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarefa>(c.Source.TarefaId)));
            
        }
    }

    public class TarefasActividadeInputType : InputObjectGraphType
	{
		public TarefasActividadeInputType()
		{
			// Defining the name of the object
			Name = "tarefasActividadeInput";
			
            //Field<StringGraphType>("idTarefasActividade");
			Field<StringGraphType>("actividadeId");
			Field<StringGraphType>("tarefaId");
			Field<StringGraphType>("subTarefaId");
			Field<ActividadeInputType>("actividade");
			Field<SubTarefaInputType>("subTarefa");
			Field<TarefaInputType>("tarefa");
			
		}
	}
}