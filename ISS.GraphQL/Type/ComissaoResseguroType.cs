using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComissaoResseguroType : ObjectGraphType<ComissaoResseguro>
    {
        public ComissaoResseguroType()
        {
            // Defining the name of the object
            Name = "comissaoResseguro";

            Field(x => x.IdComissoes, nullable: true);
            Field(x => x.ResseguroId, nullable: true);
            Field(x => x.ComissaoId, nullable: true);
            FieldAsync<ComissaoPlanoType>("comissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoPlano>(c.Source.ComissaoId)));
            FieldAsync<ResseguroType>("resseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Resseguro>(c.Source.ResseguroId)));
            
        }
    }

    public class ComissaoResseguroInputType : InputObjectGraphType
	{
		public ComissaoResseguroInputType()
		{
			// Defining the name of the object
			Name = "comissaoResseguroInput";
			
            //Field<StringGraphType>("idComissoes");
			Field<StringGraphType>("resseguroId");
			Field<StringGraphType>("comissaoId");
			Field<ComissaoPlanoInputType>("comissao");
			Field<ResseguroInputType>("resseguro");
			
		}
	}
}