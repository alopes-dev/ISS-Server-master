using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ServicoPlanoType : ObjectGraphType<ServicoPlano>
    {
        public ServicoPlanoType()
        {
            // Defining the name of the object
            Name = "servicoPlano";

            Field(x => x.IdServicoPlano, nullable: true);
            Field(x => x.ServicoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ServicoType>("servico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Servico>(c.Source.ServicoId)));
            
        }
    }

    public class ServicoPlanoInputType : InputObjectGraphType
	{
		public ServicoPlanoInputType()
		{
			// Defining the name of the object
			Name = "servicoPlanoInput";
			
            //Field<StringGraphType>("idServicoPlano");
			Field<StringGraphType>("servicoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("planoProdutoId");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ServicoInputType>("servico");
			
		}
	}
}