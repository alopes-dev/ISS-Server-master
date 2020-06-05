using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentoMembroAsseguradoType : ObjectGraphType<DocumentoMembroAssegurado>
    {
        public DocumentoMembroAsseguradoType()
        {
            // Defining the name of the object
            Name = "documentoMembroAssegurado";

            Field(x => x.IdDocumentoMembroAssegurado, nullable: true);
            Field(x => x.MembroAsseguradoId, nullable: true);
            Field(x => x.TipoDocumentoIdentificacaoId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.CodDocumentoMembroAssegurado, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NumeroDocumemnto, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MembroAsseguradoType>("membroAssegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MembroAssegurado>(c.Source.MembroAsseguradoId)));
            FieldAsync<TipoDocumentoIdentificacaoType>("tipoDocumentoIdentificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDocumentoIdentificacao>(c.Source.TipoDocumentoIdentificacaoId)));
            
        }
    }

    public class DocumentoMembroAsseguradoInputType : InputObjectGraphType
	{
		public DocumentoMembroAsseguradoInputType()
		{
			// Defining the name of the object
			Name = "documentoMembroAsseguradoInput";
			
            //Field<StringGraphType>("idDocumentoMembroAssegurado");
			Field<StringGraphType>("membroAsseguradoId");
			Field<StringGraphType>("tipoDocumentoIdentificacaoId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("codDocumentoMembroAssegurado");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("numeroDocumemnto");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			Field<MembroAsseguradoInputType>("membroAssegurado");
			Field<TipoDocumentoIdentificacaoInputType>("tipoDocumentoIdentificacao");
			
		}
	}
}