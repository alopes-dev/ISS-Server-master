using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TransferenciaSeguroType : ObjectGraphType<TransferenciaSeguro>
    {
        public TransferenciaSeguroType()
        {
            // Defining the name of the object
            Name = "transferenciaSeguro";

            Field(x => x.IdTransferenciaSeguro, nullable: true);
            Field(x => x.JaEsteveSeguroParaEsteMesmoRisco, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.QualSeguradora, nullable: true);
            Field(x => x.CodTransferenciaSeguro, nullable: true);
            Field(x => x.RazaoAnulacao, nullable: true);
            Field(x => x.TemDebitos, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            
        }
    }

    public class TransferenciaSeguroInputType : InputObjectGraphType
	{
		public TransferenciaSeguroInputType()
		{
			// Defining the name of the object
			Name = "transferenciaSeguroInput";
			
            //Field<StringGraphType>("idTransferenciaSeguro");
			Field<BooleanGraphType>("jaEsteveSeguroParaEsteMesmoRisco");
			Field<StringGraphType>("qualSeguradora");
			Field<StringGraphType>("codTransferenciaSeguro");
			Field<StringGraphType>("razaoAnulacao");
			Field<BooleanGraphType>("temDebitos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			
		}
	}
}