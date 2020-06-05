using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProdutosEmpresaType : ObjectGraphType<ProdutosEmpresa>
    {
        public ProdutosEmpresaType()
        {
            // Defining the name of the object
            Name = "produtosEmpresa";

            Field(x => x.IdProdutosEmpresa, nullable: true);
            Field(x => x.CodProduto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ProdutosPrestadoresType>>("produtosPrestadores", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProdutosPrestadores>(x => x.Where(e => e.HasValue(c.Source.IdProdutosEmpresa)))));
            
        }
    }

    public class ProdutosEmpresaInputType : InputObjectGraphType
	{
		public ProdutosEmpresaInputType()
		{
			// Defining the name of the object
			Name = "produtosEmpresaInput";
			
            //Field<StringGraphType>("idProdutosEmpresa");
			Field<StringGraphType>("codProduto");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ProdutosPrestadoresInputType>>("produtosPrestadores");
			
		}
	}
}