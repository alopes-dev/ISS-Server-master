using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPortfolioProdutoType : ObjectGraphType<TipoPortfolioProduto>
    {
        public TipoPortfolioProdutoType()
        {
            // Defining the name of the object
            Name = "tipoPortfolioProduto";

            Field(x => x.IdTipoPortfolioProduto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoPortfolioProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PortfolioProdutoType>>("portfolioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PortfolioProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipoPortfolioProduto)))));
            
        }
    }

    public class TipoPortfolioProdutoInputType : InputObjectGraphType
	{
		public TipoPortfolioProdutoInputType()
		{
			// Defining the name of the object
			Name = "tipoPortfolioProdutoInput";
			
            //Field<StringGraphType>("idTipoPortfolioProduto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoPortfolioProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PortfolioProdutoInputType>>("portfolioProduto");
			
		}
	}
}