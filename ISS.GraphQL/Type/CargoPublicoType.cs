using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CargoPublicoType : ObjectGraphType<CargoPublico>
    {
        public CargoPublicoType()
        {
            // Defining the name of the object
            Name = "cargoPublico";

            Field(x => x.IdCargoPublico, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CargoPublicoInputType : InputObjectGraphType
	{
		public CargoPublicoInputType()
		{
			// Defining the name of the object
			Name = "cargoPublicoInput";
			
            //Field<StringGraphType>("idCargoPublico");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}