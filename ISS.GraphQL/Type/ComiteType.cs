using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComiteType : ObjectGraphType<Comite>
    {
        public ComiteType()
        {
            // Defining the name of the object
            Name = "comite";

            Field(x => x.IdComite, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.EmpresaId, nullable: true);
            FieldAsync<EmpresaType>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(c.Source.EmpresaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            
        }
    }

    public class ComiteInputType : InputObjectGraphType
	{
		public ComiteInputType()
		{
			// Defining the name of the object
			Name = "comiteInput";
			
            //Field<StringGraphType>("idComite");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("empresaId");
			Field<EmpresaInputType>("empresa");
			Field<EstadoInputType>("estado");
			Field<PlanoContasInputType>("subConta");
			
		}
	}
}