using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AmbitoPlanoType : ObjectGraphType<AmbitoPlano>
    {
        public AmbitoPlanoType()
        {
            // Defining the name of the object
            Name = "ambitoPlano";

            Field(x => x.IdAmbitoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodAmbitoPlano, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class AmbitoPlanoInputType : InputObjectGraphType
	{
		public AmbitoPlanoInputType()
		{
			// Defining the name of the object
			Name = "ambitoPlanoInput";
			
            //Field<StringGraphType>("idAmbitoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codAmbitoPlano");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}