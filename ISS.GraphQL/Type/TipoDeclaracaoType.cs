using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoDeclaracaoType : ObjectGraphType<TipoDeclaracao>
    {
        public TipoDeclaracaoType()
        {
            // Defining the name of the object
            Name = "tipoDeclaracao";

            Field(x => x.IdTipoDeclaracao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoDeclaracao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            
        }
    }

    public class TipoDeclaracaoInputType : InputObjectGraphType
	{
		public TipoDeclaracaoInputType()
		{
			// Defining the name of the object
			Name = "tipoDeclaracaoInput";
			
            //Field<StringGraphType>("idTipoDeclaracao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoDeclaracao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			
		}
	}
}