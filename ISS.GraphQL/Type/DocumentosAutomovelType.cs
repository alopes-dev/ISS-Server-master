using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosAutomovelType : ObjectGraphType<DocumentosAutomovel>
    {
        public DocumentosAutomovelType()
        {
            // Defining the name of the object
            Name = "documentosAutomovel";

            Field(x => x.IdDocumentosAutomovel, nullable: true);
            Field(x => x.NomeDocumento, nullable: true);
            Field(x => x.TipoDocumento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.AutomovelId, nullable: true);
            Field(x => x.DocumentoUrl, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            
        }
    }

    public class DocumentosAutomovelInputType : InputObjectGraphType
	{
		public DocumentosAutomovelInputType()
		{
			// Defining the name of the object
			Name = "documentosAutomovelInput";
			
            //Field<StringGraphType>("idDocumentosAutomovel");
			Field<StringGraphType>("nomeDocumento");
			Field<StringGraphType>("tipoDocumento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("automovelId");
			Field<StringGraphType>("documentoUrl");
			Field<AutomovelInputType>("automovel");
			
		}
	}
}