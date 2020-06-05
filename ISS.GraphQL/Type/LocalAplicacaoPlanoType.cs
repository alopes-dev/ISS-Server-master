using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocalAplicacaoPlanoType : ObjectGraphType<LocalAplicacaoPlano>
    {
        public LocalAplicacaoPlanoType()
        {
            // Defining the name of the object
            Name = "localAplicacaoPlano";

            Field(x => x.IdLocalAplicacaoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<AgravamentoType>>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(x => x.Where(e => e.HasValue(c.Source.IdLocalAplicacaoPlano)))));
            FieldAsync<ListGraphType<DespesaType>>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(x => x.Where(e => e.HasValue(c.Source.IdLocalAplicacaoPlano)))));
            FieldAsync<ListGraphType<MargemVendaProdutoType>>("margemVendaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MargemVendaProduto>(x => x.Where(e => e.HasValue(c.Source.IdLocalAplicacaoPlano)))));
            
        }
    }

    public class LocalAplicacaoPlanoInputType : InputObjectGraphType
	{
		public LocalAplicacaoPlanoInputType()
		{
			// Defining the name of the object
			Name = "localAplicacaoPlanoInput";
			
            //Field<StringGraphType>("idLocalAplicacaoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("enderecoId");
			Field<EnderecoInputType>("endereco");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<AgravamentoInputType>>("agravamento");
			Field<ListGraphType<DespesaInputType>>("despesa");
			Field<ListGraphType<MargemVendaProdutoInputType>>("margemVendaProduto");
			
		}
	}
}