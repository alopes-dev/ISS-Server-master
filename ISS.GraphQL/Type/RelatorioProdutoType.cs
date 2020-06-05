using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RelatorioProdutoType : ObjectGraphType<RelatorioProduto>
    {
        public RelatorioProdutoType()
        {
            // Defining the name of the object
            Name = "relatorioProduto";

            Field(x => x.IdRelatorioProduto, nullable: true);
            Field(x => x.RelatorioId, nullable: true);
            Field(x => x.LinhaId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodRelatorioProduto, nullable: true);
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<RelatorioType>("relatorio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Relatorio>(c.Source.RelatorioId)));
            
        }
    }

    public class RelatorioProdutoInputType : InputObjectGraphType
	{
		public RelatorioProdutoInputType()
		{
			// Defining the name of the object
			Name = "relatorioProdutoInput";
			
            //Field<StringGraphType>("idRelatorioProduto");
			Field<StringGraphType>("relatorioId");
			Field<StringGraphType>("linhaId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codRelatorioProduto");
			Field<ProdutoInputType>("produto");
			Field<RelatorioInputType>("relatorio");
			
		}
	}
}