using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EncargoPlanoType : ObjectGraphType<EncargoPlano>
    {
        public EncargoPlanoType()
        {
            // Defining the name of the object
            Name = "encargoPlano";

            Field(x => x.IdEncargoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.EncargoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodEncargoPlano, nullable: true);
            FieldAsync<EncargosType>("encargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Encargos>(c.Source.EncargoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class EncargoPlanoInputType : InputObjectGraphType
	{
		public EncargoPlanoInputType()
		{
			// Defining the name of the object
			Name = "encargoPlanoInput";
			
            //Field<StringGraphType>("idEncargoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("encargoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codEncargoPlano");
			Field<EncargosInputType>("encargo");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}