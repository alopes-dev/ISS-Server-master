using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoeficientePremioAdesaoType : ObjectGraphType<CoeficientePremioAdesao>
    {
        public CoeficientePremioAdesaoType()
        {
            // Defining the name of the object
            Name = "coeficientePremioAdesao";

            Field(x => x.IdCoeficientePremioAdesao, nullable: true);
            Field(x => x.TipoAdesaoId, nullable: true);
            Field(x => x.AgravamentoOuDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodCoeficientePremioAdesao, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoAdesaoType>("tipoAdesao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoAdesao>(c.Source.TipoAdesaoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class CoeficientePremioAdesaoInputType : InputObjectGraphType
	{
		public CoeficientePremioAdesaoInputType()
		{
			// Defining the name of the object
			Name = "coeficientePremioAdesaoInput";
			
            //Field<StringGraphType>("idCoeficientePremioAdesao");
			Field<StringGraphType>("tipoAdesaoId");
			Field<FloatGraphType>("agravamentoOuDesconto");
			Field<StringGraphType>("codCoeficientePremioAdesao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<EstadoInputType>("estado");
			Field<TipoAdesaoInputType>("tipoAdesao");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}