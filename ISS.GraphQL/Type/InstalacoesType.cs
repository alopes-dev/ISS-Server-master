using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class InstalacoesType : ObjectGraphType<Instalacoes>
    {
        public InstalacoesType()
        {
            // Defining the name of the object
            Name = "instalacoes";

            Field(x => x.IdInstalacao, nullable: true);
            Field(x => x.NumFuncionarios, nullable: true, type: typeof(IntGraphType));
            Field(x => x.VolumeAnualSalario, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FacturacaoAnual, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescricaoProcessoFabrico, nullable: true);
            Field(x => x.OrigemFabricoEmbalagemId, nullable: true);
            Field(x => x.TipoEmbalagemId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.QualidadeProponenteId, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.DescricaoActividade, nullable: true);
            Field(x => x.TempoRamoActividade, nullable: true, type: typeof(IntGraphType));
            Field(x => x.UnidadeTempoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<OrigemFabricoEmbalagemType>("origemFabricoEmbalagem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OrigemFabricoEmbalagem>(c.Source.OrigemFabricoEmbalagemId)));
            FieldAsync<QualidadeProponenteType>("qualidadeProponente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<QualidadeProponente>(c.Source.QualidadeProponenteId)));
            FieldAsync<TipoEmbalagemType>("tipoEmbalagem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEmbalagem>(c.Source.TipoEmbalagemId)));
            FieldAsync<UnidadesTempoType>("unidadeTempo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<UnidadesTempo>(c.Source.UnidadeTempoId)));
            FieldAsync<ListGraphType<FuncionarioInstalacoesType>>("funcionarioInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FuncionarioInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdInstalacao)))));
            FieldAsync<ListGraphType<LocalizacaoInstalacoesType>>("localizacaoInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalizacaoInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdInstalacao)))));
            FieldAsync<ListGraphType<ModalidadesRcselecionadasType>>("modalidadesRcselecionadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesRcselecionadas>(x => x.Where(e => e.HasValue(c.Source.IdInstalacao)))));
            FieldAsync<ListGraphType<ProdutosInstalacoesType>>("produtosInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProdutosInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdInstalacao)))));
            
        }
    }

    public class InstalacoesInputType : InputObjectGraphType
	{
		public InstalacoesInputType()
		{
			// Defining the name of the object
			Name = "instalacoesInput";
			
            //Field<StringGraphType>("idInstalacao");
			Field<IntGraphType>("numFuncionarios");
			Field<FloatGraphType>("volumeAnualSalario");
			Field<FloatGraphType>("facturacaoAnual");
			Field<StringGraphType>("descricaoProcessoFabrico");
			Field<StringGraphType>("origemFabricoEmbalagemId");
			Field<StringGraphType>("tipoEmbalagemId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("qualidadeProponenteId");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("descricaoActividade");
			Field<IntGraphType>("tempoRamoActividade");
			Field<StringGraphType>("unidadeTempoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<ApoliceInputType>("apolice");
			Field<CotacaoInputType>("cotacao");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<OrigemFabricoEmbalagemInputType>("origemFabricoEmbalagem");
			Field<QualidadeProponenteInputType>("qualidadeProponente");
			Field<TipoEmbalagemInputType>("tipoEmbalagem");
			Field<UnidadesTempoInputType>("unidadeTempo");
			Field<ListGraphType<FuncionarioInstalacoesInputType>>("funcionarioInstalacoes");
			Field<ListGraphType<LocalizacaoInstalacoesInputType>>("localizacaoInstalacoes");
			Field<ListGraphType<ModalidadesRcselecionadasInputType>>("modalidadesRcselecionadas");
			Field<ListGraphType<ProdutosInstalacoesInputType>>("produtosInstalacoes");
			
		}
	}
}