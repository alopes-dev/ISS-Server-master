using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LicencaModuloType : ObjectGraphType<LicencaModulo>
    {
        public LicencaModuloType()
        {
            // Defining the name of the object
            Name = "licencaModulo";

            Field(x => x.IdLicencaModulo, nullable: true);
            Field(x => x.NumLicencaAtribuido, nullable: true);
            Field(x => x.NumLicensaUtilizado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataVencimento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ModuloCoreId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModuloCoreType>("moduloCore", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModuloCore>(c.Source.ModuloCoreId)));
            FieldAsync<ListGraphType<LicencaModuloUserType>>("licencaModuloUser", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LicencaModuloUser>(x => x.Where(e => e.HasValue(c.Source.IdLicencaModulo)))));
            
        }
    }

    public class LicencaModuloInputType : InputObjectGraphType
	{
		public LicencaModuloInputType()
		{
			// Defining the name of the object
			Name = "licencaModuloInput";
			
            //Field<StringGraphType>("idLicencaModulo");
			Field<StringGraphType>("numLicencaAtribuido");
			Field<BooleanGraphType>("numLicensaUtilizado");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataVencimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("moduloCoreId");
			Field<EstadoInputType>("estado");
			Field<ModuloCoreInputType>("moduloCore");
			Field<ListGraphType<LicencaModuloUserInputType>>("licencaModuloUser");
			
		}
	}
}