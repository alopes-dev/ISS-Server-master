using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoContagemType : ObjectGraphType<TipoContagem>
    {
        public TipoContagemType()
        {
            // Defining the name of the object
            Name = "tipoContagem";

            Field(x => x.IdTipoContagem, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoContagem, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            
        }
    }

    public class TipoContagemInputType : InputObjectGraphType
	{
		public TipoContagemInputType()
		{
			// Defining the name of the object
			Name = "tipoContagemInput";
			
            //Field<StringGraphType>("idTipoContagem");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoContagem");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			
		}
	}
}