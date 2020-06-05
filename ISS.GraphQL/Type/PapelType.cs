using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PapelType : ObjectGraphType<Papel>
    {
        public PapelType()
        {
            // Defining the name of the object
            Name = "papel";

            Field(x => x.IdPapel, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.NumRegistos, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodPapel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsProdutor, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.TipoSegmentoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.CodDesignacao, nullable: true);
            Field(x => x.TipoContratacaoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<TipoContratacaoType>("tipoContratacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContratacao>(c.Source.TipoContratacaoId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            FieldAsync<ListGraphType<ComissaoPlanoType>>("comissaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<ComissionamentoType>>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<CondicaoOperacaoType>>("condicaoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoOperacao>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<MenuType>>("menu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Menu>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<OperacoesCrudpessoaType>>("operacoesCrudpessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesCrudpessoa>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<OperacoesPagamentoType>>("operacoesPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesPagamento>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<PapelDescontoType>>("papelDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelDesconto>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<PapelPessoaType>>("papelPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPessoa>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<PapelPlanoType>>("papelPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPlano>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<PapelProdutorType>>("papelProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelProdutor>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<TarefasAgendamentoType>>("tarefasAgendamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefasAgendamento>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<TarifaType>>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<TipoContaType>>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            FieldAsync<ListGraphType<TipoOperacaoType>>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(x => x.Where(e => e.HasValue(c.Source.IdPapel)))));
            
        }
    }

    public class PapelInputType : InputObjectGraphType
	{
		public PapelInputType()
		{
			// Defining the name of the object
			Name = "papelInput";
			
            //Field<StringGraphType>("idPapel");
			Field<StringGraphType>("designacao");
			Field<IntGraphType>("numRegistos");
			Field<StringGraphType>("codPapel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isProdutor");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("tipoSegmentoId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("codDesignacao");
			Field<StringGraphType>("tipoContratacaoId");
			Field<EstadoInputType>("estado");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PlanoContasInputType>("subConta");
			Field<TipoContratacaoInputType>("tipoContratacao");
			Field<TipoSegmentoInputType>("tipoSegmento");
			Field<ListGraphType<ComissaoPlanoInputType>>("comissaoPlano");
			Field<ListGraphType<ComissionamentoInputType>>("comissionamento");
			Field<ListGraphType<CondicaoOperacaoInputType>>("condicaoOperacao");
			Field<ListGraphType<MenuInputType>>("menu");
			Field<ListGraphType<OperacoesCrudpessoaInputType>>("operacoesCrudpessoa");
			Field<ListGraphType<OperacoesPagamentoInputType>>("operacoesPagamento");
			Field<ListGraphType<PapelDescontoInputType>>("papelDesconto");
			Field<ListGraphType<PapelPessoaInputType>>("papelPessoa");
			Field<ListGraphType<PapelPlanoInputType>>("papelPlano");
			Field<ListGraphType<PapelProdutorInputType>>("papelProdutor");
			Field<ListGraphType<TarefasAgendamentoInputType>>("tarefasAgendamento");
			Field<ListGraphType<TarifaInputType>>("tarifa");
			Field<ListGraphType<TipoContaInputType>>("tipoConta");
			Field<ListGraphType<TipoOperacaoInputType>>("tipoOperacao");
			
		}
	}
}