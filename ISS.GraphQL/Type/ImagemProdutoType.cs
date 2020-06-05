using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ImagemProdutoType : ObjectGraphType<ImagemProduto>
    {
        public ImagemProdutoType()
        {
            // Defining the name of the object
            Name = "imagemProduto";

            Field(x => x.IdImagemProduto, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.TipoImagemProdutoId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodImagemProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.PortfolioProdutoId, nullable: true);
            //FieldAsync<Byte[]Type>("imagemByte", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Byte[]>(c.Source.IdImagemProduto)));
            Field(x => x.CaminhoImagem, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<PortfolioProdutoType>("portfolioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PortfolioProduto>(c.Source.PortfolioProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<TipoImagemProdutoType>("tipoImagemProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoImagemProduto>(c.Source.TipoImagemProdutoId)));
            
        }
    }

    public class ImagemProdutoInputType : InputObjectGraphType
	{
		public ImagemProdutoInputType()
		{
			// Defining the name of the object
			Name = "imagemProdutoInput";
			
            //Field<StringGraphType>("idImagemProduto");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("tipoImagemProdutoId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codImagemProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("portfolioProdutoId");
			//Field<Byte[]InputType>("imagemByte");
			Field<StringGraphType>("caminhoImagem");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<PortfolioProdutoInputType>("portfolioProduto");
			Field<ProdutoInputType>("produto");
			Field<TipoImagemProdutoInputType>("tipoImagemProduto");
			
		}
	}
}