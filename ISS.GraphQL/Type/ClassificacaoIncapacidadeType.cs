using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoIncapacidadeType : ObjectGraphType<ClassificacaoIncapacidade>
    {
        public ClassificacaoIncapacidadeType()
        {
            // Defining the name of the object
            Name = "classificacaoIncapacidade";

            Field(x => x.IdClassificacaoIncapacidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodClassificacaoIncapacidade, nullable: true);
            
        }
    }

    public class ClassificacaoIncapacidadeInputType : InputObjectGraphType
	{
		public ClassificacaoIncapacidadeInputType()
		{
			// Defining the name of the object
			Name = "classificacaoIncapacidadeInput";
			
            //Field<StringGraphType>("idClassificacaoIncapacidade");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codClassificacaoIncapacidade");
			
		}
	}
}