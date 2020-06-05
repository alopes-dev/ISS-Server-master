using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoCascoType : ObjectGraphType<ClassificacaoCasco>
    {
        public ClassificacaoCascoType()
        {
            // Defining the name of the object
            Name = "classificacaoCasco";

            Field(x => x.IdClassificacaoCasco, nullable: true);
            Field(x => x.CodClassificacaoCasco, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ClassificacaoCascoInputType : InputObjectGraphType
	{
		public ClassificacaoCascoInputType()
		{
			// Defining the name of the object
			Name = "classificacaoCascoInput";
			
            //Field<StringGraphType>("idClassificacaoCasco");
			Field<StringGraphType>("codClassificacaoCasco");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}