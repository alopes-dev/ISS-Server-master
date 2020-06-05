using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DespesasCoberturaType : ObjectGraphType<DespesasCobertura>
    {
        public DespesasCoberturaType()
        {
            // Defining the name of the object
            Name = "despesasCobertura";

            Field(x => x.IdDespesasCobertura, nullable: true);
            Field(x => x.CoberturaId, nullable: true);
            Field(x => x.DespesasId, nullable: true);
            FieldAsync<DespesaType>("despesas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(c.Source.DespesasId)));
            
        }
    }

    public class DespesasCoberturaInputType : InputObjectGraphType
	{
		public DespesasCoberturaInputType()
		{
			// Defining the name of the object
			Name = "despesasCoberturaInput";
			
            //Field<StringGraphType>("idDespesasCobertura");
			Field<StringGraphType>("coberturaId");
			Field<StringGraphType>("despesasId");
			Field<DespesaInputType>("despesas");
			
		}
	}
}