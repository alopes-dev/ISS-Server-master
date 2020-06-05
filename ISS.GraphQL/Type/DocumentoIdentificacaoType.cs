using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentoIdentificacaoType : ObjectGraphType<DocumentoIdentificacao>
    {
        public DocumentoIdentificacaoType()
        {
            // Defining the name of the object
            Name = "documentoIdentificacao";

            Field(x => x.IdDocumentoIdentificacao, nullable: true);
            Field(x => x.NumeroDoc, nullable: true);
            Field(x => x.DataEmissao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataValidade, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.TipoDocumentacaoIdentificacaoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Principal, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodDocumentoIdentificacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EntidadeEmissoraId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Eobrigatorio, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EmissoraDocumentosType>("entidadeEmissora", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EmissoraDocumentos>(c.Source.EntidadeEmissoraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<TipoDocumentoIdentificacaoType>("tipoDocumentacaoIdentificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDocumentoIdentificacao>(c.Source.TipoDocumentacaoIdentificacaoId)));
            
        }
    }

    public class DocumentoIdentificacaoInputType : InputObjectGraphType
	{
		public DocumentoIdentificacaoInputType()
		{
			// Defining the name of the object
			Name = "documentoIdentificacaoInput";
			
            //Field<StringGraphType>("idDocumentoIdentificacao");
			Field<StringGraphType>("numeroDoc");
			Field<DateTimeGraphType>("dataEmissao");
			Field<DateTimeGraphType>("dataValidade");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("tipoDocumentacaoIdentificacaoId");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("principal");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codDocumentoIdentificacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("entidadeEmissoraId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("eobrigatorio");
			Field<EmissoraDocumentosInputType>("entidadeEmissora");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<TipoDocumentoIdentificacaoInputType>("tipoDocumentacaoIdentificacao");
			
		}
	}
}