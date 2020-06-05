using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RecorrenciaDiarioType : ObjectGraphType<RecorrenciaDiario>
    {
        public RecorrenciaDiarioType()
        {
            // Defining the name of the object
            Name = "recorrenciaDiario";

            Field(x => x.IdRecorrenciaDiario, nullable: true);
            Field(x => x.PadraoRecorrenciaId, nullable: true);
            Field(x => x.NumeroRecorrenciaDias, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumRegenerarTarefa, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DiaSemanaRecorrencia, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PadraoRecorrenciaType>("padraoRecorrencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PadraoRecorrencia>(c.Source.PadraoRecorrenciaId)));
            
        }
    }

    public class RecorrenciaDiarioInputType : InputObjectGraphType
	{
		public RecorrenciaDiarioInputType()
		{
			// Defining the name of the object
			Name = "recorrenciaDiarioInput";
			
            //Field<StringGraphType>("idRecorrenciaDiario");
			Field<StringGraphType>("padraoRecorrenciaId");
			Field<IntGraphType>("numeroRecorrenciaDias");
			Field<IntGraphType>("numRegenerarTarefa");
			Field<BooleanGraphType>("diaSemanaRecorrencia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PadraoRecorrenciaInputType>("padraoRecorrencia");
			
		}
	}
}