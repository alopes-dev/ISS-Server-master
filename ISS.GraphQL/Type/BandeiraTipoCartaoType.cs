using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BandeiraTipoCartaoType : ObjectGraphType<BandeiraTipoCartao>
    {
        public BandeiraTipoCartaoType()
        {
            // Defining the name of the object
            Name = "bandeiraTipoCartao";

            Field(x => x.IdBandeiraTipoCartao, nullable: true);
            Field(x => x.CodBandeiraTipoCartao, nullable: true);
            Field(x => x.TipoCartaoPagamentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.BandeiraPagamentoId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<BandeiraPagamentoType>("bandeiraPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BandeiraPagamento>(c.Source.BandeiraPagamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCartaoPagamentoType>("tipoCartaoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCartaoPagamento>(c.Source.TipoCartaoPagamentoId)));
            
        }
    }

    public class BandeiraTipoCartaoInputType : InputObjectGraphType
	{
		public BandeiraTipoCartaoInputType()
		{
			// Defining the name of the object
			Name = "bandeiraTipoCartaoInput";
			
            //Field<StringGraphType>("idBandeiraTipoCartao");
			Field<StringGraphType>("codBandeiraTipoCartao");
			Field<StringGraphType>("tipoCartaoPagamentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("bandeiraPagamentoId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<BandeiraPagamentoInputType>("bandeiraPagamento");
			Field<EstadoInputType>("estado");
			Field<TipoCartaoPagamentoInputType>("tipoCartaoPagamento");
			
		}
	}
}