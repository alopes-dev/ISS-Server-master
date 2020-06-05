using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CasosInconsideravelAcidentePessoalType : ObjectGraphType<CasosInconsideravelAcidentePessoal>
    {
        public CasosInconsideravelAcidentePessoalType()
        {
            // Defining the name of the object
            Name = "casosInconsideravelAcidentePessoal";

            Field(x => x.IdCasosInconsideravelAcidentePessoal, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCasosInconsideravelAcidentePessoal, nullable: true);
            Field(x => x.Excepcao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            
        }
    }

    public class CasosInconsideravelAcidentePessoalInputType : InputObjectGraphType
	{
		public CasosInconsideravelAcidentePessoalInputType()
		{
			// Defining the name of the object
			Name = "casosInconsideravelAcidentePessoalInput";
			
            //Field<StringGraphType>("idCasosInconsideravelAcidentePessoal");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCasosInconsideravelAcidentePessoal");
			Field<StringGraphType>("excepcao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			
		}
	}
}