using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CartaoPagamentoType : ObjectGraphType<CartaoPagamento>
    {
        public CartaoPagamentoType()
        {
            // Defining the name of the object
            Name = "cartaoPagamento";

            Field(x => x.IdCartaoPagamento, nullable: true);
            Field(x => x.NumCartao, nullable: true);
            Field(x => x.DataValidade, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoCartaoPagamentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodCartaoPagamento, nullable: true);
            Field(x => x.Conta, nullable: true);
            Field(x => x.DataEmissao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NomeCartao, nullable: true);
            Field(x => x.ContaFinanceiraId, nullable: true);
            //FieldAsync<DecimalType>("saldoDisponivel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Decimal>(c.Source.IdCartaoPagamento)));
            //FieldAsync<DecimalType>("saldoContablistico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Decimal>(c.Source.IdCartaoPagamento)));
            //FieldAsync<DecimalType>("saldo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Decimal>(c.Source.IdCartaoPagamento)));
            Field(x => x.DataUltimaUtilizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ContaFinanceiraType>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCartaoPagamentoType>("tipoCartaoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCartaoPagamento>(c.Source.TipoCartaoPagamentoId)));
            FieldAsync<ListGraphType<InformacaoBancariaType>>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(x => x.Where(e => e.HasValue(c.Source.IdCartaoPagamento)))));
            
        }
    }

    public class CartaoPagamentoInputType : InputObjectGraphType
	{
		public CartaoPagamentoInputType()
		{
			// Defining the name of the object
			Name = "cartaoPagamentoInput";
			
            //Field<StringGraphType>("idCartaoPagamento");
			Field<StringGraphType>("numCartao");
			Field<DateTimeGraphType>("dataValidade");
			Field<StringGraphType>("tipoCartaoPagamentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codCartaoPagamento");
			Field<StringGraphType>("conta");
			Field<DateTimeGraphType>("dataEmissao");
			Field<StringGraphType>("nomeCartao");
			Field<StringGraphType>("contaFinanceiraId");
			//Field<DecimalInputType>("saldoDisponivel");
			//Field<DecimalInputType>("saldoContablistico");
			//Field<DecimalInputType>("saldo");
			Field<DateTimeGraphType>("dataUltimaUtilizacao");
			Field<ContaFinanceiraInputType>("contaFinanceira");
			Field<EstadoInputType>("estado");
			Field<TipoCartaoPagamentoInputType>("tipoCartaoPagamento");
			Field<ListGraphType<InformacaoBancariaInputType>>("informacaoBancaria");
			
		}
	}
}