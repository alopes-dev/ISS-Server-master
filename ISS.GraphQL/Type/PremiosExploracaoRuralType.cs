using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PremiosExploracaoRuralType : ObjectGraphType<PremiosExploracaoRural>
    {
        public PremiosExploracaoRuralType()
        {
            // Defining the name of the object
            Name = "premiosExploracaoRural";

            Field(x => x.IdPremiosExploracaoRural, nullable: true);
            Field(x => x.TipoObjecto, nullable: true);
            Field(x => x.Objecto, nullable: true);
            Field(x => x.Risco1, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco2, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco3, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PremiosExploracaoRuralInputType : InputObjectGraphType
	{
		public PremiosExploracaoRuralInputType()
		{
			// Defining the name of the object
			Name = "premiosExploracaoRuralInput";
			
            //Field<StringGraphType>("idPremiosExploracaoRural");
			Field<StringGraphType>("tipoObjecto");
			Field<StringGraphType>("objecto");
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