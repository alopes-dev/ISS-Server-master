using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoAcompanhamentoType : ObjectGraphType<TipoAcompanhamento>
    {
        public TipoAcompanhamentoType()
        {
            // Defining the name of the object
            Name = "tipoAcompanhamento";

            Field(x => x.IdTipoAcompanhamento, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TarefasAgendamentoType>>("tarefasAgendamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefasAgendamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoAcompanhamento)))));
            
        }
    }

    public class TipoAcompanhamentoInputType : InputObjectGraphType
	{
		public TipoAcompanhamentoInputType()
		{
			// Defining the name of the object
			Name = "tipoAcompanhamentoInput";
			
            //Field<StringGraphType>("idTipoAcompanhamento");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TarefasAgendamentoInputType>>("tarefasAgendamento");
			
		}
	}
}