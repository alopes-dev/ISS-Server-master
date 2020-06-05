using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCombustivelType : ObjectGraphType<TipoCombustivel>
    {
        public TipoCombustivelType()
        {
            // Defining the name of the object
            Name = "tipoCombustivel";

            Field(x => x.IdTipoCombustivel, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            
        }
    }

    public class TipoCombustivelInputType : InputObjectGraphType
	{
		public TipoCombustivelInputType()
		{
			// Defining the name of the object
			Name = "tipoCombustivelInput";
			
            //Field<StringGraphType>("idTipoCombustivel");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			
		}
	}
}