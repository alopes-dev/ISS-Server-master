using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoClausulaType : ObjectGraphType<ContratoClausula>
    {
        public ContratoClausulaType()
        {
            // Defining the name of the object
            Name = "contratoClausula";

            Field(x => x.IdContratoClausula, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.ClausulaId, nullable: true);
            FieldAsync<ClausulaType>("clausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Clausula>(c.Source.ClausulaId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            
        }
    }

    public class ContratoClausulaInputType : InputObjectGraphType
	{
		public ContratoClausulaInputType()
		{
			// Defining the name of the object
			Name = "contratoClausulaInput";
			
            //Field<StringGraphType>("idContratoClausula");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("clausulaId");
			Field<ClausulaInputType>("clausula");
			Field<ContratoInputType>("contrato");
			
		}
	}
}