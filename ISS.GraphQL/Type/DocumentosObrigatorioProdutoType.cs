using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosObrigatorioProdutoType : ObjectGraphType<DocumentosObrigatorioProduto>
    {
        public DocumentosObrigatorioProdutoType()
        {
            // Defining the name of the object
            Name = "documentosObrigatorioProduto";

            Field(x => x.IdDocumento, nullable: true);
            Field(x => x.TiposDocumentoProdutoId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            Field(x => x.FaseId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodDocumentosObrigatorioProduto, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FaseDocumentosObrigatorioType>("fase", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FaseDocumentosObrigatorio>(c.Source.FaseId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            FieldAsync<TiposDocumentoProdutoType>("tiposDocumentoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TiposDocumentoProduto>(c.Source.TiposDocumentoProdutoId)));
            
        }
    }

    public class DocumentosObrigatorioProdutoInputType : InputObjectGraphType
	{
		public DocumentosObrigatorioProdutoInputType()
		{
			// Defining the name of the object
			Name = "documentosObrigatorioProdutoInput";
			
            //Field<StringGraphType>("idDocumento");
			Field<StringGraphType>("tiposDocumentoProdutoId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<StringGraphType>("faseId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codDocumentosObrigatorioProduto");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("designacao");
			Field<EstadoInputType>("estado");
			Field<FaseDocumentosObrigatorioInputType>("fase");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			Field<TipoCoberturaInputType>("tipoCobertura");
			Field<TiposDocumentoProdutoInputType>("tiposDocumentoProduto");
			
		}
	}
}