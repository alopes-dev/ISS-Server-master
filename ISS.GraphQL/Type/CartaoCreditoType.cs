using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CartaoCreditoType : ObjectGraphType<CartaoCredito>
    {
        public CartaoCreditoType()
        {
            // Defining the name of the object
            Name = "cartaoCredito";

            Field(x => x.IdCartaoCredito, nullable: true);
            Field(x => x.NomeCartao, nullable: true);
            Field(x => x.NumeroCartao, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.InformacaoBancariaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodCartaoCredito, nullable: true);
            Field(x => x.DataExpiracao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<InformacaoBancariaType>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(c.Source.InformacaoBancariaId)));
            
        }
    }

    public class CartaoCreditoInputType : InputObjectGraphType
	{
		public CartaoCreditoInputType()
		{
			// Defining the name of the object
			Name = "cartaoCreditoInput";
			
            //Field<StringGraphType>("idCartaoCredito");
			Field<StringGraphType>("nomeCartao");
			Field<IntGraphType>("numeroCartao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("informacaoBancariaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codCartaoCredito");
			Field<DateTimeGraphType>("dataExpiracao");
			Field<EstadoInputType>("estado");
			Field<InformacaoBancariaInputType>("informacaoBancaria");
			
		}
	}
}