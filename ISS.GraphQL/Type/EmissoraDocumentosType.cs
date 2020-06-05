using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EmissoraDocumentosType : ObjectGraphType<EmissoraDocumentos>
    {
        public EmissoraDocumentosType()
        {
            // Defining the name of the object
            Name = "emissoraDocumentos";

            Field(x => x.IdEmissoraDocumentos, nullable: true);
            Field(x => x.CodEmissoraDocumentos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CartaConducaoType>>("cartaConducao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CartaConducao>(x => x.Where(e => e.HasValue(c.Source.IdEmissoraDocumentos)))));
            FieldAsync<ListGraphType<DocumentoIdentificacaoType>>("documentoIdentificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentoIdentificacao>(x => x.Where(e => e.HasValue(c.Source.IdEmissoraDocumentos)))));
            
        }
    }

    public class EmissoraDocumentosInputType : InputObjectGraphType
	{
		public EmissoraDocumentosInputType()
		{
			// Defining the name of the object
			Name = "emissoraDocumentosInput";
			
            //Field<StringGraphType>("idEmissoraDocumentos");
			Field<StringGraphType>("codEmissoraDocumentos");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CartaConducaoInputType>>("cartaConducao");
			Field<ListGraphType<DocumentoIdentificacaoInputType>>("documentoIdentificacao");
			
		}
	}
}