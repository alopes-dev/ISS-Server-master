using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCartaoPagamentoType : ObjectGraphType<TipoCartaoPagamento>
    {
        public TipoCartaoPagamentoType()
        {
            // Defining the name of the object
            Name = "tipoCartaoPagamento";

            Field(x => x.IdTipoCartaoPagamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoCartaoPagamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.FormaPagamentoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            FieldAsync<ListGraphType<BandeiraTipoCartaoType>>("bandeiraTipoCartao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BandeiraTipoCartao>(x => x.Where(e => e.HasValue(c.Source.IdTipoCartaoPagamento)))));
            FieldAsync<ListGraphType<CartaoPagamentoType>>("cartaoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CartaoPagamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoCartaoPagamento)))));
            
        }
    }

    public class TipoCartaoPagamentoInputType : InputObjectGraphType
	{
		public TipoCartaoPagamentoInputType()
		{
			// Defining the name of the object
			Name = "tipoCartaoPagamentoInput";
			
            //Field<StringGraphType>("idTipoCartaoPagamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoCartaoPagamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("formaPagamentoId");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoInputType>("formaPagamento");
			Field<ListGraphType<BandeiraTipoCartaoInputType>>("bandeiraTipoCartao");
			Field<ListGraphType<CartaoPagamentoInputType>>("cartaoPagamento");
			
		}
	}
}