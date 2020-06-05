using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoFormaPagamentoType : ObjectGraphType<ContratoFormaPagamento>
    {
        public ContratoFormaPagamentoType()
        {
            // Defining the name of the object
            Name = "contratoFormaPagamento";

            Field(x => x.IdContratoFormaPagamento, nullable: true);
            Field(x => x.FormaPagamentoId, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.CodContratoFormaPagamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            
        }
    }

    public class ContratoFormaPagamentoInputType : InputObjectGraphType
	{
		public ContratoFormaPagamentoInputType()
		{
			// Defining the name of the object
			Name = "contratoFormaPagamentoInput";
			
            //Field<StringGraphType>("idContratoFormaPagamento");
			Field<StringGraphType>("formaPagamentoId");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("codContratoFormaPagamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ContratoInputType>("contrato");
			Field<FormaPagamentoInputType>("formaPagamento");
			
		}
	}
}