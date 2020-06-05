using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NotasType : ObjectGraphType<Notas>
    {
        public NotasType()
        {
            // Defining the name of the object
            Name = "notas";

            Field(x => x.IdNotas, nullable: true);
            Field(x => x.CodNotas, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Nota, nullable: true);
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdNotas)))));
            
        }
    }

    public class NotasInputType : InputObjectGraphType
	{
		public NotasInputType()
		{
			// Defining the name of the object
			Name = "notasInput";
			
            //Field<StringGraphType>("idNotas");
			Field<StringGraphType>("codNotas");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("nota");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			
		}
	}
}