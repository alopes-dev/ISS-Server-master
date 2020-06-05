using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgravamentoDespesaType : ObjectGraphType<AgravamentoDespesa>
    {
        public AgravamentoDespesaType()
        {
            // Defining the name of the object
            Name = "agravamentoDespesa";

            Field(x => x.IdAgravamentoDespesa, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.AgravamentoId, nullable: true);
            Field(x => x.DespesaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<AgravamentoType>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(c.Source.AgravamentoId)));
            FieldAsync<DespesaType>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(c.Source.DespesaId)));
            
        }
    }

    public class AgravamentoDespesaInputType : InputObjectGraphType
	{
		public AgravamentoDespesaInputType()
		{
			// Defining the name of the object
			Name = "agravamentoDespesaInput";
			
            //Field<StringGraphType>("idAgravamentoDespesa");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("agravamentoId");
			Field<StringGraphType>("despesaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<AgravamentoInputType>("agravamento");
			Field<DespesaInputType>("despesa");
			
		}
	}
}