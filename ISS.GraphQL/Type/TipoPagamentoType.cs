using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPagamentoType : ObjectGraphType<TipoPagamento>
    {
        public TipoPagamentoType()
        {
            // Defining the name of the object
            Name = "tipoPagamento";

            Field(x => x.IdTipoPagamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodTipoPagamento, nullable: true);
            Field(x => x.CodigoTipoPagamento, nullable: true, type: typeof(IntGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ContratoType>>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdTipoPagamento)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdTipoPagamento)))));
            FieldAsync<ListGraphType<SubTipoPagamentoType>>("subTipoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTipoPagamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoPagamento)))));
            
        }
    }

    public class TipoPagamentoInputType : InputObjectGraphType
	{
		public TipoPagamentoInputType()
		{
			// Defining the name of the object
			Name = "tipoPagamentoInput";
			
            //Field<StringGraphType>("idTipoPagamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("codTipoPagamento");
			Field<IntGraphType>("codigoTipoPagamento");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ContratoInputType>>("contrato");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			Field<ListGraphType<SubTipoPagamentoInputType>>("subTipoPagamento");
			
		}
	}
}