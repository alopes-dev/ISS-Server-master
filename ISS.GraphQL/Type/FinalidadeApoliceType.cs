using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FinalidadeApoliceType : ObjectGraphType<FinalidadeApolice>
    {
        public FinalidadeApoliceType()
        {
            // Defining the name of the object
            Name = "finalidadeApolice";

            Field(x => x.IdFinalidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFinalidadeApolice, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class FinalidadeApoliceInputType : InputObjectGraphType
	{
		public FinalidadeApoliceInputType()
		{
			// Defining the name of the object
			Name = "finalidadeApoliceInput";
			
            //Field<StringGraphType>("idFinalidade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFinalidadeApolice");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}