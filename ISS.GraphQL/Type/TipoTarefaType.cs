using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoTarefaType : ObjectGraphType<TipoTarefa>
    {
        public TipoTarefaType()
        {
            // Defining the name of the object
            Name = "tipoTarefa";

            Field(x => x.IdTipoTarefa, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.TarefaRecorrenteId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TarefaRecorrenteType>("tarefaRecorrente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefaRecorrente>(c.Source.TarefaRecorrenteId)));
            
        }
    }

    public class TipoTarefaInputType : InputObjectGraphType
	{
		public TipoTarefaInputType()
		{
			// Defining the name of the object
			Name = "tipoTarefaInput";
			
            //Field<StringGraphType>("idTipoTarefa");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("tarefaRecorrenteId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TarefaRecorrenteInputType>("tarefaRecorrente");
			
		}
	}
}