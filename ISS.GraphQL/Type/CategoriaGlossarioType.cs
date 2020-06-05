using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaGlossarioType : ObjectGraphType<CategoriaGlossario>
    {
        public CategoriaGlossarioType()
        {
            // Defining the name of the object
            Name = "categoriaGlossario";

            Field(x => x.IdCategoriaGlossario, nullable: true);
            Field(x => x.CodCategoriaGlossario, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<GlossarioType>>("glossario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Glossario>(x => x.Where(e => e.HasValue(c.Source.IdCategoriaGlossario)))));
            
        }
    }

    public class CategoriaGlossarioInputType : InputObjectGraphType
	{
		public CategoriaGlossarioInputType()
		{
			// Defining the name of the object
			Name = "categoriaGlossarioInput";
			
            //Field<StringGraphType>("idCategoriaGlossario");
			Field<StringGraphType>("codCategoriaGlossario");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<GlossarioInputType>>("glossario");
			
		}
	}
}