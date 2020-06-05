using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosLinhaType : ObjectGraphType<DocumentosLinha>
    {
        public DocumentosLinhaType()
        {
            // Defining the name of the object
            Name = "documentosLinha";

            Field(x => x.IdDocumentoLinha, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodDocumentosLinha, nullable: true);
            Field(x => x.Designacao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<DocumentosNecessarioPorLinhaType>>("documentosNecessarioPorLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosNecessarioPorLinha>(x => x.Where(e => e.HasValue(c.Source.IdDocumentoLinha)))));
            
        }
    }

    public class DocumentosLinhaInputType : InputObjectGraphType
	{
		public DocumentosLinhaInputType()
		{
			// Defining the name of the object
			Name = "documentosLinhaInput";
			
            //Field<StringGraphType>("idDocumentoLinha");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codDocumentosLinha");
			Field<StringGraphType>("designacao");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<DocumentosNecessarioPorLinhaInputType>>("documentosNecessarioPorLinha");
			
		}
	}
}