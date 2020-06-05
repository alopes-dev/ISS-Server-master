using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormaMovimentoContaFinanceiraType : ObjectGraphType<FormaMovimentoContaFinanceira>
    {
        public FormaMovimentoContaFinanceiraType()
        {
            // Defining the name of the object
            Name = "formaMovimentoContaFinanceira";

            Field(x => x.IdFormaMovimentoContaFinanceira, nullable: true);
            Field(x => x.CodFormaMovimentoContaFinanceira, nullable: true);
            Field(x => x.Familia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceiraFormaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdFormaMovimentoContaFinanceira)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceiraFormaMovimentoContaFinanceiraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdFormaMovimentoContaFinanceira)))));
            
        }
    }

    public class FormaMovimentoContaFinanceiraInputType : InputObjectGraphType
	{
		public FormaMovimentoContaFinanceiraInputType()
		{
			// Defining the name of the object
			Name = "formaMovimentoContaFinanceiraInput";
			
            //Field<StringGraphType>("idFormaMovimentoContaFinanceira");
			Field<StringGraphType>("codFormaMovimentoContaFinanceira");
			Field<StringGraphType>("familia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceiraFormaMovimento");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceiraFormaMovimentoContaFinanceiraNavigation");
			
		}
	}
}