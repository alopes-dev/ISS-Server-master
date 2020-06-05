using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CartaConducaoType : ObjectGraphType<CartaConducao>
    {
        public CartaConducaoType()
        {
            // Defining the name of the object
            Name = "cartaConducao";

            Field(x => x.IdCartaConducao, nullable: true);
            Field(x => x.NumLicenca, nullable: true);
            Field(x => x.DataEmissao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataPrimeiraEmissao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataValidade, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.CaminhoAssinatura, nullable: true);
            Field(x => x.RestricoesPessoaisCartaConducaoId, nullable: true);
            Field(x => x.RestricoesCategoriasCartaConducaoId, nullable: true);
            Field(x => x.RestricoesViaturaCartaConducaoId, nullable: true);
            Field(x => x.TipoCartaConducaoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EntidadeEmissoraId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodCartaConducao, nullable: true);
            FieldAsync<EmissoraDocumentosType>("entidadeEmissora", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EmissoraDocumentos>(c.Source.EntidadeEmissoraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<RestricoesCategoriasCartaConducaoType>("restricoesCategoriasCartaConducao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RestricoesCategoriasCartaConducao>(c.Source.RestricoesCategoriasCartaConducaoId)));
            FieldAsync<RestricoesPessoaisCartaConducaoType>("restricoesPessoaisCartaConducao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RestricoesPessoaisCartaConducao>(c.Source.RestricoesPessoaisCartaConducaoId)));
            FieldAsync<RestricoesViaturaCartaConducaoType>("restricoesViaturaCartaConducao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RestricoesViaturaCartaConducao>(c.Source.RestricoesViaturaCartaConducaoId)));
            FieldAsync<TipoCartaConducaoType>("tipoCartaConducao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCartaConducao>(c.Source.TipoCartaConducaoId)));
            
        }
    }

    public class CartaConducaoInputType : InputObjectGraphType
	{
		public CartaConducaoInputType()
		{
			// Defining the name of the object
			Name = "cartaConducaoInput";
			
            //Field<StringGraphType>("idCartaConducao");
			Field<StringGraphType>("numLicenca");
			Field<DateTimeGraphType>("dataEmissao");
			Field<DateTimeGraphType>("dataPrimeiraEmissao");
			Field<DateTimeGraphType>("dataValidade");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("caminhoAssinatura");
			Field<StringGraphType>("restricoesPessoaisCartaConducaoId");
			Field<StringGraphType>("restricoesCategoriasCartaConducaoId");
			Field<StringGraphType>("restricoesViaturaCartaConducaoId");
			Field<StringGraphType>("tipoCartaConducaoId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("entidadeEmissoraId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codCartaConducao");
			Field<EmissoraDocumentosInputType>("entidadeEmissora");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<RestricoesCategoriasCartaConducaoInputType>("restricoesCategoriasCartaConducao");
			Field<RestricoesPessoaisCartaConducaoInputType>("restricoesPessoaisCartaConducao");
			Field<RestricoesViaturaCartaConducaoInputType>("restricoesViaturaCartaConducao");
			Field<TipoCartaConducaoInputType>("tipoCartaConducao");
			
		}
	}
}