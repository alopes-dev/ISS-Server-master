using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProdutosPrestadoresType : ObjectGraphType<ProdutosPrestadores>
    {
        public ProdutosPrestadoresType()
        {
            // Defining the name of the object
            Name = "produtosPrestadores";

            Field(x => x.IdProdutosPrestadores, nullable: true);
            Field(x => x.CodProdutoPrestador, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PrecoProduto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ProdutosEmpresaId, nullable: true);
            Field(x => x.PrestadorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodProdutosPrestadores, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("prestador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PrestadorId)));
            FieldAsync<ProdutosEmpresaType>("produtosEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProdutosEmpresa>(c.Source.ProdutosEmpresaId)));
            
        }
    }

    public class ProdutosPrestadoresInputType : InputObjectGraphType
	{
		public ProdutosPrestadoresInputType()
		{
			// Defining the name of the object
			Name = "produtosPrestadoresInput";
			
            //Field<StringGraphType>("idProdutosPrestadores");
			Field<StringGraphType>("codProdutoPrestador");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("precoProduto");
			Field<StringGraphType>("produtosEmpresaId");
			Field<StringGraphType>("prestadorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codProdutosPrestadores");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("prestador");
			Field<ProdutosEmpresaInputType>("produtosEmpresa");
			
		}
	}
}