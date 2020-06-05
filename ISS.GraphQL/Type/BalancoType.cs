using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BalancoType : ObjectGraphType<Balanco>
    {
        public BalancoType()
        {
            // Defining the name of the object
            Name = "balanco";

            Field(x => x.IdBalanco, nullable: true);
            Field(x => x.NumSubClasse, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ContaMaeId, nullable: true);
            Field(x => x.ClasseId, nullable: true);
            Field(x => x.ClassificacaoContaId, nullable: true);
            Field(x => x.TipoClasseContaId, nullable: true);
            Field(x => x.Grau, nullable: true, type: typeof(IntGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ValorDebito, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorCredito, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Saldo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorDebitoAnterior, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorCreditoAnterior, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SaldoAnterior, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ConceitoConta, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class BalancoInputType : InputObjectGraphType
	{
		public BalancoInputType()
		{
			// Defining the name of the object
			Name = "balancoInput";
			
            //Field<StringGraphType>("idBalanco");
			Field<StringGraphType>("numSubClasse");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("contaMaeId");
			Field<StringGraphType>("classeId");
			Field<StringGraphType>("classificacaoContaId");
			Field<StringGraphType>("tipoClasseContaId");
			Field<IntGraphType>("grau");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("valorDebito");
			Field<FloatGraphType>("valorCredito");
			Field<FloatGraphType>("saldo");
			Field<FloatGraphType>("valorDebitoAnterior");
			Field<FloatGraphType>("valorCreditoAnterior");
			Field<FloatGraphType>("saldoAnterior");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("conceitoConta");
			Field<EstadoInputType>("estado");
			
		}
	}
}