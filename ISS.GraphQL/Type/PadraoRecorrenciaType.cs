using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PadraoRecorrenciaType : ObjectGraphType<PadraoRecorrencia>
    {
        public PadraoRecorrenciaType()
        {
            // Defining the name of the object
            Name = "padraoRecorrencia";

            Field(x => x.IdPadraoRecorrencia, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IntervaloRecorrenciaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<IntervaloRecorrenciaType>("intervaloRecorrencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IntervaloRecorrencia>(c.Source.IntervaloRecorrenciaId)));
            FieldAsync<ListGraphType<RecorrenciaDiarioType>>("recorrenciaDiario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RecorrenciaDiario>(x => x.Where(e => e.HasValue(c.Source.IdPadraoRecorrencia)))));
            FieldAsync<ListGraphType<RecorrenciaMesAnoType>>("recorrenciaMesAno", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RecorrenciaMesAno>(x => x.Where(e => e.HasValue(c.Source.IdPadraoRecorrencia)))));
            FieldAsync<ListGraphType<RecorrenciaSemanalType>>("recorrenciaSemanal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RecorrenciaSemanal>(x => x.Where(e => e.HasValue(c.Source.IdPadraoRecorrencia)))));
            FieldAsync<ListGraphType<TarefaRecorrenteType>>("tarefaRecorrente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefaRecorrente>(x => x.Where(e => e.HasValue(c.Source.IdPadraoRecorrencia)))));
            
        }
    }

    public class PadraoRecorrenciaInputType : InputObjectGraphType
	{
		public PadraoRecorrenciaInputType()
		{
			// Defining the name of the object
			Name = "padraoRecorrenciaInput";
			
            //Field<StringGraphType>("idPadraoRecorrencia");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("intervaloRecorrenciaId");
			Field<EstadoInputType>("estado");
			Field<IntervaloRecorrenciaInputType>("intervaloRecorrencia");
			Field<ListGraphType<RecorrenciaDiarioInputType>>("recorrenciaDiario");
			Field<ListGraphType<RecorrenciaMesAnoInputType>>("recorrenciaMesAno");
			Field<ListGraphType<RecorrenciaSemanalInputType>>("recorrenciaSemanal");
			Field<ListGraphType<TarefaRecorrenteInputType>>("tarefaRecorrente");
			
		}
	}
}