using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DesvalorizacaoPlanoType : ObjectGraphType<DesvalorizacaoPlano>
    {
        public DesvalorizacaoPlanoType()
        {
            // Defining the name of the object
            Name = "desvalorizacaoPlano";

            Field(x => x.IdDesvalorizacaoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DesvalorizacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<DesvalorizacaoType>("desvalorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desvalorizacao>(c.Source.DesvalorizacaoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DesvalorizacaoPlanoInputType : InputObjectGraphType
	{
		public DesvalorizacaoPlanoInputType()
		{
			// Defining the name of the object
			Name = "desvalorizacaoPlanoInput";
			
            //Field<StringGraphType>("idDesvalorizacaoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("desvalorizacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<DesvalorizacaoInputType>("desvalorizacao");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}