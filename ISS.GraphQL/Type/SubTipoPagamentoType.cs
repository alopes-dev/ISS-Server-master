using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubTipoPagamentoType : ObjectGraphType<SubTipoPagamento>
    {
        public SubTipoPagamentoType()
        {
            // Defining the name of the object
            Name = "subTipoPagamento";

            Field(x => x.IdSubTipoPagamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodigoSubTipoPagamento, nullable: true);
            Field(x => x.TipoPagamentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoPagamentoType>("tipoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPagamento>(c.Source.TipoPagamentoId)));
            FieldAsync<ListGraphType<OperaccoesPagamentoType>>("operaccoesPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperaccoesPagamento>(x => x.Where(e => e.HasValue(c.Source.IdSubTipoPagamento)))));
            
        }
    }

    public class SubTipoPagamentoInputType : InputObjectGraphType
	{
		public SubTipoPagamentoInputType()
		{
			// Defining the name of the object
			Name = "subTipoPagamentoInput";
			
            //Field<StringGraphType>("idSubTipoPagamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codigoSubTipoPagamento");
			Field<StringGraphType>("tipoPagamentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TipoPagamentoInputType>("tipoPagamento");
			Field<ListGraphType<OperaccoesPagamentoInputType>>("operaccoesPagamento");
			
		}
	}
}