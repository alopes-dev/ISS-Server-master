using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicaoTarifaType : ObjectGraphType<CondicaoTarifa>
    {
        public CondicaoTarifaType()
        {
            // Defining the name of the object
            Name = "condicaoTarifa";

            Field(x => x.IdCondicaoTarifa, nullable: true);
            Field(x => x.CondicaoAplicacaoTarifaId, nullable: true);
            Field(x => x.TarifaId, nullable: true);
            Field(x => x.Valor, nullable: true);
            Field(x => x.UnidadeId, nullable: true);
            Field(x => x.CodCondicaoTarifa, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<CondicaoAplicacaoTarifaType>("condicaoAplicacaoTarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoAplicacaoTarifa>(c.Source.CondicaoAplicacaoTarifaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TarifaType>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(c.Source.TarifaId)));
            
        }
    }

    public class CondicaoTarifaInputType : InputObjectGraphType
	{
		public CondicaoTarifaInputType()
		{
			// Defining the name of the object
			Name = "condicaoTarifaInput";
			
            //Field<StringGraphType>("idCondicaoTarifa");
			Field<StringGraphType>("condicaoAplicacaoTarifaId");
			Field<StringGraphType>("tarifaId");
			Field<StringGraphType>("valor");
			Field<StringGraphType>("unidadeId");
			Field<StringGraphType>("codCondicaoTarifa");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<CondicaoAplicacaoTarifaInputType>("condicaoAplicacaoTarifa");
			Field<EstadoInputType>("estado");
			Field<TarifaInputType>("tarifa");
			
		}
	}
}