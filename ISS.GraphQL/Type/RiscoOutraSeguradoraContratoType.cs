using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RiscoOutraSeguradoraContratoType : ObjectGraphType<RiscoOutraSeguradoraContrato>
    {
        public RiscoOutraSeguradoraContratoType()
        {
            // Defining the name of the object
            Name = "riscoOutraSeguradoraContrato";

            Field(x => x.IdRiscoOutraSeguradoraContrato, nullable: true);
            Field(x => x.CodRiscoOutraSeguradoraContrato, nullable: true);
            Field(x => x.RiscoId, nullable: true);
            Field(x => x.OutraSeguradoraContratoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<OutraSeguradoraContratoType>("outraSeguradoraContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OutraSeguradoraContrato>(c.Source.OutraSeguradoraContratoId)));
            FieldAsync<RiscoType>("risco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Risco>(c.Source.RiscoId)));
            
        }
    }

    public class RiscoOutraSeguradoraContratoInputType : InputObjectGraphType
	{
		public RiscoOutraSeguradoraContratoInputType()
		{
			// Defining the name of the object
			Name = "riscoOutraSeguradoraContratoInput";
			
            //Field<StringGraphType>("idRiscoOutraSeguradoraContrato");
			Field<StringGraphType>("codRiscoOutraSeguradoraContrato");
			Field<StringGraphType>("riscoId");
			Field<StringGraphType>("outraSeguradoraContratoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<OutraSeguradoraContratoInputType>("outraSeguradoraContrato");
			Field<RiscoInputType>("risco");
			
		}
	}
}