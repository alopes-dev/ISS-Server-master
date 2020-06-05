using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LicencaType : ObjectGraphType<Licenca>
    {
        public LicencaType()
        {
            // Defining the name of the object
            Name = "licenca";

            Field(x => x.IdLicenca, nullable: true);
            Field(x => x.ChaveLicenca, nullable: true);
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NumLicenca, nullable: true, type: typeof(IntGraphType));
            FieldAsync<ListGraphType<MenuType>>("menu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Menu>(x => x.Where(e => e.HasValue(c.Source.IdLicenca)))));
            
        }
    }

    public class LicencaInputType : InputObjectGraphType
	{
		public LicencaInputType()
		{
			// Defining the name of the object
			Name = "licencaInput";
			
            //Field<StringGraphType>("idLicenca");
			Field<StringGraphType>("chaveLicenca");
			Field<DateTimeGraphType>("dataFim");
			Field<DateTimeGraphType>("dataInicio");
			Field<IntGraphType>("numLicenca");
			Field<ListGraphType<MenuInputType>>("menu");
			
		}
	}
}