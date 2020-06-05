using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PortfolioProdutoType : ObjectGraphType<PortfolioProduto>
    {
        public PortfolioProdutoType()
        {
            // Defining the name of the object
            Name = "portfolioProduto";

            Field(x => x.IdPortfolio, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoRamoSeguroId, nullable: true);
            Field(x => x.CodPortfolioProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.TipoPortfolioProdutoId, nullable: true);
            Field(x => x.CaminhoImagem, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<TipoPortfolioProdutoType>("tipoPortfolioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPortfolioProduto>(c.Source.TipoPortfolioProdutoId)));
            FieldAsync<TipoRamoSeguroType>("tipoRamoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRamoSeguro>(c.Source.TipoRamoSeguroId)));
            FieldAsync<ListGraphType<ImagemProdutoType>>("imagemProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImagemProduto>(x => x.Where(e => e.HasValue(c.Source.IdPortfolio)))));
            FieldAsync<ListGraphType<ProdutoType>>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(x => x.Where(e => e.HasValue(c.Source.IdPortfolio)))));
            
        }
    }

    public class PortfolioProdutoInputType : InputObjectGraphType
	{
		public PortfolioProdutoInputType()
		{
			// Defining the name of the object
			Name = "portfolioProdutoInput";
			
            //Field<StringGraphType>("idPortfolio");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoRamoSeguroId");
			Field<StringGraphType>("codPortfolioProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("tipoPortfolioProdutoId");
			Field<StringGraphType>("caminhoImagem");
			Field<EstadoInputType>("estado");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PlanoContasInputType>("subConta");
			Field<TipoPortfolioProdutoInputType>("tipoPortfolioProduto");
			Field<TipoRamoSeguroInputType>("tipoRamoSeguro");
			Field<ListGraphType<ImagemProdutoInputType>>("imagemProduto");
			Field<ListGraphType<ProdutoInputType>>("produto");
			
		}
	}
}