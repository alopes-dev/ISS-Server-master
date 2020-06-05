using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoDocumentosType : ObjectGraphType<TipoDocumentos>
    {
        public TipoDocumentosType()
        {
            // Defining the name of the object
            Name = "tipoDocumentos";

            Field(x => x.IdTipoDocumentos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoDocumentos, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.HistoricoMovimento, nullable: true);
            Field(x => x.Antecede, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodigoAgtTipoDocumento, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ComissaoType>>("comissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissao>(x => x.Where(e => e.HasValue(c.Source.IdTipoDocumentos)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoDocumentos)))));
            FieldAsync<ListGraphType<ImpostoTipoDocumentosType>>("impostoTipoDocumentos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoTipoDocumentos>(x => x.Where(e => e.HasValue(c.Source.IdTipoDocumentos)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdTipoDocumentos)))));
            FieldAsync<ListGraphType<TipoOperacaoType>>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoDocumentos)))));
            
        }
    }

    public class TipoDocumentosInputType : InputObjectGraphType
	{
		public TipoDocumentosInputType()
		{
			// Defining the name of the object
			Name = "tipoDocumentosInput";
			
            //Field<StringGraphType>("idTipoDocumentos");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoDocumentos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("historicoMovimento");
			Field<BooleanGraphType>("antecede");
			Field<StringGraphType>("codigoAgtTipoDocumento");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ComissaoInputType>>("comissao");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<ImpostoTipoDocumentosInputType>>("impostoTipoDocumentos");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<TipoOperacaoInputType>>("tipoOperacao");
			
		}
	}
}