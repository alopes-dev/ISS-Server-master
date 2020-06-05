using GraphQL.Types;
using ISS.Application.Dto;

namespace ISS.GraphQL
{
    public class GetPlanoType : ObjectGraphType<PlanoObjectivoCormecialDto>
    {
        public GetPlanoType()
        {

            Name = "GetPlanoType";
            Field(x => x.Quantidade, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Mes, nullable: true, type: typeof(IntGraphType));
           
        }
    }

    // public class GetPlanoTypeInputType : InputObjectGraphType
	// {
	// 	public GetPlanoTypeInputType()
	// 	{

	// 		Name = "GetPlanoTypeInput";
	// 		Field<IntGraphType>("quantidade");
	// 		Field<IntGraphType>("mes");
			
	// 	}
	// }
}