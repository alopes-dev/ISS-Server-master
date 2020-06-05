
using GraphQL.Types;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;
using ISS.Application.Models;
using ISS.GraphQL.Type;

namespace ISS.GraphQL
{
    public class PagamentoDtoType : ObjectGraphType<PagamentoDto>
	{
        public PagamentoDtoType()
        {
            Name = "pagamento";
            
            Field(x => x.FormaPagamentoId,type:typeof(StringGraphType));
            Field(x => x.CartaoPagamentoId,type:typeof(StringGraphType));
            Field(x => x.PropostaRef,type:typeof(StringGraphType));
            Field(x => x.ValorAPagar,type:typeof(FloatGraphType));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            FieldAsync<CartaoPagamentoType>("cartaoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CartaoPagamento>(c.Source.CartaoPagamentoId)));
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.PropostaRef)));
        }
    }

    public class PagamentoDtoInputType : InputObjectGraphType
	{
        public PagamentoDtoInputType()
        {
            Name = "pagamentoInput";
        
            Field<StringGraphType>("formaPagamentoId");
            Field<StringGraphType>("cartaoPagamentoId");
            Field<StringGraphType>("moedaId");
            Field<StringGraphType>("propostaRef");
            Field<FloatGraphType>("valorAPagar");
        }
    }
}