using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgravamentoPlanoType : ObjectGraphType<AgravamentoPlano>
    {
        public AgravamentoPlanoType()
        {
            // Defining the name of the object
            Name = "agravamentoPlano";

            Field(x => x.IdAgravamentoPlano, nullable: true);
            Field(x => x.AgravamentoId, nullable: true);
            Field(x => x.PlanoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodAgravamentoPlano, nullable: true);
            FieldAsync<AgravamentoType>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(c.Source.AgravamentoId)));
            FieldAsync<PlanoProdutoType>("plano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoId)));
            
        }
    }

    public class AgravamentoPlanoInputType : InputObjectGraphType
	{
		public AgravamentoPlanoInputType()
		{
			// Defining the name of the object
			Name = "agravamentoPlanoInput";
			
            //Field<StringGraphType>("idAgravamentoPlano");
			Field<StringGraphType>("agravamentoId");
			Field<StringGraphType>("planoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codAgravamentoPlano");
			Field<AgravamentoInputType>("agravamento");
			Field<PlanoProdutoInputType>("plano");
			
		}
	}
}