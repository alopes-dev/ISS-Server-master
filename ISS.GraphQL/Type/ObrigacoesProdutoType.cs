using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObrigacoesProdutoType : ObjectGraphType<ObrigacoesProduto>
    {
        public ObrigacoesProdutoType()
        {
            // Defining the name of the object
            Name = "obrigacoesProduto";

            Field(x => x.IdObrigacoesProduto, nullable: true);
            Field(x => x.NumPonto, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.ResponsavelObrigacoesId, nullable: true);
            Field(x => x.TipoObrigacoesId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodObrigacoesProduto, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<ResponsavelObrigacoesType>("responsavelObrigacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ResponsavelObrigacoes>(c.Source.ResponsavelObrigacoesId)));
            FieldAsync<TipoObrigacoesType>("tipoObrigacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoObrigacoes>(c.Source.TipoObrigacoesId)));
            
        }
    }

    public class ObrigacoesProdutoInputType : InputObjectGraphType
	{
		public ObrigacoesProdutoInputType()
		{
			// Defining the name of the object
			Name = "obrigacoesProdutoInput";
			
            //Field<StringGraphType>("idObrigacoesProduto");
			Field<IntGraphType>("numPonto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("responsavelObrigacoesId");
			Field<StringGraphType>("tipoObrigacoesId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codObrigacoesProduto");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			Field<ResponsavelObrigacoesInputType>("responsavelObrigacoes");
			Field<TipoObrigacoesInputType>("tipoObrigacoes");
			
		}
	}
}