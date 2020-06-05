using GraphQL.Types;
using ISS.Application.Dto.Calculos;

namespace ISS.GraphQL
{
    public class CambioModelType : ObjectGraphType<CambioModel>
    {
        public CambioModelType()
        {

            // Defining the name of the object
            Name = "cambioModel";

            Field(x => x.Moeda, nullable: true);
            Field(x => x.OutraMoeda, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.OutraMoedaId, nullable: true);
            Field(x => x.CodMoeda, nullable: true);
            Field(x => x.CodOutraMoeda, nullable: true);
            Field(x => x.SimboloMoeda, nullable: true);
            Field(x => x.SimboloOutraMoeda, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorOutraMoeda, nullable: true, type: typeof(FloatGraphType));
            Field<ListGraphType<StringGraphType>>("mensagens");
        }
    }

    public class CambioModelInputType : InputObjectGraphType
    {
        public CambioModelInputType()
        {
            // Defining the name of the object
            Name = "cambioModelInput";

            Field<StringGraphType>("moedaId");
            Field<StringGraphType>("outraMoedaId");
            Field<FloatGraphType>("valor");
            Field<FloatGraphType>("valorOutraMoeda");
        }
    }
}