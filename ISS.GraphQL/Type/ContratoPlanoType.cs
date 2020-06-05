using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoPlanoType : ObjectGraphType<ContratoPlano>
    {
        public ContratoPlanoType()
        {
            // Defining the name of the object
            Name = "contratoPlano";

            Field(x => x.IdContratoPlano, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.CodContratoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class ContratoPlanoInputType : InputObjectGraphType
	{
		public ContratoPlanoInputType()
		{
			// Defining the name of the object
			Name = "contratoPlanoInput";
			
            //Field<StringGraphType>("idContratoPlano");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("codContratoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ContratoInputType>("contrato");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}