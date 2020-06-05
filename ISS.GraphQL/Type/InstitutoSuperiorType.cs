using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class InstitutoSuperiorType : ObjectGraphType<InstitutoSuperior>
    {
        public InstitutoSuperiorType()
        {
            // Defining the name of the object
            Name = "institutoSuperior";

            Field(x => x.IdInstituto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodInstitutoSuperior, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<FaculdadeType>>("faculdade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Faculdade>(x => x.Where(e => e.HasValue(c.Source.IdInstituto)))));
            
        }
    }

    public class InstitutoSuperiorInputType : InputObjectGraphType
	{
		public InstitutoSuperiorInputType()
		{
			// Defining the name of the object
			Name = "institutoSuperiorInput";
			
            //Field<StringGraphType>("idInstituto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codInstitutoSuperior");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<FaculdadeInputType>>("faculdade");
			
		}
	}
}