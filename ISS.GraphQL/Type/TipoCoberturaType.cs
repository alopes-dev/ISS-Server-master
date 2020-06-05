using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCoberturaType : ObjectGraphType<TipoCobertura>
    {
        public TipoCoberturaType()
        {
            // Defining the name of the object
            Name = "tipoCobertura";

            Field(x => x.IdTipo, nullable: true);
            Field(x => x.NomeCobertura, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.CodTipoCobertura, nullable: true);
            Field(x => x.DiasPeriodoCarencia, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Obs, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<ListGraphType<AgravamentoLimiteComparticipacaoType>>("agravamentoLimiteComparticipacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoLimiteComparticipacao>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<CoberturaType>>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<CoeficientePremioAdesaoType>>("coeficientePremioAdesao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoeficientePremioAdesao>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<CoeficientePremioDoencasPreExistentesType>>("coeficientePremioDoencasPreExistentes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoeficientePremioDoencasPreExistentes>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<CoeficientePremioLimiteIndemnizacaoType>>("coeficientePremioLimiteIndemnizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoeficientePremioLimiteIndemnizacao>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<CoeficientePremioPessoasType>>("coeficientePremioPessoas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoeficientePremioPessoas>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<DescontoFranquiaType>>("descontoFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoFranquia>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<DocumentosObrigatorioProdutoType>>("documentosObrigatorioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosObrigatorioProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<GarantiasContratadasType>>("garantiasContratadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GarantiasContratadas>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<LimitesAceitacaoType>>("limitesAceitacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimitesAceitacao>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<LocaisCoberturaType>>("locaisCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisCobertura>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<NivelRiscoCoberturaType>>("nivelRiscoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRiscoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<RiscosExcluidosType>>("riscosExcluidos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RiscosExcluidos>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<SegmentoTipoCoberturaType>>("segmentoTipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoTipoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<TermoResponsabilidadeType>>("termoResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TermoResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            
        }
    }

    public class TipoCoberturaInputType : InputObjectGraphType
	{
		public TipoCoberturaInputType()
		{
			// Defining the name of the object
			Name = "tipoCoberturaInput";
			
            //Field<StringGraphType>("idTipo");
			Field<StringGraphType>("nomeCobertura");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("codTipoCobertura");
			Field<IntGraphType>("diasPeriodoCarencia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("obs");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			Field<ListGraphType<AgravamentoLimiteComparticipacaoInputType>>("agravamentoLimiteComparticipacao");
			Field<ListGraphType<CoberturaInputType>>("cobertura");
			Field<ListGraphType<CoeficientePremioAdesaoInputType>>("coeficientePremioAdesao");
			Field<ListGraphType<CoeficientePremioDoencasPreExistentesInputType>>("coeficientePremioDoencasPreExistentes");
			Field<ListGraphType<CoeficientePremioLimiteIndemnizacaoInputType>>("coeficientePremioLimiteIndemnizacao");
			Field<ListGraphType<CoeficientePremioPessoasInputType>>("coeficientePremioPessoas");
			Field<ListGraphType<DescontoFranquiaInputType>>("descontoFranquia");
			Field<ListGraphType<DocumentosObrigatorioProdutoInputType>>("documentosObrigatorioProduto");
			Field<ListGraphType<GarantiasContratadasInputType>>("garantiasContratadas");
			Field<ListGraphType<LimitesAceitacaoInputType>>("limitesAceitacao");
			Field<ListGraphType<LocaisCoberturaInputType>>("locaisCobertura");
			Field<ListGraphType<NivelRiscoCoberturaInputType>>("nivelRiscoCobertura");
			Field<ListGraphType<RiscosExcluidosInputType>>("riscosExcluidos");
			Field<ListGraphType<SegmentoTipoCoberturaInputType>>("segmentoTipoCobertura");
			Field<ListGraphType<TermoResponsabilidadeInputType>>("termoResponsabilidade");
			
		}
	}
}