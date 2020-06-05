using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarefaType : ObjectGraphType<Tarefa>
    {
        public TarefaType()
        {
            // Defining the name of the object
            Name = "tarefa";

            Field(x => x.IdTarefa, nullable: true);
            Field(x => x.Pcfid, nullable: true);
            Field(x => x.HierarquiaId, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.MetricaDisponivel, nullable: true);
            Field(x => x.IndiceDiferenca, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DetalhesMudanca, nullable: true);
            Field(x => x.CodTarefa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.NivelRiscoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PrioridadeId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<PrioridadeType>("prioridade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Prioridade>(c.Source.PrioridadeId)));
            FieldAsync<ListGraphType<PessoaTarefaType>>("pessoaTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaTarefa>(x => x.Where(e => e.HasValue(c.Source.IdTarefa)))));
            FieldAsync<ListGraphType<SubTarefaType>>("subTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTarefa>(x => x.Where(e => e.HasValue(c.Source.IdTarefa)))));
            FieldAsync<ListGraphType<SubscricaoCessaoRetencaoType>>("subscricaoCessaoRetencao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubscricaoCessaoRetencao>(x => x.Where(e => e.HasValue(c.Source.IdTarefa)))));
            FieldAsync<ListGraphType<TarefaPlanoType>>("tarefaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefaPlano>(x => x.Where(e => e.HasValue(c.Source.IdTarefa)))));
            FieldAsync<ListGraphType<TarefasActividadeType>>("tarefasActividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefasActividade>(x => x.Where(e => e.HasValue(c.Source.IdTarefa)))));
            
        }
    }

    public class TarefaInputType : InputObjectGraphType
	{
		public TarefaInputType()
		{
			// Defining the name of the object
			Name = "tarefaInput";
			
            //Field<StringGraphType>("idTarefa");
			Field<StringGraphType>("pcfid");
			Field<StringGraphType>("hierarquiaId");
			Field<StringGraphType>("nome");
			Field<StringGraphType>("metricaDisponivel");
			Field<IntGraphType>("indiceDiferenca");
			Field<StringGraphType>("detalhesMudanca");
			Field<StringGraphType>("codTarefa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("nivelRiscoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("prioridadeId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<DireccaoInputType>("direccao");
			Field<EstadoInputType>("estado");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<PrioridadeInputType>("prioridade");
			Field<ListGraphType<PessoaTarefaInputType>>("pessoaTarefa");
			Field<ListGraphType<SubTarefaInputType>>("subTarefa");
			Field<ListGraphType<SubscricaoCessaoRetencaoInputType>>("subscricaoCessaoRetencao");
			Field<ListGraphType<TarefaPlanoInputType>>("tarefaPlano");
			Field<ListGraphType<TarefasActividadeInputType>>("tarefasActividade");
			
		}
	}
}