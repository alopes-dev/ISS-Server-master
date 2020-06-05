using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExcepcoesPlanoType : ObjectGraphType<ExcepcoesPlano>
    {
        public ExcepcoesPlanoType()
        {
            // Defining the name of the object
            Name = "excepcoesPlano";

            Field(x => x.IdExcepcaoPlano, nullable: true);
            Field(x => x.ExcepcaoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodExcepcoesPlano, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ExcepcoesType>("excepcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Excepcoes>(c.Source.ExcepcaoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class ExcepcoesPlanoInputType : InputObjectGraphType
	{
		public ExcepcoesPlanoInputType()
		{
			// Defining the name of the object
			Name = "excepcoesPlanoInput";
			
            //Field<StringGraphType>("idExcepcaoPlano");
			Field<StringGraphType>("excepcaoId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codExcepcoesPlano");
			Field<StringGraphType>("estadoId");
			Field<ExcepcoesInputType>("excepcao");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}