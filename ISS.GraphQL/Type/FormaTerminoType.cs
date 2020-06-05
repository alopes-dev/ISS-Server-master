using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormaTerminoType : ObjectGraphType<FormaTermino>
    {
        public FormaTerminoType()
        {
            // Defining the name of the object
            Name = "formaTermino";

            Field(x => x.IdFormaTermino, nullable: true);
            Field(x => x.DataTermino, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NumOcorrencia, nullable: true, type: typeof(IntGraphType));
            Field(x => x.TipoTerminoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoTerminoType>("tipoTermino", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTermino>(c.Source.TipoTerminoId)));
            FieldAsync<ListGraphType<IntervaloRecorrenciaType>>("intervaloRecorrencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IntervaloRecorrencia>(x => x.Where(e => e.HasValue(c.Source.IdFormaTermino)))));
            
        }
    }

    public class FormaTerminoInputType : InputObjectGraphType
	{
		public FormaTerminoInputType()
		{
			// Defining the name of the object
			Name = "formaTerminoInput";
			
            //Field<StringGraphType>("idFormaTermino");
			Field<DateTimeGraphType>("dataTermino");
			Field<IntGraphType>("numOcorrencia");
			Field<StringGraphType>("tipoTerminoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TipoTerminoInputType>("tipoTermino");
			Field<ListGraphType<IntervaloRecorrenciaInputType>>("intervaloRecorrencia");
			
		}
	}
}