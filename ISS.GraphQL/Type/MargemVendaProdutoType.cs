using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MargemVendaProdutoType : ObjectGraphType<MargemVendaProduto>
    {
        public MargemVendaProdutoType()
        {
            // Defining the name of the object
            Name = "margemVendaProduto";

            Field(x => x.IdMargemVendaProduto, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMinPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Descricao, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoMargemId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.TipoRecebimentoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.LocalAplicacaoId, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            Field(x => x.CodMargemVendaProduto, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<CentroCustoType>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(c.Source.CentroCustoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LocalAplicacaoPlanoType>("localAplicacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalAplicacaoPlano>(c.Source.LocalAplicacaoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<TipoMargemType>("tipoMargem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoMargem>(c.Source.TipoMargemId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<TipoRecebimentoType>("tipoRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimento>(c.Source.TipoRecebimentoId)));
            FieldAsync<ListGraphType<MargemVendaSeleccionadoType>>("margemVendaSeleccionado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MargemVendaSeleccionado>(x => x.Where(e => e.HasValue(c.Source.IdMargemVendaProduto)))));
            
        }
    }

    public class MargemVendaProdutoInputType : InputObjectGraphType
	{
		public MargemVendaProdutoInputType()
		{
			// Defining the name of the object
			Name = "margemVendaProdutoInput";
			
            //Field<StringGraphType>("idMargemVendaProduto");
			Field<FloatGraphType>("taxa");
			Field<FloatGraphType>("valorMinPremioSimples");
			Field<FloatGraphType>("valorMaxPremioSimples");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("tipoMargemId");
			Field<BooleanGraphType>("isTaxa");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("tipoRecebimentoId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("localAplicacaoId");
			Field<StringGraphType>("produtorId");
			Field<StringGraphType>("codMargemVendaProduto");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<CanalInputType>("canal");
			Field<CentroCustoInputType>("centroCusto");
			Field<EstadoInputType>("estado");
			Field<LocalAplicacaoPlanoInputType>("localAplicacao");
			Field<MoedaInputType>("moeda");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<PessoaInputType>("produtor");
			Field<TipoMargemInputType>("tipoMargem");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<TipoRecebimentoInputType>("tipoRecebimento");
			Field<ListGraphType<MargemVendaSeleccionadoInputType>>("margemVendaSeleccionado");
			
		}
	}
}