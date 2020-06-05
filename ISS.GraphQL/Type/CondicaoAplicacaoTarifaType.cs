using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicaoAplicacaoTarifaType : ObjectGraphType<CondicaoAplicacaoTarifa>
    {
        public CondicaoAplicacaoTarifaType()
        {
            // Defining the name of the object
            Name = "condicaoAplicacaoTarifa";

            Field(x => x.IdCondicaoAplicacaoTarifa, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCondicaoAplicacaoTarifa, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CapitalSeguro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorPremioSimplesMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorPremioSimplesMin, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CondicaoTarifaType>>("condicaoTarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoTarifa>(x => x.Where(e => e.HasValue(c.Source.IdCondicaoAplicacaoTarifa)))));
            
        }
    }

    public class CondicaoAplicacaoTarifaInputType : InputObjectGraphType
	{
		public CondicaoAplicacaoTarifaInputType()
		{
			// Defining the name of the object
			Name = "condicaoAplicacaoTarifaInput";
			
            //Field<StringGraphType>("idCondicaoAplicacaoTarifa");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCondicaoAplicacaoTarifa");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<FloatGraphType>("capitalSeguro");
			Field<FloatGraphType>("valorPremioSimplesMax");
			Field<StringGraphType>("valorPremioSimplesMin");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CondicaoTarifaInputType>>("condicaoTarifa");
			
		}
	}
}