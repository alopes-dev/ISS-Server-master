using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoPessoaPlanoType : ObjectGraphType<DescontoPessoaPlano>
    {
        public DescontoPessoaPlanoType()
        {
            // Defining the name of the object
            Name = "descontoPessoaPlano";

            Field(x => x.IdDescontoPessoaPlano, nullable: true);
            Field(x => x.CodDescontoPessoaPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DescontoPessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<DescontoPessoaType>("descontoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoPessoa>(c.Source.DescontoPessoaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DescontoPessoaPlanoInputType : InputObjectGraphType
	{
		public DescontoPessoaPlanoInputType()
		{
			// Defining the name of the object
			Name = "descontoPessoaPlanoInput";
			
            //Field<StringGraphType>("idDescontoPessoaPlano");
			Field<StringGraphType>("codDescontoPessoaPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("descontoPessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<DescontoPessoaInputType>("descontoPessoa");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}