using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExcepcoesType : ObjectGraphType<Excepcoes>
    {
        public ExcepcoesType()
        {
            // Defining the name of the object
            Name = "excepcoes";

            Field(x => x.IdExcepcao, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.CodExcepcao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.NumOrdem, nullable: true);
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<ExcepcoesPlanoType>>("excepcoesPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExcepcoesPlano>(x => x.Where(e => e.HasValue(c.Source.IdExcepcao)))));
            
        }
    }

    public class ExcepcoesInputType : InputObjectGraphType
	{
		public ExcepcoesInputType()
		{
			// Defining the name of the object
			Name = "excepcoesInput";
			
            //Field<StringGraphType>("idExcepcao");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("codExcepcao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("numOrdem");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<ExcepcoesPlanoInputType>>("excepcoesPlano");
			
		}
	}
}