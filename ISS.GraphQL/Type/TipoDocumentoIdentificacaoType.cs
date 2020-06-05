using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoDocumentoIdentificacaoType : ObjectGraphType<TipoDocumentoIdentificacao>
    {
        public TipoDocumentoIdentificacaoType()
        {
            // Defining the name of the object
            Name = "tipoDocumentoIdentificacao";

            Field(x => x.IdTipoDocumento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoDocumentoIdentificacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.TipoPessoaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoDocumentoIdentificacaoType>("tipoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDocumentoIdentificacao>(c.Source.TipoPessoaId)));
            FieldAsync<ListGraphType<DocumentoIdentificacaoType>>("documentoIdentificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentoIdentificacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoDocumento)))));
            FieldAsync<ListGraphType<DocumentoMembroAsseguradoType>>("documentoMembroAssegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentoMembroAssegurado>(x => x.Where(e => e.HasValue(c.Source.IdTipoDocumento)))));
            FieldAsync<ListGraphType<TipoDocumentoIdentificacaoType>>("inverseTipoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDocumentoIdentificacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoDocumento)))));
            
        }
    }

    public class TipoDocumentoIdentificacaoInputType : InputObjectGraphType
	{
		public TipoDocumentoIdentificacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoDocumentoIdentificacaoInput";
			
            //Field<StringGraphType>("idTipoDocumento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoDocumentoIdentificacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("tipoPessoaId");
			Field<EstadoInputType>("estado");
			Field<TipoDocumentoIdentificacaoInputType>("tipoPessoa");
			Field<ListGraphType<DocumentoIdentificacaoInputType>>("documentoIdentificacao");
			Field<ListGraphType<DocumentoMembroAsseguradoInputType>>("documentoMembroAssegurado");
			Field<ListGraphType<TipoDocumentoIdentificacaoInputType>>("inverseTipoPessoa");
			
		}
	}
}