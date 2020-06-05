using GraphQL.Types;
using ISS.Application.Dto;

namespace ISS.GraphQL
{
    public class GetPlanoProdutoType : ObjectGraphType<PlanoCormecialProdutoDto>
    {
        public GetPlanoProdutoType()
        {

            Name = "GetPlanoprodutoType";
            Field(x => x.Quantidade);
            Field(x => x.Produto);
           
        }
    }

  
}