using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LeadType : ObjectGraphType<Lead>
    {
        public LeadType()
        {
            // Defining the name of the object
            Name = "lead";

            Field(x => x.IdLead, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodLead, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.Observacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class LeadInputType : InputObjectGraphType
	{
		public LeadInputType()
		{
			// Defining the name of the object
			Name = "leadInput";
			
            //Field<StringGraphType>("idLead");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codLead");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("observacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}