using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosCoberturasType : ObjectGraphType<DocumentosCoberturas>
    {
        public DocumentosCoberturasType()
        {
            // Defining the name of the object
            Name = "documentosCoberturas";

            Field(x => x.IdDocumentosCoberturas, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CoberturaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodDocumentosCoberturas, nullable: true);
            FieldAsync<CoberturaType>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class DocumentosCoberturasInputType : InputObjectGraphType
	{
		public DocumentosCoberturasInputType()
		{
			// Defining the name of the object
			Name = "documentosCoberturasInput";
			
            //Field<StringGraphType>("idDocumentosCoberturas");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("coberturaId");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codDocumentosCoberturas");
			Field<CoberturaInputType>("cobertura");
			Field<EstadoInputType>("estado");
			
		}
	}
}