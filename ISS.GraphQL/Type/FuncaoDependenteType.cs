using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FuncaoDependenteType : ObjectGraphType<FuncaoDependente>
    {
        public FuncaoDependenteType()
        {
            // Defining the name of the object
            Name = "funcaoDependente";

            Field(x => x.IdFuncaoDependente, nullable: true);
            Field(x => x.FuncaoDependenteId, nullable: true);
            Field(x => x.FuncaoMaeId, nullable: true);
            FieldAsync<FuncaoType>("funcaoDependenteNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(c.Source.FuncaoDependenteId)));
            FieldAsync<FuncaoType>("funcaoMae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(c.Source.FuncaoMaeId)));
            
        }
    }

    public class FuncaoDependenteInputType : InputObjectGraphType
	{
		public FuncaoDependenteInputType()
		{
			// Defining the name of the object
			Name = "funcaoDependenteInput";
			
            //Field<StringGraphType>("idFuncaoDependente");
			Field<StringGraphType>("funcaoDependenteId");
			Field<StringGraphType>("funcaoMaeId");
			Field<FuncaoInputType>("funcaoDependenteNavigation");
			Field<FuncaoInputType>("funcaoMae");
			
		}
	}
}