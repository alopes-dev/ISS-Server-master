using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoType : ObjectGraphType<Desconto>
    {
        public DescontoType()
        {
            // Defining the name of the object
            Name = "desconto";

            Field(x => x.IdDesconto, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoDescontoId, nullable: true);
            Field(x => x.CodDesconto, nullable: true);
            Field(x => x.ValorMinPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorMinDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.TipoTarifaId, nullable: true);
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.TipoPagamentoId, nullable: true);
            Field(x => x.LocalAplicacaoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Nota, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<CanalDescontoType>>("canalDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalDesconto>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<DescontoApoliceGrupoType>>("descontoApoliceGrupo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoApoliceGrupo>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<DescontoLinhaType>>("descontoLinha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoLinha>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<DescontoPessoaType>>("descontoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<DescontoPlanoType>>("descontoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoPlano>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<DescontoSeleccionadoType>>("descontoSeleccionado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoSeleccionado>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<DescontoTipoContaType>>("descontoTipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoTipoConta>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<FormaContratacaoType>>("formaContratacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaContratacao>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<LocaisDescontoType>>("locaisDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisDesconto>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<MembroAsseguradoType>>("membroAssegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MembroAssegurado>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            FieldAsync<ListGraphType<PapelDescontoType>>("papelDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelDesconto>(x => x.Where(e => e.HasValue(c.Source.IdDesconto)))));
            
        }
    }

    public class DescontoInputType : InputObjectGraphType
	{
		public DescontoInputType()
		{
			// Defining the name of the object
			Name = "descontoInput";
			
            //Field<StringGraphType>("idDesconto");
			Field<FloatGraphType>("taxa");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoDescontoId");
			Field<StringGraphType>("codDesconto");
			Field<FloatGraphType>("valorMinPremioSimples");
			Field<FloatGraphType>("valorMaxPremioSimples");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("valorMinDesconto");
			Field<FloatGraphType>("valorMaxDesconto");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("tipoTarifaId");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("tipoPagamentoId");
			Field<StringGraphType>("localAplicacaoId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("nota");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("produtorId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<PessoaInputType>("produtor");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<ListGraphType<CanalDescontoInputType>>("canalDesconto");
			Field<ListGraphType<DescontoApoliceGrupoInputType>>("descontoApoliceGrupo");
			Field<ListGraphType<DescontoLinhaInputType>>("descontoLinha");
			Field<ListGraphType<DescontoPessoaInputType>>("descontoPessoa");
			Field<ListGraphType<DescontoPlanoInputType>>("descontoPlano");
			Field<ListGraphType<DescontoSeleccionadoInputType>>("descontoSeleccionado");
			Field<ListGraphType<DescontoTipoContaInputType>>("descontoTipoConta");
			Field<ListGraphType<FormaContratacaoInputType>>("formaContratacao");
			Field<ListGraphType<LocaisDescontoInputType>>("locaisDesconto");
			Field<ListGraphType<MembroAsseguradoInputType>>("membroAssegurado");
			Field<ListGraphType<PapelDescontoInputType>>("papelDesconto");
			
		}
	}
}