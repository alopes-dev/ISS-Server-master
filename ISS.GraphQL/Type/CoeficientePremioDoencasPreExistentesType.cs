using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoeficientePremioDoencasPreExistentesType : ObjectGraphType<CoeficientePremioDoencasPreExistentes>
    {
        public CoeficientePremioDoencasPreExistentesType()
        {
            // Defining the name of the object
            Name = "coeficientePremioDoencasPreExistentes";

            Field(x => x.IdCoeficientePremioDoencasPreExistentes, nullable: true);
            Field(x => x.TemPeriodoCarencia, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.AgravamentoOuDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodCoeficientePremioDoencasPreExistentes, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class CoeficientePremioDoencasPreExistentesInputType : InputObjectGraphType
	{
		public CoeficientePremioDoencasPreExistentesInputType()
		{
			// Defining the name of the object
			Name = "coeficientePremioDoencasPreExistentesInput";
			
            //Field<StringGraphType>("idCoeficientePremioDoencasPreExistentes");
			Field<BooleanGraphType>("temPeriodoCarencia");
			Field<FloatGraphType>("agravamentoOuDesconto");
			Field<StringGraphType>("codCoeficientePremioDoencasPreExistentes");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<EstadoInputType>("estado");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}