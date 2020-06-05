using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosTestemunhaType : ObjectGraphType<DocumentosTestemunha>
    {
        public DocumentosTestemunhaType()
        {
            // Defining the name of the object
            Name = "documentosTestemunha";

            Field(x => x.IdDocumentosTestemunha, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.TestemunhaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TestemunhaType>("testemunha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Testemunha>(c.Source.TestemunhaId)));
            
        }
    }

    public class DocumentosTestemunhaInputType : InputObjectGraphType
	{
		public DocumentosTestemunhaInputType()
		{
			// Defining the name of the object
			Name = "documentosTestemunhaInput";
			
            //Field<StringGraphType>("idDocumentosTestemunha");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("testemunhaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TestemunhaInputType>("testemunha");
			
		}
	}
}