using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicoesProdutoType : ObjectGraphType<CondicoesProduto>
    {
        public CondicoesProdutoType()
        {
            // Defining the name of the object
            Name = "condicoesProduto";

            Field(x => x.IdCondicoesProduto, nullable: true);
            Field(x => x.CondicoesId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class CondicoesProdutoInputType : InputObjectGraphType
	{
		public CondicoesProdutoInputType()
		{
			// Defining the name of the object
			Name = "condicoesProdutoInput";
			
            //Field<StringGraphType>("idCondicoesProduto");
			Field<StringGraphType>("condicoesId");
			Field<StringGraphType>("produtoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			
		}
	}
}