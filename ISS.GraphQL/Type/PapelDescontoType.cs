using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PapelDescontoType : ObjectGraphType<PapelDesconto>
    {
        public PapelDescontoType()
        {
            // Defining the name of the object
            Name = "papelDesconto";

            Field(x => x.IdPapelDesconto, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            
        }
    }

    public class PapelDescontoInputType : InputObjectGraphType
	{
		public PapelDescontoInputType()
		{
			// Defining the name of the object
			Name = "papelDescontoInput";
			
            //Field<StringGraphType>("idPapelDesconto");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("descontoId");
			Field<DescontoInputType>("desconto");
			Field<PapelInputType>("papel");
			
		}
	}
}