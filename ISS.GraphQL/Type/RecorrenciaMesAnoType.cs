using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RecorrenciaMesAnoType : ObjectGraphType<RecorrenciaMesAno>
    {
        public RecorrenciaMesAnoType()
        {
            // Defining the name of the object
            Name = "recorrenciaMesAno";

            Field(x => x.IdRecorrenciaMesAno, nullable: true);
            Field(x => x.PadraoRecorrenciaId, nullable: true);
            Field(x => x.NumeroInMesOuAno, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DiaSemanaRecorrencia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.RegenerarNovaTarefaNum, nullable: true, type: typeof(IntGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PadraoRecorrenciaType>("padraoRecorrencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PadraoRecorrencia>(c.Source.PadraoRecorrenciaId)));
            
        }
    }

    public class RecorrenciaMesAnoInputType : InputObjectGraphType
	{
		public RecorrenciaMesAnoInputType()
		{
			// Defining the name of the object
			Name = "recorrenciaMesAnoInput";
			
            //Field<StringGraphType>("idRecorrenciaMesAno");
			Field<StringGraphType>("padraoRecorrenciaId");
			Field<IntGraphType>("numeroInMesOuAno");
			Field<StringGraphType>("diaSemanaRecorrencia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<IntGraphType>("regenerarNovaTarefaNum");
			Field<EstadoInputType>("estado");
			Field<PadraoRecorrenciaInputType>("padraoRecorrencia");
			
		}
	}
}