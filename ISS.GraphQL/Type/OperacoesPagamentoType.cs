using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OperacoesPagamentoType : ObjectGraphType<OperacoesPagamento>
    {
        public OperacoesPagamentoType()
        {
            // Defining the name of the object
            Name = "operacoesPagamento";

            Field(x => x.IdOperacoesPagamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodOperacoesPagamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorRegraOperacao, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.ContaId, nullable: true);
            Field(x => x.CaminhoIcome, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<PlanoContasType>("conta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.ContaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<ApoliceType>>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(x => x.Where(e => e.HasValue(c.Source.IdOperacoesPagamento)))));
            FieldAsync<ListGraphType<AprovacaoType>>("aprovacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Aprovacao>(x => x.Where(e => e.HasValue(c.Source.IdOperacoesPagamento)))));
            FieldAsync<ListGraphType<ClassificacaoOperacaoType>>("classificacaoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoOperacao>(x => x.Where(e => e.HasValue(c.Source.IdOperacoesPagamento)))));
            FieldAsync<ListGraphType<LimiteCompetenciaType>>("limiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdOperacoesPagamento)))));
            FieldAsync<ListGraphType<NotaType>>("nota", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Nota>(x => x.Where(e => e.HasValue(c.Source.IdOperacoesPagamento)))));
            FieldAsync<ListGraphType<PlanoProdutoType>>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdOperacoesPagamento)))));
            
        }
    }

    public class OperacoesPagamentoInputType : InputObjectGraphType
	{
		public OperacoesPagamentoInputType()
		{
			// Defining the name of the object
			Name = "operacoesPagamentoInput";
			
            //Field<StringGraphType>("idOperacoesPagamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codOperacoesPagamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("valorRegraOperacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("contaId");
			Field<StringGraphType>("caminhoIcome");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<PlanoContasInputType>("conta");
			Field<EstadoInputType>("estado");
			Field<PapelInputType>("papel");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<ListGraphType<ApoliceInputType>>("apolice");
			Field<ListGraphType<AprovacaoInputType>>("aprovacao");
			Field<ListGraphType<ClassificacaoOperacaoInputType>>("classificacaoOperacao");
			Field<ListGraphType<LimiteCompetenciaInputType>>("limiteCompetencia");
			Field<ListGraphType<NotaInputType>>("nota");
			Field<ListGraphType<PlanoProdutoInputType>>("planoProduto");
			
		}
	}
}