using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriasProdutosInstalacoesType : ObjectGraphType<CategoriasProdutosInstalacoes>
    {
        public CategoriasProdutosInstalacoesType()
        {
            // Defining the name of the object
            Name = "categoriasProdutosInstalacoes";

            Field(x => x.IdCategoriaProduto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCategoriasProdutosInstalacoes, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ProdutosInstalacoesType>>("produtosInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProdutosInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdCategoriaProduto)))));
            
        }
    }

    public class CategoriasProdutosInstalacoesInputType : InputObjectGraphType
	{
		public CategoriasProdutosInstalacoesInputType()
		{
			// Defining the name of the object
			Name = "categoriasProdutosInstalacoesInput";
			
            //Field<StringGraphType>("idCategoriaProduto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCategoriasProdutosInstalacoes");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ProdutosInstalacoesInputType>>("produtosInstalacoes");
			
		}
	}
}