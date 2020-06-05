using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class QuadroDanosType : ObjectGraphType<QuadroDanos>
    {
        public QuadroDanosType()
        {
            // Defining the name of the object
            Name = "quadroDanos";

            Field(x => x.IdQuadroDano, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Percentagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoQuadroDanoId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodQuadroDanos, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<TipoQuadroDanoType>("tipoQuadroDano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoQuadroDano>(c.Source.TipoQuadroDanoId)));
            
        }
    }

    public class QuadroDanosInputType : InputObjectGraphType
	{
		public QuadroDanosInputType()
		{
			// Defining the name of the object
			Name = "quadroDanosInput";
			
            //Field<StringGraphType>("idQuadroDano");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("percentagem");
			Field<StringGraphType>("tipoQuadroDanoId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codQuadroDanos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			Field<TipoQuadroDanoInputType>("tipoQuadroDano");
			
		}
	}
}