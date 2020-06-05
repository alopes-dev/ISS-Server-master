using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TaxaPremioFixoIndicNomeType : ObjectGraphType<TaxaPremioFixoIndicNome>
    {
        public TaxaPremioFixoIndicNomeType()
        {
            // Defining the name of the object
            Name = "taxaPremioFixoIndicNome";

            Field(x => x.IdTaxaPremioFixo, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TaxaPremioFixoIndicNomeInputType : InputObjectGraphType
	{
		public TaxaPremioFixoIndicNomeInputType()
		{
			// Defining the name of the object
			Name = "taxaPremioFixoIndicNomeInput";
			
            //Field<StringGraphType>("idTaxaPremioFixo");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("isTaxa");
			Field<EstadoInputType>("estado");
			
		}
	}
}