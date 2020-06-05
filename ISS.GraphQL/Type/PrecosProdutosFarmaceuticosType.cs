using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrecosProdutosFarmaceuticosType : ObjectGraphType<PrecosProdutosFarmaceuticos>
    {
        public PrecosProdutosFarmaceuticosType()
        {
            // Defining the name of the object
            Name = "precosProdutosFarmaceuticos";

            Field(x => x.IdPrecosProdutosFarmaceuticos, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.Preco, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ProdutosFarmaceuticosType>("descricaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProdutosFarmaceuticos>(c.Source.Descricao)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PrecosProdutosFarmaceuticosInputType : InputObjectGraphType
	{
		public PrecosProdutosFarmaceuticosInputType()
		{
			// Defining the name of the object
			Name = "precosProdutosFarmaceuticosInput";
			
            //Field<StringGraphType>("idPrecosProdutosFarmaceuticos");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("preco");
			Field<StringGraphType>("estadoId");
			Field<ProdutosFarmaceuticosInputType>("descricaoNavigation");
			Field<EstadoInputType>("estado");
			
		}
	}
}