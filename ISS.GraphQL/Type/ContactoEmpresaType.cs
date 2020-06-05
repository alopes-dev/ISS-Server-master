using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContactoEmpresaType : ObjectGraphType<ContactoEmpresa>
    {
        public ContactoEmpresaType()
        {
            // Defining the name of the object
            Name = "contactoEmpresa";

            Field(x => x.IdContactoPessoa, nullable: true);
            Field(x => x.Principal, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EmpresaId, nullable: true);
            Field(x => x.ContactoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ContactoType>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(c.Source.ContactoId)));
            FieldAsync<EmpresaType>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(c.Source.EmpresaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ContactoEmpresaInputType : InputObjectGraphType
	{
		public ContactoEmpresaInputType()
		{
			// Defining the name of the object
			Name = "contactoEmpresaInput";
			
            //Field<StringGraphType>("idContactoPessoa");
			Field<BooleanGraphType>("principal");
			Field<StringGraphType>("empresaId");
			Field<StringGraphType>("contactoId");
			Field<StringGraphType>("estadoId");
			Field<ContactoInputType>("contacto");
			Field<EmpresaInputType>("empresa");
			Field<EstadoInputType>("estado");
			
		}
	}
}