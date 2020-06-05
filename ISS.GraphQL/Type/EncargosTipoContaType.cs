using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EncargosTipoContaType : ObjectGraphType<EncargosTipoConta>
    {
        public EncargosTipoContaType()
        {
            // Defining the name of the object
            Name = "encargosTipoConta";

            Field(x => x.IdEncargosTipoConta, nullable: true);
            Field(x => x.EncargosId, nullable: true);
            Field(x => x.CodEncargosTipoConta, nullable: true);
            Field(x => x.TipoContaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EncargosType>("encargos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Encargos>(c.Source.EncargosId)));
            FieldAsync<TipoContaType>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(c.Source.TipoContaId)));
            
        }
    }

    public class EncargosTipoContaInputType : InputObjectGraphType
	{
		public EncargosTipoContaInputType()
		{
			// Defining the name of the object
			Name = "encargosTipoContaInput";
			
            //Field<StringGraphType>("idEncargosTipoConta");
			Field<StringGraphType>("encargosId");
			Field<StringGraphType>("codEncargosTipoConta");
			Field<StringGraphType>("tipoContaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<EncargosInputType>("encargos");
			Field<TipoContaInputType>("tipoConta");
			
		}
	}
}