using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AcrescimoCapitalMinimoType : ObjectGraphType<AcrescimoCapitalMinimo>
    {
        public AcrescimoCapitalMinimoType()
        {
            // Defining the name of the object
            Name = "acrescimoCapitalMinimo";

            Field(x => x.Designacao, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CapitaMinimo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaPremioAcrescido, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodAcrescimoCapitalMinimo, nullable: true);
            Field(x => x.IdAcrescimoCapitalMinimo, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class AcrescimoCapitalMinimoInputType : InputObjectGraphType
	{
		public AcrescimoCapitalMinimoInputType()
		{
			// Defining the name of the object
			Name = "acrescimoCapitalMinimoInput";
			
            Field<StringGraphType>("designacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("capitaMinimo");
			Field<FloatGraphType>("taxaPremioAcrescido");
			Field<StringGraphType>("codAcrescimoCapitalMinimo");
			//Field<StringGraphType>("idAcrescimoCapitalMinimo");
			Field<EstadoInputType>("estado");
			
		}
	}
}