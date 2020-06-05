using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GarantiasAfetasDespesasMedicasType : ObjectGraphType<GarantiasAfetasDespesasMedicas>
    {
        public GarantiasAfetasDespesasMedicasType()
        {
            // Defining the name of the object
            Name = "garantiasAfetasDespesasMedicas";

            Field(x => x.GarantiasProdutoId, nullable: true);
            Field(x => x.DespesasApresentadas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Comparticipacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ReembolsoDespesasMedicas, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<GarantiasCoberturaType>("garantiasProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GarantiasCobertura>(c.Source.GarantiasProdutoId)));
            FieldAsync<ReembolsoDespesasMedicasType>("reembolsoDespesasMedicasNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReembolsoDespesasMedicas>(c.Source.ReembolsoDespesasMedicas)));
            
        }
    }

    public class GarantiasAfetasDespesasMedicasInputType : InputObjectGraphType
	{
		public GarantiasAfetasDespesasMedicasInputType()
		{
			// Defining the name of the object
			Name = "garantiasAfetasDespesasMedicasInput";
			
            //Field<StringGraphType>("garantiasProdutoId");
			Field<FloatGraphType>("despesasApresentadas");
			Field<FloatGraphType>("comparticipacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("reembolsoDespesasMedicas");
			Field<EstadoInputType>("estado");
			Field<GarantiasCoberturaInputType>("garantiasProduto");
			Field<ReembolsoDespesasMedicasInputType>("reembolsoDespesasMedicasNavigation");
			
		}
	}
}