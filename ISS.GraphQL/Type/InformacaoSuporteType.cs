using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class InformacaoSuporteType : ObjectGraphType<InformacaoSuporte>
    {
        public InformacaoSuporteType()
        {
            // Defining the name of the object
            Name = "informacaoSuporte";

            Field(x => x.IdInformacaoSuporte, nullable: true);
            Field(x => x.Titulo, nullable: true);
            Field(x => x.Conteudo, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodInformacaoSuporte, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class InformacaoSuporteInputType : InputObjectGraphType
	{
		public InformacaoSuporteInputType()
		{
			// Defining the name of the object
			Name = "informacaoSuporteInput";
			
            //Field<StringGraphType>("idInformacaoSuporte");
			Field<StringGraphType>("titulo");
			Field<StringGraphType>("conteudo");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codInformacaoSuporte");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			
		}
	}
}