using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ValorCativoType : ObjectGraphType<ValorCativo>
    {
        public ValorCativoType()
        {
            // Defining the name of the object
            Name = "valorCativo";

            Field(x => x.IdValorCativo, nullable: true);
            Field(x => x.CodValorCativo, nullable: true);
            Field(x => x.ContaId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.DataCavito, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PrazoCativo, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoJustificativoCativoId, nullable: true);
            Field(x => x.TipoContaId, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CativadoPorId, nullable: true);
            Field(x => x.DescativadoPorId, nullable: true);
            FieldAsync<FuncionarioType>("cativadoPor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.CativadoPorId)));
            FieldAsync<ContaFinanceiraType>("conta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaId)));
            FieldAsync<FuncionarioType>("descativadoPor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.DescativadoPorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<TipoContaType>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(c.Source.TipoContaId)));
            FieldAsync<TipoJustificativoCativoType>("tipoJustificativoCativo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoJustificativoCativo>(c.Source.TipoJustificativoCativoId)));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdValorCativo)))));
            
        }
    }

    public class ValorCativoInputType : InputObjectGraphType
	{
		public ValorCativoInputType()
		{
			// Defining the name of the object
			Name = "valorCativoInput";
			
            //Field<StringGraphType>("idValorCativo");
			Field<StringGraphType>("codValorCativo");
			Field<StringGraphType>("contaId");
			Field<StringGraphType>("moedaId");
			Field<DateTimeGraphType>("dataCavito");
			Field<IntGraphType>("prazoCativo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoJustificativoCativoId");
			Field<StringGraphType>("tipoContaId");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("cativadoPorId");
			Field<StringGraphType>("descativadoPorId");
			Field<FuncionarioInputType>("cativadoPor");
			Field<ContaFinanceiraInputType>("conta");
			Field<FuncionarioInputType>("descativadoPor");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<TipoContaInputType>("tipoConta");
			Field<TipoJustificativoCativoInputType>("tipoJustificativoCativo");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceira");
			
		}
	}
}