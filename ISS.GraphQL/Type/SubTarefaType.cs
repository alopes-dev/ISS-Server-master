using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubTarefaType : ObjectGraphType<SubTarefa>
    {
        public SubTarefaType()
        {
            // Defining the name of the object
            Name = "subTarefa";

            Field(x => x.IdSubTarefa, nullable: true);
            Field(x => x.Pcfid, nullable: true);
            Field(x => x.HierarquiaId, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.MetricaDisponivel, nullable: true);
            Field(x => x.IndiceDiferenca, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DetalhesMudanca, nullable: true);
            Field(x => x.TarefaId, nullable: true);
            Field(x => x.CodSubTarefa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TarefaType>("tarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarefa>(c.Source.TarefaId)));
            FieldAsync<ListGraphType<TarefasActividadeType>>("tarefasActividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefasActividade>(x => x.Where(e => e.HasValue(c.Source.IdSubTarefa)))));
            
        }
    }

    public class SubTarefaInputType : InputObjectGraphType
	{
		public SubTarefaInputType()
		{
			// Defining the name of the object
			Name = "subTarefaInput";
			
            //Field<StringGraphType>("idSubTarefa");
			Field<StringGraphType>("pcfid");
			Field<StringGraphType>("hierarquiaId");
			Field<StringGraphType>("nome");
			Field<StringGraphType>("metricaDisponivel");
			Field<IntGraphType>("indiceDiferenca");
			Field<StringGraphType>("detalhesMudanca");
			Field<StringGraphType>("tarefaId");
			Field<StringGraphType>("codSubTarefa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<TarefaInputType>("tarefa");
			Field<ListGraphType<TarefasActividadeInputType>>("tarefasActividade");
			
		}
	}
}