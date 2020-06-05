using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgendaPlanoType : ObjectGraphType<AgendaPlano>
    {
        public AgendaPlanoType()
        {
            // Defining the name of the object
            Name = "agendaPlano";

            Field(x => x.IdAgendaPlano, nullable: true);
            Field(x => x.AgendaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<AgendaType>("agenda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agenda>(c.Source.AgendaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class AgendaPlanoInputType : InputObjectGraphType
	{
		public AgendaPlanoInputType()
		{
			// Defining the name of the object
			Name = "agendaPlanoInput";
			
            //Field<StringGraphType>("idAgendaPlano");
			Field<StringGraphType>("agendaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("planoProdutoId");
			Field<AgendaInputType>("agenda");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}