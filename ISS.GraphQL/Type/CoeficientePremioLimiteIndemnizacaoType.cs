using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoeficientePremioLimiteIndemnizacaoType : ObjectGraphType<CoeficientePremioLimiteIndemnizacao>
    {
        public CoeficientePremioLimiteIndemnizacaoType()
        {
            // Defining the name of the object
            Name = "coeficientePremioLimiteIndemnizacao";

            Field(x => x.IdCoeficientePremioLimiteIndemnizacao, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.AgravamentoOuDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodCoeficientePremioLimiteIndemnizacao, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class CoeficientePremioLimiteIndemnizacaoInputType : InputObjectGraphType
	{
		public CoeficientePremioLimiteIndemnizacaoInputType()
		{
			// Defining the name of the object
			Name = "coeficientePremioLimiteIndemnizacaoInput";
			
            //Field<StringGraphType>("idCoeficientePremioLimiteIndemnizacao");
			Field<FloatGraphType>("valor");
			Field<FloatGraphType>("agravamentoOuDesconto");
			Field<StringGraphType>("codCoeficientePremioLimiteIndemnizacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<EstadoInputType>("estado");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}