using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProdutosFarmaceuticosType : ObjectGraphType<ProdutosFarmaceuticos>
    {
        public ProdutosFarmaceuticosType()
        {
            // Defining the name of the object
            Name = "produtosFarmaceuticos";

            Field(x => x.IdProdutosFarmaceuticos, nullable: true);
            Field(x => x.CodProduto, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NossoPreco, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PrecosProdutosFarmaceuticosType>>("precosProdutosFarmaceuticos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecosProdutosFarmaceuticos>(x => x.Where(e => e.HasValue(c.Source.IdProdutosFarmaceuticos)))));
            
        }
    }

    public class ProdutosFarmaceuticosInputType : InputObjectGraphType
	{
		public ProdutosFarmaceuticosInputType()
		{
			// Defining the name of the object
			Name = "produtosFarmaceuticosInput";
			
            //Field<StringGraphType>("idProdutosFarmaceuticos");
			Field<StringGraphType>("codProduto");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("nossoPreco");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PrecosProdutosFarmaceuticosInputType>>("precosProdutosFarmaceuticos");
			
		}
	}
}