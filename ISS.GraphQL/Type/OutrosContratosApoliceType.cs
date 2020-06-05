using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OutrosContratosApoliceType : ObjectGraphType<OutrosContratosApolice>
    {
        public OutrosContratosApoliceType()
        {
            // Defining the name of the object
            Name = "outrosContratosApolice";

            Field(x => x.IdOutrosContratosApolice, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.OutraSeguradoraContratoId, nullable: true);
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<OutraSeguradoraContratoType>("outraSeguradoraContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OutraSeguradoraContrato>(c.Source.OutraSeguradoraContratoId)));
            
        }
    }

    public class OutrosContratosApoliceInputType : InputObjectGraphType
	{
		public OutrosContratosApoliceInputType()
		{
			// Defining the name of the object
			Name = "outrosContratosApoliceInput";
			
            //Field<StringGraphType>("idOutrosContratosApolice");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("outraSeguradoraContratoId");
			Field<CotacaoInputType>("cotacao");
			Field<OutraSeguradoraContratoInputType>("outraSeguradoraContrato");
			
		}
	}
}