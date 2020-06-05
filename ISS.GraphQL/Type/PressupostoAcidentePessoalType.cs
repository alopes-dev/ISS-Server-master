using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PressupostoAcidentePessoalType : ObjectGraphType<PressupostoAcidentePessoal>
    {
        public PressupostoAcidentePessoalType()
        {
            // Defining the name of the object
            Name = "pressupostoAcidentePessoal";

            Field(x => x.IdPressupostoAcidentePessoal, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodPressupostoAcidentePessoal, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class PressupostoAcidentePessoalInputType : InputObjectGraphType
	{
		public PressupostoAcidentePessoalInputType()
		{
			// Defining the name of the object
			Name = "pressupostoAcidentePessoalInput";
			
            //Field<StringGraphType>("idPressupostoAcidentePessoal");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codPressupostoAcidentePessoal");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}