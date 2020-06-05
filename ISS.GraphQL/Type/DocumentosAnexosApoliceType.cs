using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosAnexosApoliceType : ObjectGraphType<DocumentosAnexosApolice>
    {
        public DocumentosAnexosApoliceType()
        {
            // Defining the name of the object
            Name = "documentosAnexosApolice";

            Field(x => x.IdDocumentoAnexo, nullable: true);
            Field(x => x.Titulo, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class DocumentosAnexosApoliceInputType : InputObjectGraphType
	{
		public DocumentosAnexosApoliceInputType()
		{
			// Defining the name of the object
			Name = "documentosAnexosApoliceInput";
			
            //Field<StringGraphType>("idDocumentoAnexo");
			Field<StringGraphType>("titulo");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("apoliceId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			
		}
	}
}