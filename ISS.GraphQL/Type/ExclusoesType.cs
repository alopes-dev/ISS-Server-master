using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExclusoesType : ObjectGraphType<Exclusoes>
    {
        public ExclusoesType()
        {
            // Defining the name of the object
            Name = "exclusoes";

            Field(x => x.IdExclusoes, nullable: true);
            Field(x => x.CodExclusoes, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.IsPadrao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.RiscoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.TipoExclusaoId, nullable: true);
            Field(x => x.IsEspecifica, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsAdicional, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<RiscoType>("risco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Risco>(c.Source.RiscoId)));
            FieldAsync<TipoExclusaoType>("tipoExclusao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoExclusao>(c.Source.TipoExclusaoId)));
            FieldAsync<ListGraphType<ExclusoesCoberturaType>>("exclusoesCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExclusoesCobertura>(x => x.Where(e => e.HasValue(c.Source.IdExclusoes)))));
            FieldAsync<ListGraphType<ExclusoesPlanoType>>("exclusoesPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExclusoesPlano>(x => x.Where(e => e.HasValue(c.Source.IdExclusoes)))));
            FieldAsync<ListGraphType<ExclusoesSelecionadaApoliceType>>("exclusoesSelecionadaApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExclusoesSelecionadaApolice>(x => x.Where(e => e.HasValue(c.Source.IdExclusoes)))));
            FieldAsync<ListGraphType<ExclusoesSelecionadaLinhaProdutoType>>("exclusoesSelecionadaLinhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExclusoesSelecionadaLinhaProduto>(x => x.Where(e => e.HasValue(c.Source.IdExclusoes)))));
            FieldAsync<ListGraphType<ExclusoesSelecionadaPlanoType>>("exclusoesSelecionadaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExclusoesSelecionadaPlano>(x => x.Where(e => e.HasValue(c.Source.IdExclusoes)))));
            FieldAsync<ListGraphType<ItensExclusaoType>>("itensExclusao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ItensExclusao>(x => x.Where(e => e.HasValue(c.Source.IdExclusoes)))));
            
        }
    }

    public class ExclusoesInputType : InputObjectGraphType
	{
		public ExclusoesInputType()
		{
			// Defining the name of the object
			Name = "exclusoesInput";
			
            //Field<StringGraphType>("idExclusoes");
			Field<StringGraphType>("codExclusoes");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("produtoId");
			Field<BooleanGraphType>("isPadrao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("riscoId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("tipoExclusaoId");
			Field<BooleanGraphType>("isEspecifica");
			Field<BooleanGraphType>("isAdicional");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ProdutoInputType>("produto");
			Field<RiscoInputType>("risco");
			Field<TipoExclusaoInputType>("tipoExclusao");
			Field<ListGraphType<ExclusoesCoberturaInputType>>("exclusoesCobertura");
			Field<ListGraphType<ExclusoesPlanoInputType>>("exclusoesPlano");
			Field<ListGraphType<ExclusoesSelecionadaApoliceInputType>>("exclusoesSelecionadaApolice");
			Field<ListGraphType<ExclusoesSelecionadaLinhaProdutoInputType>>("exclusoesSelecionadaLinhaProduto");
			Field<ListGraphType<ExclusoesSelecionadaPlanoInputType>>("exclusoesSelecionadaPlano");
			Field<ListGraphType<ItensExclusaoInputType>>("itensExclusao");
			
		}
	}
}