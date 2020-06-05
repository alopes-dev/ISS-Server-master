using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OperacaoType : ObjectGraphType<Operacao>
    {
        public OperacaoType()
        {
            // Defining the name of the object
            Name = "operacao";

            Field(x => x.IdOperacao, nullable: true);
            Field(x => x.CodOperacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.ClassificacaoOperacaoId, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<ClassificacaoOperacaoType>("classificacaoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoOperacao>(c.Source.ClassificacaoOperacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<CondicaoOperacaoType>("condicaoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoOperacao>(c.Source.IdOperacao)));
            FieldAsync<ListGraphType<ComissaoPlanoType>>("comissaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdOperacao)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdOperacao)))));
            FieldAsync<ListGraphType<OperacaoPlanoType>>("operacaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdOperacao)))));
            
        }
    }

    public class OperacaoInputType : InputObjectGraphType
	{
		public OperacaoInputType()
		{
			// Defining the name of the object
			Name = "operacaoInput";
			
            //Field<StringGraphType>("idOperacao");
			Field<StringGraphType>("codOperacao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("classificacaoOperacaoId");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<ClassificacaoOperacaoInputType>("classificacaoOperacao");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<PlanoContasInputType>("subConta");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<CondicaoOperacaoInputType>("condicaoOperacao");
			Field<ListGraphType<ComissaoPlanoInputType>>("comissaoPlano");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<OperacaoPlanoInputType>>("operacaoPlano");
			
		}
	}
}