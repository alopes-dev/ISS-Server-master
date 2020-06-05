using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SaldoType : ObjectGraphType<Saldo>
    {
        public SaldoType()
        {
            // Defining the name of the object
            Name = "saldo";

            Field(x => x.IdSaldo, nullable: true);
            Field(x => x.CodSaldo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ContaFinanceiraId, nullable: true);
            Field(x => x.Saldo1, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SaldoDisponivel, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SaldoContabilistico, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SaldoCativo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ContaFinanceiraType>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class SaldoInputType : InputObjectGraphType
	{
		public SaldoInputType()
		{
			// Defining the name of the object
			Name = "saldoInput";
			
            //Field<StringGraphType>("idSaldo");
			Field<StringGraphType>("codSaldo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("contaFinanceiraId");
			Field<FloatGraphType>("saldo1");
			Field<FloatGraphType>("saldoDisponivel");
			Field<FloatGraphType>("saldoContabilistico");
			Field<FloatGraphType>("saldoCativo");
			Field<StringGraphType>("estadoId");
			Field<ContaFinanceiraInputType>("contaFinanceira");
			Field<EstadoInputType>("estado");
			
		}
	}
}