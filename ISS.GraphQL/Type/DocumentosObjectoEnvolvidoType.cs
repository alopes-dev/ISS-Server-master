using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosObjectoEnvolvidoType : ObjectGraphType<DocumentosObjectoEnvolvido>
    {
        public DocumentosObjectoEnvolvidoType()
        {
            // Defining the name of the object
            Name = "documentosObjectoEnvolvido";

            Field(x => x.IdDocumentosAutomovel, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.ObjectoEnvolvidoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ObjectoEnvolvidoType>("objectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoEnvolvido>(c.Source.ObjectoEnvolvidoId)));
            
        }
    }

    public class DocumentosObjectoEnvolvidoInputType : InputObjectGraphType
	{
		public DocumentosObjectoEnvolvidoInputType()
		{
			// Defining the name of the object
			Name = "documentosObjectoEnvolvidoInput";
			
            //Field<StringGraphType>("idDocumentosAutomovel");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("objectoEnvolvidoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ObjectoEnvolvidoInputType>("objectoEnvolvido");
			
		}
	}
}