using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarefaRecorrenteType : ObjectGraphType<TarefaRecorrente>
    {
        public TarefaRecorrenteType()
        {
            // Defining the name of the object
            Name = "tarefaRecorrente";

            Field(x => x.IdTarefaRecorrente, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PadraoRecorrenciaId, nullable: true);
            Field(x => x.TarefasAgendamentoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PadraoRecorrenciaType>("padraoRecorrencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PadraoRecorrencia>(c.Source.PadraoRecorrenciaId)));
            FieldAsync<TarefasAgendamentoType>("tarefasAgendamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefasAgendamento>(c.Source.TarefasAgendamentoId)));
            FieldAsync<ListGraphType<TipoTarefaType>>("tipoTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTarefa>(x => x.Where(e => e.HasValue(c.Source.IdTarefaRecorrente)))));
            
        }
    }

    public class TarefaRecorrenteInputType : InputObjectGraphType
	{
		public TarefaRecorrenteInputType()
		{
			// Defining the name of the object
			Name = "tarefaRecorrenteInput";
			
            //Field<StringGraphType>("idTarefaRecorrente");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("padraoRecorrenciaId");
			Field<StringGraphType>("tarefasAgendamentoId");
			Field<EstadoInputType>("estado");
			Field<PadraoRecorrenciaInputType>("padraoRecorrencia");
			Field<TarefasAgendamentoInputType>("tarefasAgendamento");
			Field<ListGraphType<TipoTarefaInputType>>("tipoTarefa");
			
		}
	}
}