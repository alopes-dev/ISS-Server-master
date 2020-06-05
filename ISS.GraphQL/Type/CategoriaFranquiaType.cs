using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaFranquiaType : ObjectGraphType<CategoriaFranquia>
    {
        public CategoriaFranquiaType()
        {
            // Defining the name of the object
            Name = "categoriaFranquia";

            Field(x => x.IdCategoriaFranquia, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCategoriaFranquia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CategoriaFranquiaInputType : InputObjectGraphType
	{
		public CategoriaFranquiaInputType()
		{
			// Defining the name of the object
			Name = "categoriaFranquiaInput";
			
            //Field<StringGraphType>("idCategoriaFranquia");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCategoriaFranquia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}