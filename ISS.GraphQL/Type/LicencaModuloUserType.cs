using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LicencaModuloUserType : ObjectGraphType<LicencaModuloUser>
    {
        public LicencaModuloUserType()
        {
            // Defining the name of the object
            Name = "licencaModuloUser";

            Field(x => x.IdLicencaModuloUser, nullable: true);
            Field(x => x.LicencaModuloId, nullable: true);
            FieldAsync<LicencaModuloType>("licencaModulo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LicencaModulo>(c.Source.LicencaModuloId)));
            
        }
    }

    public class LicencaModuloUserInputType : InputObjectGraphType
	{
		public LicencaModuloUserInputType()
		{
			// Defining the name of the object
			Name = "licencaModuloUserInput";
			
            //Field<StringGraphType>("idLicencaModuloUser");
			Field<StringGraphType>("licencaModuloId");
			Field<LicencaModuloInputType>("licencaModulo");
			
		}
	}
}