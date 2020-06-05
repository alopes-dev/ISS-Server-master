using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ImpostoPlanoType : ObjectGraphType<ImpostoPlano>
    {
        public ImpostoPlanoType()
        {
            // Defining the name of the object
            Name = "impostoPlano";

            Field(x => x.IdImpostoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.ImpostoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ImpostoType>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(c.Source.ImpostoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class ImpostoPlanoInputType : InputObjectGraphType
	{
		public ImpostoPlanoInputType()
		{
			// Defining the name of the object
			Name = "impostoPlanoInput";
			
            //Field<StringGraphType>("idImpostoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("impostoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ImpostoInputType>("imposto");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}