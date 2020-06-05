using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OperaccoesPagamentoType : ObjectGraphType<OperaccoesPagamento>
    {
        public OperaccoesPagamentoType()
        {
            // Defining the name of the object
            Name = "operaccoesPagamento";

            Field(x => x.IdOperaccoesPagamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodOperaccoesPagamento, nullable: true);
            Field(x => x.SubTipoPagamentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SubTipoPagamentoType>("subTipoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTipoPagamento>(c.Source.SubTipoPagamentoId)));
            FieldAsync<ListGraphType<ImpostoType>>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(x => x.Where(e => e.HasValue(c.Source.IdOperaccoesPagamento)))));
            
        }
    }

    public class OperaccoesPagamentoInputType : InputObjectGraphType
	{
		public OperaccoesPagamentoInputType()
		{
			// Defining the name of the object
			Name = "operaccoesPagamentoInput";
			
            //Field<StringGraphType>("idOperaccoesPagamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codOperaccoesPagamento");
			Field<StringGraphType>("subTipoPagamentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<SubTipoPagamentoInputType>("subTipoPagamento");
			Field<ListGraphType<ImpostoInputType>>("imposto");
			
		}
	}
}