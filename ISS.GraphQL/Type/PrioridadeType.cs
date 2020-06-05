using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrioridadeType : ObjectGraphType<Prioridade>
    {
        public PrioridadeType()
        {
            // Defining the name of the object
            Name = "prioridade";

            Field(x => x.IdPrioridade, nullable: true);
            Field(x => x.CodPrioridade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<NotaType>>("nota", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Nota>(x => x.Where(e => e.HasValue(c.Source.IdPrioridade)))));
            FieldAsync<ListGraphType<TarefaType>>("tarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarefa>(x => x.Where(e => e.HasValue(c.Source.IdPrioridade)))));
            FieldAsync<ListGraphType<TarefasAgendamentoType>>("tarefasAgendamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefasAgendamento>(x => x.Where(e => e.HasValue(c.Source.IdPrioridade)))));
            
        }
    }

    public class PrioridadeInputType : InputObjectGraphType
	{
		public PrioridadeInputType()
		{
			// Defining the name of the object
			Name = "prioridadeInput";
			
            //Field<StringGraphType>("idPrioridade");
			Field<StringGraphType>("codPrioridade");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<NotaInputType>>("nota");
			Field<ListGraphType<TarefaInputType>>("tarefa");
			Field<ListGraphType<TarefasAgendamentoInputType>>("tarefasAgendamento");
			
		}
	}
}