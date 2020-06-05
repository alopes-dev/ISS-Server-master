using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubCategoriaItensType : ObjectGraphType<SubCategoriaItens>
    {
        public SubCategoriaItensType()
        {
            // Defining the name of the object
            Name = "subCategoriaItens";

            Field(x => x.IdSubCategoriaItens, nullable: true);
            Field(x => x.CodSubCategoriaItens, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CategoriaItensId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CategoriaItensType>("categoriaItens", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaItens>(c.Source.CategoriaItensId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ItensPerguntaType>>("itensPergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ItensPergunta>(x => x.Where(e => e.HasValue(c.Source.IdSubCategoriaItens)))));
            
        }
    }

    public class SubCategoriaItensInputType : InputObjectGraphType
	{
		public SubCategoriaItensInputType()
		{
			// Defining the name of the object
			Name = "subCategoriaItensInput";
			
            //Field<StringGraphType>("idSubCategoriaItens");
			Field<StringGraphType>("codSubCategoriaItens");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("categoriaItensId");
			Field<StringGraphType>("estadoId");
			Field<CategoriaItensInputType>("categoriaItens");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ItensPerguntaInputType>>("itensPergunta");
			
		}
	}
}