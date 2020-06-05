using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LembreteType : ObjectGraphType<Lembrete>
    {
        public LembreteType()
        {
            // Defining the name of the object
            Name = "lembrete";

            Field(x => x.IdLembrete, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            //FieldAsync<TimeSpanType>("hora", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TimeSpan>(c.Source.IdLembrete)));
            Field(x => x.Data, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TarefaAgendamentoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TarefasAgendamentoType>("tarefaAgendamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefasAgendamento>(c.Source.TarefaAgendamentoId)));
            
        }
    }

    public class LembreteInputType : InputObjectGraphType
	{
		public LembreteInputType()
		{
			// Defining the name of the object
			Name = "lembreteInput";
			
            //Field<StringGraphType>("idLembrete");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			//Field<TimeSpanInputType>("hora");
			Field<DateTimeGraphType>("data");
			Field<StringGraphType>("tarefaAgendamentoId");
			Field<EstadoInputType>("estado");
			Field<TarefasAgendamentoInputType>("tarefaAgendamento");
			
		}
	}
}