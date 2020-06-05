using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MovimentoPlanoType : ObjectGraphType<MovimentoPlano>
    {
        public MovimentoPlanoType()
        {
            // Defining the name of the object
            Name = "movimentoPlano";

            Field(x => x.IdMovimentoPlano, nullable: true);
            Field(x => x.MovimentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<MovimentoType>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(c.Source.MovimentoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class MovimentoPlanoInputType : InputObjectGraphType
	{
		public MovimentoPlanoInputType()
		{
			// Defining the name of the object
			Name = "movimentoPlanoInput";
			
            //Field<StringGraphType>("idMovimentoPlano");
			Field<StringGraphType>("movimentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("planoProdutoId");
			Field<MovimentoInputType>("movimento");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}