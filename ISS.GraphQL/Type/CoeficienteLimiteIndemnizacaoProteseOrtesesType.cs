using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoeficienteLimiteIndemnizacaoProteseOrtesesType : ObjectGraphType<CoeficienteLimiteIndemnizacaoProteseOrteses>
    {
        public CoeficienteLimiteIndemnizacaoProteseOrtesesType()
        {
            // Defining the name of the object
            Name = "coeficienteLimiteIndemnizacaoProteseOrteses";

            Field(x => x.IdCoeficienteLimiteIndemnizacaoProteseOrteses, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.AgravamentoOuDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodCoeficienteLimiteIndemnizacaoOrteses, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoOrtesesProteses, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoOrtesesProtesesType>("tipoOrtesesProtesesNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOrtesesProteses>(c.Source.TipoOrtesesProteses)));
            
        }
    }

    public class CoeficienteLimiteIndemnizacaoProteseOrtesesInputType : InputObjectGraphType
	{
		public CoeficienteLimiteIndemnizacaoProteseOrtesesInputType()
		{
			// Defining the name of the object
			Name = "coeficienteLimiteIndemnizacaoProteseOrtesesInput";
			
            //Field<StringGraphType>("idCoeficienteLimiteIndemnizacaoProteseOrteses");
			Field<FloatGraphType>("valor");
			Field<FloatGraphType>("agravamentoOuDesconto");
			Field<StringGraphType>("codCoeficienteLimiteIndemnizacaoOrteses");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoOrtesesProteses");
			Field<EstadoInputType>("estado");
			Field<TipoOrtesesProtesesInputType>("tipoOrtesesProtesesNavigation");
			
		}
	}
}