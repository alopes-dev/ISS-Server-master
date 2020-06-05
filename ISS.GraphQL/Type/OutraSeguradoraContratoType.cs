using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OutraSeguradoraContratoType : ObjectGraphType<OutraSeguradoraContrato>
    {
        public OutraSeguradoraContratoType()
        {
            // Defining the name of the object
            Name = "outraSeguradoraContrato";

            Field(x => x.IdOutraSeguradoraContrato, nullable: true);
            Field(x => x.CodOutraSeguradoraContrato, nullable: true);
            Field(x => x.NifoutraSeguradora, nullable: true);
            Field(x => x.NumeroContrato, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Duracao, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CapitalSeguro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoRamoSeguroId, nullable: true);
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoRamoSeguroType>("tipoRamoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRamoSeguro>(c.Source.TipoRamoSeguroId)));
            FieldAsync<ListGraphType<OutrosContratosApoliceType>>("outrosContratosApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OutrosContratosApolice>(x => x.Where(e => e.HasValue(c.Source.IdOutraSeguradoraContrato)))));
            FieldAsync<ListGraphType<RiscoOutraSeguradoraContratoType>>("riscoOutraSeguradoraContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RiscoOutraSeguradoraContrato>(x => x.Where(e => e.HasValue(c.Source.IdOutraSeguradoraContrato)))));
            
        }
    }

    public class OutraSeguradoraContratoInputType : InputObjectGraphType
	{
		public OutraSeguradoraContratoInputType()
		{
			// Defining the name of the object
			Name = "outraSeguradoraContratoInput";
			
            //Field<StringGraphType>("idOutraSeguradoraContrato");
			Field<StringGraphType>("codOutraSeguradoraContrato");
			Field<StringGraphType>("nifoutraSeguradora");
			Field<IntGraphType>("numeroContrato");
			Field<IntGraphType>("duracao");
			Field<FloatGraphType>("capitalSeguro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoRamoSeguroId");
			Field<DateTimeGraphType>("dataInicio");
			Field<EstadoInputType>("estado");
			Field<TipoRamoSeguroInputType>("tipoRamoSeguro");
			Field<ListGraphType<OutrosContratosApoliceInputType>>("outrosContratosApolice");
			Field<ListGraphType<RiscoOutraSeguradoraContratoInputType>>("riscoOutraSeguradoraContrato");
			
		}
	}
}