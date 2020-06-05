using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TiposDocumentoProdutoType : ObjectGraphType<TiposDocumentoProduto>
    {
        public TiposDocumentoProdutoType()
        {
            // Defining the name of the object
            Name = "tiposDocumentoProduto";

            Field(x => x.IdTiposDocumentoProduto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTiposDocumentoProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<DocumentosObrigatorioProdutoType>>("documentosObrigatorioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosObrigatorioProduto>(x => x.Where(e => e.HasValue(c.Source.IdTiposDocumentoProduto)))));
            
        }
    }

    public class TiposDocumentoProdutoInputType : InputObjectGraphType
	{
		public TiposDocumentoProdutoInputType()
		{
			// Defining the name of the object
			Name = "tiposDocumentoProdutoInput";
			
            //Field<StringGraphType>("idTiposDocumentoProduto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTiposDocumentoProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<DocumentosObrigatorioProdutoInputType>>("documentosObrigatorioProduto");
			
		}
	}
}