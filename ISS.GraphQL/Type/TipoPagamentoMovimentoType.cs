using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPagamentoMovimentoType : ObjectGraphType<TipoPagamentoMovimento>
    {
        public TipoPagamentoMovimentoType()
        {
            // Defining the name of the object
            Name = "tipoPagamentoMovimento";

            Field(x => x.TipoPagamentoId, nullable: true);
            Field(x => x.MovimentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ModificadoPor, nullable: true);
            Field(x => x.CodTipoPagamentoMovimento, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoPagamentoMovimentoInputType : InputObjectGraphType
	{
		public TipoPagamentoMovimentoInputType()
		{
			// Defining the name of the object
			Name = "tipoPagamentoMovimentoInput";
			
            Field<StringGraphType>("tipoPagamentoId");
			//Field<StringGraphType>("movimentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("modificadoPor");
			Field<StringGraphType>("codTipoPagamentoMovimento");
			Field<EstadoInputType>("estado");
			
		}
	}
}