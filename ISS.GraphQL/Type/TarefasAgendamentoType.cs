using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarefasAgendamentoType : ObjectGraphType<TarefasAgendamento>
    {
        public TarefasAgendamentoType()
        {
            // Defining the name of the object
            Name = "tarefasAgendamento";

            Field(x => x.IdTarefa, nullable: true);
            Field(x => x.Assunto, nullable: true);
            Field(x => x.CategoriaId, nullable: true);
            Field(x => x.PrioridadeId, nullable: true);
            Field(x => x.LembreteId, nullable: true);
            Field(x => x.TipoAcompanhamentoId, nullable: true);
            Field(x => x.InformacaoCobranca, nullable: true);
            //FieldAsync<ByteType>("percentagemConcluida", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Byte>(c.Source.IdTarefa)));
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataConclusao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Descricao, nullable: true);
            Field(x => x.TrabalhoTotal, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TrabalhoReal, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CategoriaTarefaId, nullable: true);
            Field(x => x.Processo, nullable: true);
            Field(x => x.IsRecorrente, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PapelId, nullable: true);
            FieldAsync<CategoriaTarefaType>("categoriaTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaTarefa>(c.Source.CategoriaTarefaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PrioridadeType>("prioridade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Prioridade>(c.Source.PrioridadeId)));
            FieldAsync<TipoAcompanhamentoType>("tipoAcompanhamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoAcompanhamento>(c.Source.TipoAcompanhamentoId)));
            FieldAsync<ListGraphType<LembreteType>>("lembrete", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Lembrete>(x => x.Where(e => e.HasValue(c.Source.IdTarefa)))));
            FieldAsync<ListGraphType<TarefaRecorrenteType>>("tarefaRecorrente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefaRecorrente>(x => x.Where(e => e.HasValue(c.Source.IdTarefa)))));
            
        }
    }

    public class TarefasAgendamentoInputType : InputObjectGraphType
	{
		public TarefasAgendamentoInputType()
		{
			// Defining the name of the object
			Name = "tarefasAgendamentoInput";
			
            //Field<StringGraphType>("idTarefa");
			Field<StringGraphType>("assunto");
			Field<StringGraphType>("categoriaId");
			Field<StringGraphType>("prioridadeId");
			Field<StringGraphType>("lembreteId");
			Field<StringGraphType>("tipoAcompanhamentoId");
			Field<StringGraphType>("informacaoCobranca");
			//Field<ByteInputType>("percentagemConcluida");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataConclusao");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("trabalhoTotal");
			Field<DateTimeGraphType>("trabalhoReal");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("categoriaTarefaId");
			Field<StringGraphType>("processo");
			Field<BooleanGraphType>("isRecorrente");
			Field<StringGraphType>("papelId");
			Field<CategoriaTarefaInputType>("categoriaTarefa");
			Field<EstadoInputType>("estado");
			Field<PapelInputType>("papel");
			Field<PessoaInputType>("pessoa");
			Field<PrioridadeInputType>("prioridade");
			Field<TipoAcompanhamentoInputType>("tipoAcompanhamento");
			Field<ListGraphType<LembreteInputType>>("lembrete");
			Field<ListGraphType<TarefaRecorrenteInputType>>("tarefaRecorrente");
			
		}
	}
}