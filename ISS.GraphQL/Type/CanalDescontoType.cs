using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CanalDescontoType : ObjectGraphType<CanalDesconto>
    {
        public CanalDescontoType()
        {
            // Defining the name of the object
            Name = "canalDesconto";

            Field(x => x.IdCanalDesconto, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            
        }
    }

    public class CanalDescontoInputType : InputObjectGraphType
	{
		public CanalDescontoInputType()
		{
			// Defining the name of the object
			Name = "canalDescontoInput";
			
            //Field<StringGraphType>("idCanalDesconto");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("descontoId");
			Field<CanalInputType>("canal");
			Field<DescontoInputType>("desconto");
			
		}
	}
}