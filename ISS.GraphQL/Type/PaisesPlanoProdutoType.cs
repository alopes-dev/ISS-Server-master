using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PaisesPlanoProdutoType : ObjectGraphType<PaisesPlanoProduto>
    {
        public PaisesPlanoProdutoType()
        {
            // Defining the name of the object
            Name = "paisesPlanoProduto";

            Field(x => x.IdPaisesPlanoProduto, nullable: true);
            Field(x => x.PaisId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<PaisType>("pais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class PaisesPlanoProdutoInputType : InputObjectGraphType
	{
		public PaisesPlanoProdutoInputType()
		{
			// Defining the name of the object
			Name = "paisesPlanoProdutoInput";
			
            //Field<StringGraphType>("idPaisesPlanoProduto");
			Field<StringGraphType>("paisId");
			Field<StringGraphType>("planoProdutoId");
			Field<PaisInputType>("pais");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}