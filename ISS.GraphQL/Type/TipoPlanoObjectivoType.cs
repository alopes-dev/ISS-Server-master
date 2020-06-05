using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPlanoObjectivoType : ObjectGraphType<TipoPlanoObjectivo>
    {
        public TipoPlanoObjectivoType()
        {
            // Defining the name of the object
            Name = "tipoPlanoObjectivo";

            Field(x => x.IdTipoObjectivo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodObjectivo, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoPlanoObjectivoInputType : InputObjectGraphType
	{
		public TipoPlanoObjectivoInputType()
		{
			// Defining the name of the object
			Name = "tipoPlanoObjectivoInput";
			
            //Field<StringGraphType>("idTipoObjectivo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codObjectivo");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}