using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObjectivoProdutoType : ObjectGraphType<ObjectivoProduto>
    {
        public ObjectivoProdutoType()
        {
            // Defining the name of the object
            Name = "objectivoProduto";

            Field(x => x.IdObjectivo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoObjectivoProdutoId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodObjectivoProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<TipoObjectivoProdutoType>("tipoObjectivoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoObjectivoProduto>(c.Source.TipoObjectivoProdutoId)));
            
        }
    }

    public class ObjectivoProdutoInputType : InputObjectGraphType
	{
		public ObjectivoProdutoInputType()
		{
			// Defining the name of the object
			Name = "objectivoProdutoInput";
			
            //Field<StringGraphType>("idObjectivo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoObjectivoProdutoId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codObjectivoProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			Field<TipoObjectivoProdutoInputType>("tipoObjectivoProduto");
			
		}
	}
}