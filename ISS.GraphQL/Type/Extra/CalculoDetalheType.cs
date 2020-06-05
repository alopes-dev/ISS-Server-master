using GraphQL.Types;
using ISS.Application.Dto;

namespace ISS.GraphQL
{
    public class CalculoDetalheType : ObjectGraphType<CalculoDetalhe>
    {
        public CalculoDetalheType()
        {

            // Defining the name of the object
            Name = "calculoDetalhe";

            Field(x => x.Descricao, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
        }
    }
}