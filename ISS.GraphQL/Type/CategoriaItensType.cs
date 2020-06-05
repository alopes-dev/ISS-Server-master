using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaItensType : ObjectGraphType<CategoriaItens>
    {
        public CategoriaItensType()
        {
            // Defining the name of the object
            Name = "categoriaItens";

            Field(x => x.IdCategoriaItens, nullable: true);
            Field(x => x.CodCategoriaItens, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<SubCategoriaItensType>>("subCategoriaItens", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubCategoriaItens>(x => x.Where(e => e.HasValue(c.Source.IdCategoriaItens)))));
            
        }
    }

    public class CategoriaItensInputType : InputObjectGraphType
	{
		public CategoriaItensInputType()
		{
			// Defining the name of the object
			Name = "categoriaItensInput";
			
            //Field<StringGraphType>("idCategoriaItens");
			Field<StringGraphType>("codCategoriaItens");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<SubCategoriaItensInputType>>("subCategoriaItens");
			
		}
	}
}