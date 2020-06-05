using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosLesadoType : ObjectGraphType<DocumentosLesado>
    {
        public DocumentosLesadoType()
        {
            // Defining the name of the object
            Name = "documentosLesado";

            Field(x => x.IdDocumentosLesado, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.LesadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LesadoType>("lesado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Lesado>(c.Source.LesadoId)));
            
        }
    }

    public class DocumentosLesadoInputType : InputObjectGraphType
	{
		public DocumentosLesadoInputType()
		{
			// Defining the name of the object
			Name = "documentosLesadoInput";
			
            //Field<StringGraphType>("idDocumentosLesado");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("lesadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LesadoInputType>("lesado");
			
		}
	}
}