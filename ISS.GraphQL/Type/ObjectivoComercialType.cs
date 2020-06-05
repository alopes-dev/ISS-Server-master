using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObjectivoComercialType : ObjectGraphType<ObjectivoComercial>
    {
        public ObjectivoComercialType()
        {
            // Defining the name of the object
            Name = "objectivoComercial";

            Field(x => x.IdObjectivoComercial, nullable: true);
            Field(x => x.Indicador, nullable: true);
            Field(x => x.ValorObjectivo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoObjectivoComercialId, nullable: true);
            Field(x => x.ValorReal, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Desvio, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Resultado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Ponderacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodObjectivoComercial, nullable: true);
            Field(x => x.ValorPlaneado, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<TipoObjectivoComercialType>("tipoObjectivoComercial", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoObjectivoComercial>(c.Source.TipoObjectivoComercialId)));
            
        }
    }

    public class ObjectivoComercialInputType : InputObjectGraphType
	{
		public ObjectivoComercialInputType()
		{
			// Defining the name of the object
			Name = "objectivoComercialInput";
			
            //Field<StringGraphType>("idObjectivoComercial");
			Field<StringGraphType>("indicador");
			Field<FloatGraphType>("valorObjectivo");
			Field<StringGraphType>("tipoObjectivoComercialId");
			Field<FloatGraphType>("valorReal");
			Field<FloatGraphType>("desvio");
			Field<FloatGraphType>("resultado");
			Field<FloatGraphType>("ponderacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codObjectivoComercial");
			Field<FloatGraphType>("valorPlaneado");
			Field<TipoObjectivoComercialInputType>("tipoObjectivoComercial");
			
		}
	}
}