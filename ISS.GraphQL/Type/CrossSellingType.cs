using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CrossSellingType : ObjectGraphType<CrossSelling>
    {
        public CrossSellingType()
        {
            // Defining the name of the object
            Name = "crossSelling";

            Field(x => x.IdCrossSelling, nullable: true);
            Field(x => x.ProdutoPrincipalId, nullable: true);
            Field(x => x.ProdutoCrossedId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodCrossSelling, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProdutoType>("produtoCrossed", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoCrossedId)));
            FieldAsync<ProdutoType>("produtoPrincipal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoPrincipalId)));
            FieldAsync<ListGraphType<CrossSellingRateType>>("crossSellingRate", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CrossSellingRate>(x => x.Where(e => e.HasValue(c.Source.IdCrossSelling)))));
            
        }
    }

    public class CrossSellingInputType : InputObjectGraphType
	{
		public CrossSellingInputType()
		{
			// Defining the name of the object
			Name = "crossSellingInput";
			
            //Field<StringGraphType>("idCrossSelling");
			Field<StringGraphType>("produtoPrincipalId");
			Field<StringGraphType>("produtoCrossedId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codCrossSelling");
			Field<EstadoInputType>("estado");
			Field<ProdutoInputType>("produtoCrossed");
			Field<ProdutoInputType>("produtoPrincipal");
			Field<ListGraphType<CrossSellingRateInputType>>("crossSellingRate");
			
		}
	}
}