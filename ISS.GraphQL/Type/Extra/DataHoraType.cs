using GraphQL.Types;

namespace ISS.GraphQL.Type.Base
{
    public class DataHoraType : ObjectGraphType<ISS.GraphQL.Query.DataHora>
    {
        public DataHoraType()
        {
            Field(x => x.Data);
            Field(x => x.Hora);
        }
    }
}
