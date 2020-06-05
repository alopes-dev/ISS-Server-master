using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FranquiaInvalidezTemporariaType : ObjectGraphType<FranquiaInvalidezTemporaria>
    {
        public FranquiaInvalidezTemporariaType()
        {
            // Defining the name of the object
            Name = "franquiaInvalidezTemporaria";

            Field(x => x.IdFranquiaIncapacidadeTemporaria, nullable: true);
            Field(x => x.IdTaxaSinistralidade, nullable: true);
            Field(x => x.TaxaFranquia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodFranquia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TaxaSinistralidadeType>("idTaxaSinistralidadeNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TaxaSinistralidade>(c.Source.IdTaxaSinistralidade)));
            
        }
    }

    public class FranquiaInvalidezTemporariaInputType : InputObjectGraphType
	{
		public FranquiaInvalidezTemporariaInputType()
		{
			// Defining the name of the object
			Name = "franquiaInvalidezTemporariaInput";
			
            //Field<StringGraphType>("idFranquiaIncapacidadeTemporaria");
			Field<StringGraphType>("idTaxaSinistralidade");
			Field<FloatGraphType>("taxaFranquia");
			Field<StringGraphType>("codFranquia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TaxaSinistralidadeInputType>("idTaxaSinistralidadeNavigation");
			
		}
	}
}