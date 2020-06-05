using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosNecessarioPorLinhaType : ObjectGraphType<DocumentosNecessarioPorLinha>
    {
        public DocumentosNecessarioPorLinhaType()
        {
            // Defining the name of the object
            Name = "documentosNecessarioPorLinha";

            Field(x => x.IdDocumentosNecessarioLinha, nullable: true);
            Field(x => x.DocumentoLinhaId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodDocumentosNecessarioPorLinha, nullable: true);
            FieldAsync<DocumentosLinhaType>("documentoLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosLinha>(c.Source.DocumentoLinhaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class DocumentosNecessarioPorLinhaInputType : InputObjectGraphType
	{
		public DocumentosNecessarioPorLinhaInputType()
		{
			// Defining the name of the object
			Name = "documentosNecessarioPorLinhaInput";
			
            //Field<StringGraphType>("idDocumentosNecessarioLinha");
			Field<StringGraphType>("documentoLinhaId");
			Field<StringGraphType>("linhaProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codDocumentosNecessarioPorLinha");
			Field<DocumentosLinhaInputType>("documentoLinha");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}