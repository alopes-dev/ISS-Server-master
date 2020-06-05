using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgravamentoPessoaType : ObjectGraphType<AgravamentoPessoa>
    {
        public AgravamentoPessoaType()
        {
            // Defining the name of the object
            Name = "agravamentoPessoa";

            Field(x => x.IdAgravamentoPessoa, nullable: true);
            Field(x => x.IdadeMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.IdadeMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Percentagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescricaoAgravamentoPessoa, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodAgravamentoPessoa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.AgravamentoId, nullable: true);
            FieldAsync<AgravamentoType>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(c.Source.AgravamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class AgravamentoPessoaInputType : InputObjectGraphType
	{
		public AgravamentoPessoaInputType()
		{
			// Defining the name of the object
			Name = "agravamentoPessoaInput";
			
            //Field<StringGraphType>("idAgravamentoPessoa");
			Field<IntGraphType>("idadeMin");
			Field<IntGraphType>("idadeMax");
			Field<FloatGraphType>("percentagem");
			Field<StringGraphType>("descricaoAgravamentoPessoa");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codAgravamentoPessoa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("agravamentoId");
			Field<AgravamentoInputType>("agravamento");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ProdutoInputType>("produto");
			
		}
	}
}