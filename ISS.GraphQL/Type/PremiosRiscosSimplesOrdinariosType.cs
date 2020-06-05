using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PremiosRiscosSimplesOrdinariosType : ObjectGraphType<PremiosRiscosSimplesOrdinarios>
    {
        public PremiosRiscosSimplesOrdinariosType()
        {
            // Defining the name of the object
            Name = "premiosRiscosSimplesOrdinarios";

            Field(x => x.IdRiscosSimplesOrdinarios, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Localidade, nullable: true);
            Field(x => x.CodPremiosRiscosSimplesOrdinarios, nullable: true);
            Field(x => x.Risco1, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco2, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco3, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PremiosRiscosSimplesOrdinariosInputType : InputObjectGraphType
	{
		public PremiosRiscosSimplesOrdinariosInputType()
		{
			// Defining the name of the object
			Name = "premiosRiscosSimplesOrdinariosInput";
			
            //Field<StringGraphType>("idRiscosSimplesOrdinarios");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("localidade");
			Field<StringGraphType>("codPremiosRiscosSimplesOrdinarios");
			Field<FloatGraphType>("risco1");
			Field<FloatGraphType>("risco2");
			Field<FloatGraphType>("risco3");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}