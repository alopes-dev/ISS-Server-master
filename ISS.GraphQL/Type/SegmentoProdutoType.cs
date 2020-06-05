using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SegmentoProdutoType : ObjectGraphType<SegmentoProduto>
    {
        public SegmentoProdutoType()
        {
            // Defining the name of the object
            Name = "segmentoProduto";

            Field(x => x.IdSegmentoProduto, nullable: true);
            Field(x => x.IdadeMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.IdadeMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.SexoId, nullable: true);
            Field(x => x.BalcaoId, nullable: true);
            Field(x => x.FidelizacaoId, nullable: true);
            Field(x => x.TipoSegmentoId, nullable: true);
            Field(x => x.Caeid, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodSegmentoProduto, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<BalcaoType>("balcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Balcao>(c.Source.BalcaoId)));
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.Caeid)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FidelizacaoType>("fidelizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fidelizacao>(c.Source.FidelizacaoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<SexoType>("sexo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sexo>(c.Source.SexoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            FieldAsync<ListGraphType<ComissionamentoType>>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(x => x.Where(e => e.HasValue(c.Source.IdSegmentoProduto)))));
            FieldAsync<ListGraphType<SegmentoProdutoPlanoType>>("segmentoProdutoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoProdutoPlano>(x => x.Where(e => e.HasValue(c.Source.IdSegmentoProduto)))));
            
        }
    }

    public class SegmentoProdutoInputType : InputObjectGraphType
	{
		public SegmentoProdutoInputType()
		{
			// Defining the name of the object
			Name = "segmentoProdutoInput";
			
            //Field<StringGraphType>("idSegmentoProduto");
			Field<IntGraphType>("idadeMin");
			Field<IntGraphType>("idadeMax");
			Field<StringGraphType>("sexoId");
			Field<StringGraphType>("balcaoId");
			Field<StringGraphType>("fidelizacaoId");
			Field<StringGraphType>("tipoSegmentoId");
			Field<StringGraphType>("caeid");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codSegmentoProduto");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("planoProdutoId");
			Field<BalcaoInputType>("balcao");
			Field<CaeInputType>("cae");
			Field<EstadoInputType>("estado");
			Field<FidelizacaoInputType>("fidelizacao");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<SexoInputType>("sexo");
			Field<PlanoContasInputType>("subConta");
			Field<TipoSegmentoInputType>("tipoSegmento");
			Field<ListGraphType<ComissionamentoInputType>>("comissionamento");
			Field<ListGraphType<SegmentoProdutoPlanoInputType>>("segmentoProdutoPlano");
			
		}
	}
}