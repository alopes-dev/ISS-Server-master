using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoEmbarcacaoType : ObjectGraphType<TipoEmbarcacao>
    {
        public TipoEmbarcacaoType()
        {
            // Defining the name of the object
            Name = "tipoEmbarcacao";

            Field(x => x.IdTipoEmbarcacao, nullable: true);
            Field(x => x.CodTipoEmbarcacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Criterio, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoEmbarcacaoInputType : InputObjectGraphType
	{
		public TipoEmbarcacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoEmbarcacaoInput";
			
            //Field<StringGraphType>("idTipoEmbarcacao");
			Field<StringGraphType>("codTipoEmbarcacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("criterio");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}