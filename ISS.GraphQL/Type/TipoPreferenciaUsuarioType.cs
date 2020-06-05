using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPreferenciaUsuarioType : ObjectGraphType<TipoPreferenciaUsuario>
    {
        public TipoPreferenciaUsuarioType()
        {
            // Defining the name of the object
            Name = "tipoPreferenciaUsuario";

            Field(x => x.IdTipoTipoPreferenciaUsuario, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoPreferenciaUsuario, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            
        }
    }

    public class TipoPreferenciaUsuarioInputType : InputObjectGraphType
	{
		public TipoPreferenciaUsuarioInputType()
		{
			// Defining the name of the object
			Name = "tipoPreferenciaUsuarioInput";
			
            //Field<StringGraphType>("idTipoTipoPreferenciaUsuario");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoPreferenciaUsuario");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			
		}
	}
}