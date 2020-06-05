using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaTarefaType : ObjectGraphType<CategoriaTarefa>
    {
        public CategoriaTarefaType()
        {
            // Defining the name of the object
            Name = "categoriaTarefa";

            Field(x => x.IdCategoria, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CorId, nullable: true);
            FieldAsync<CorType>("cor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cor>(c.Source.CorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<NotaType>>("nota", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Nota>(x => x.Where(e => e.HasValue(c.Source.IdCategoria)))));
            FieldAsync<ListGraphType<TarefasAgendamentoType>>("tarefasAgendamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefasAgendamento>(x => x.Where(e => e.HasValue(c.Source.IdCategoria)))));
            
        }
    }

    public class CategoriaTarefaInputType : InputObjectGraphType
	{
		public CategoriaTarefaInputType()
		{
			// Defining the name of the object
			Name = "categoriaTarefaInput";
			
            //Field<StringGraphType>("idCategoria");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("corId");
			Field<CorInputType>("cor");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<NotaInputType>>("nota");
			Field<ListGraphType<TarefasAgendamentoInputType>>("tarefasAgendamento");
			
		}
	}
}