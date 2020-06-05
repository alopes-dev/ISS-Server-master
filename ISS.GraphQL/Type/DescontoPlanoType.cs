using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoPlanoType : ObjectGraphType<DescontoPlano>
    {
        public DescontoPlanoType()
        {
            // Defining the name of the object
            Name = "descontoPlano";

            Field(x => x.IdDescontoPlano, nullable: true);
            Field(x => x.CodDescontoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DescontoPlanoInputType : InputObjectGraphType
	{
		public DescontoPlanoInputType()
		{
			// Defining the name of the object
			Name = "descontoPlanoInput";
			
            //Field<StringGraphType>("idDescontoPlano");
			Field<StringGraphType>("codDescontoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("descontoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DescontoInputType>("desconto");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}