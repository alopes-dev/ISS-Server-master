using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ImpostoTipoDocumentosType : ObjectGraphType<ImpostoTipoDocumentos>
    {
        public ImpostoTipoDocumentosType()
        {
            // Defining the name of the object
            Name = "impostoTipoDocumentos";

            Field(x => x.IdImpostoTipoDocumentos, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ImpostoId, nullable: true);
            Field(x => x.TipoDocumentosId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ImpostoType>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(c.Source.ImpostoId)));
            FieldAsync<TipoDocumentosType>("tipoDocumentos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDocumentos>(c.Source.TipoDocumentosId)));
            
        }
    }

    public class ImpostoTipoDocumentosInputType : InputObjectGraphType
	{
		public ImpostoTipoDocumentosInputType()
		{
			// Defining the name of the object
			Name = "impostoTipoDocumentosInput";
			
            //Field<StringGraphType>("idImpostoTipoDocumentos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("impostoId");
			Field<StringGraphType>("tipoDocumentosId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ImpostoInputType>("imposto");
			Field<TipoDocumentosInputType>("tipoDocumentos");
			
		}
	}
}