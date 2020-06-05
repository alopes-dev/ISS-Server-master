using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RecorrenciaSemanalType : ObjectGraphType<RecorrenciaSemanal>
    {
        public RecorrenciaSemanalType()
        {
            // Defining the name of the object
            Name = "recorrenciaSemanal";

            Field(x => x.IdRecorrenciaSemanal, nullable: true);
            Field(x => x.PadraoRecorrenciaId, nullable: true);
            Field(x => x.NumeroRecorrenciaSemanal, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DiaSemanaRecorrencia, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.RegenerarNovaTarefaNum, nullable: true, type: typeof(IntGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PadraoRecorrenciaType>("padraoRecorrencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PadraoRecorrencia>(c.Source.PadraoRecorrenciaId)));
            
        }
    }

    public class RecorrenciaSemanalInputType : InputObjectGraphType
	{
		public RecorrenciaSemanalInputType()
		{
			// Defining the name of the object
			Name = "recorrenciaSemanalInput";
			
            //Field<StringGraphType>("idRecorrenciaSemanal");
			Field<StringGraphType>("padraoRecorrenciaId");
			Field<IntGraphType>("numeroRecorrenciaSemanal");
			Field<BooleanGraphType>("diaSemanaRecorrencia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<IntGraphType>("regenerarNovaTarefaNum");
			Field<EstadoInputType>("estado");
			Field<PadraoRecorrenciaInputType>("padraoRecorrencia");
			
		}
	}
}