using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RendimentosPessoaType : ObjectGraphType<RendimentosPessoa>
    {
        public RendimentosPessoaType()
        {
            // Defining the name of the object
            Name = "rendimentosPessoa";

            Field(x => x.IdRendimentosPessoa, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.SalarioBaseMensal, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodRendimentosPessoa, nullable: true);
            Field(x => x.SubSidioAlimentacaoMensal, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.OutrosRendimentosMensais, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaSimplesBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Caeid, nullable: true);
            Field(x => x.NumFuncionarios, nullable: true, type: typeof(IntGraphType));
            Field(x => x.MassaSalarialLiquida, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.FormaLiquidacaoPremioId, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.SubSidioNatal, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SubSidioFeria, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoContratacaoId, nullable: true);
            Field(x => x.EntidadeEmpregadoraId, nullable: true);
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.Caeid)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<PessoaType>("entidadeEmpregadora", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.EntidadeEmpregadoraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaLiquidacaoPremioType>("formaLiquidacaoPremio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaLiquidacaoPremio>(c.Source.FormaLiquidacaoPremioId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoContratacaoType>("tipoContratacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContratacao>(c.Source.TipoContratacaoId)));
            
        }
    }

    public class RendimentosPessoaInputType : InputObjectGraphType
	{
		public RendimentosPessoaInputType()
		{
			// Defining the name of the object
			Name = "rendimentosPessoaInput";
			
            //Field<StringGraphType>("idRendimentosPessoa");
			Field<StringGraphType>("pessoaId");
			Field<FloatGraphType>("salarioBaseMensal");
			Field<StringGraphType>("codRendimentosPessoa");
			Field<FloatGraphType>("subSidioAlimentacaoMensal");
			Field<FloatGraphType>("outrosRendimentosMensais");
			Field<FloatGraphType>("taxaSimplesBase");
			Field<StringGraphType>("caeid");
			Field<IntGraphType>("numFuncionarios");
			Field<FloatGraphType>("massaSalarialLiquida");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("formaLiquidacaoPremioId");
			Field<StringGraphType>("cotacaoId");
			Field<FloatGraphType>("subSidioNatal");
			Field<FloatGraphType>("subSidioFeria");
			Field<StringGraphType>("tipoContratacaoId");
			Field<StringGraphType>("entidadeEmpregadoraId");
			Field<CaeInputType>("cae");
			Field<CotacaoInputType>("cotacao");
			Field<PessoaInputType>("entidadeEmpregadora");
			Field<EstadoInputType>("estado");
			Field<FormaLiquidacaoPremioInputType>("formaLiquidacaoPremio");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoContratacaoInputType>("tipoContratacao");
			
		}
	}
}