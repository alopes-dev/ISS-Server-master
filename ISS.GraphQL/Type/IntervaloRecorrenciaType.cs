using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class IntervaloRecorrenciaType : ObjectGraphType<IntervaloRecorrencia>
    {
        public IntervaloRecorrenciaType()
        {
            // Defining the name of the object
            Name = "intervaloRecorrencia";

            Field(x => x.IdIntervaloRecorrencia, nullable: true);
            Field(x => x.FormaTerminoId, nullable: true);
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaTerminoType>("formaTermino", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaTermino>(c.Source.FormaTerminoId)));
            FieldAsync<ListGraphType<PadraoRecorrenciaType>>("padraoRecorrencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PadraoRecorrencia>(x => x.Where(e => e.HasValue(c.Source.IdIntervaloRecorrencia)))));
            
        }
    }

    public class IntervaloRecorrenciaInputType : InputObjectGraphType
	{
		public IntervaloRecorrenciaInputType()
		{
			// Defining the name of the object
			Name = "intervaloRecorrenciaInput";
			
            //Field<StringGraphType>("idIntervaloRecorrencia");
			Field<StringGraphType>("formaTerminoId");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<FormaTerminoInputType>("formaTermino");
			Field<ListGraphType<PadraoRecorrenciaInputType>>("padraoRecorrencia");
			
		}
	}
}