using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoeficienteLimiteIndemnizacaoPartoType : ObjectGraphType<CoeficienteLimiteIndemnizacaoParto>
    {
        public CoeficienteLimiteIndemnizacaoPartoType()
        {
            // Defining the name of the object
            Name = "coeficienteLimiteIndemnizacaoParto";

            Field(x => x.IdCoeficienteLimiteIndemnizacaoParto, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.AgravamentoOuDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodCoeficienteLimiteIndemnizacaoParto, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoPartoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoPartoType>("tipoParto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoParto>(c.Source.TipoPartoId)));
            
        }
    }

    public class CoeficienteLimiteIndemnizacaoPartoInputType : InputObjectGraphType
	{
		public CoeficienteLimiteIndemnizacaoPartoInputType()
		{
			// Defining the name of the object
			Name = "coeficienteLimiteIndemnizacaoPartoInput";
			
            //Field<StringGraphType>("idCoeficienteLimiteIndemnizacaoParto");
			Field<FloatGraphType>("valor");
			Field<FloatGraphType>("agravamentoOuDesconto");
			Field<StringGraphType>("codCoeficienteLimiteIndemnizacaoParto");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoPartoId");
			Field<EstadoInputType>("estado");
			Field<TipoPartoInputType>("tipoParto");
			
		}
	}
}