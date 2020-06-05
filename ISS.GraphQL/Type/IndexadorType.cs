using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class IndexadorType : ObjectGraphType<Indexador>
    {
        public IndexadorType()
        {
            // Defining the name of the object
            Name = "indexador";

            Field(x => x.IdIndexador, nullable: true);
            Field(x => x.CodIndexador, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class IndexadorInputType : InputObjectGraphType
	{
		public IndexadorInputType()
		{
			// Defining the name of the object
			Name = "indexadorInput";
			
            //Field<StringGraphType>("idIndexador");
			Field<StringGraphType>("codIndexador");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			
		}
	}
}