using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSegmentoType : ObjectGraphType<TipoSegmento>
    {
        public TipoSegmentoType()
        {
            // Defining the name of the object
            Name = "tipoSegmento";

            Field(x => x.IdTipoSegmento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoSegmento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TaxaAgravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumRegistos, nullable: true, type: typeof(IntGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.TipoPessoaId, nullable: true);
            Field(x => x.DimensaoEmpresaId, nullable: true);
            FieldAsync<DimensaoEmpresaType>("dimensaoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DimensaoEmpresa>(c.Source.DimensaoEmpresaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoPessoaType>("tipoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPessoa>(c.Source.TipoPessoaId)));
            FieldAsync<ListGraphType<ContratoSegmentosType>>("contratoSegmentos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoSegmentos>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<LimiteCompetenciaType>>("limiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<PapelType>>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<PapelPessoaType>>("papelPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPessoa>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<SectorActividadesProdutorType>>("sectorActividadesProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadesProdutor>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<SegmentoComissionamentoProdutorType>>("segmentoComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<SegmentoFranquiaType>>("segmentoFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoFranquia>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<SegmentoObjectivosComerciaisType>>("segmentoObjectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<SegmentoProdutoType>>("segmentoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<SegmentoTipoCoberturaType>>("segmentoTipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoTipoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<TipoSegmentoComissionamentoType>>("tipoSegmentoComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<TipoSegmentoContratoType>>("tipoSegmentoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoContrato>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<TipoSegmentoPlanoType>>("tipoSegmentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            FieldAsync<ListGraphType<TipoSegmentosComissionamentoType>>("tipoSegmentosComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentosComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmento)))));
            
        }
    }

    public class TipoSegmentoInputType : InputObjectGraphType
	{
		public TipoSegmentoInputType()
		{
			// Defining the name of the object
			Name = "tipoSegmentoInput";
			
            //Field<StringGraphType>("idTipoSegmento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoSegmento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("taxaAgravamento");
			Field<IntGraphType>("numRegistos");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("tipoPessoaId");
			Field<StringGraphType>("dimensaoEmpresaId");
			Field<DimensaoEmpresaInputType>("dimensaoEmpresa");
			Field<EstadoInputType>("estado");
			Field<TipoPessoaInputType>("tipoPessoa");
			Field<ListGraphType<ContratoSegmentosInputType>>("contratoSegmentos");
			Field<ListGraphType<LimiteCompetenciaInputType>>("limiteCompetencia");
			Field<ListGraphType<PapelInputType>>("papel");
			Field<ListGraphType<PapelPessoaInputType>>("papelPessoa");
			Field<ListGraphType<SectorActividadesProdutorInputType>>("sectorActividadesProdutor");
			Field<ListGraphType<SegmentoComissionamentoProdutorInputType>>("segmentoComissionamentoProdutor");
			Field<ListGraphType<SegmentoFranquiaInputType>>("segmentoFranquia");
			Field<ListGraphType<SegmentoObjectivosComerciaisInputType>>("segmentoObjectivosComerciais");
			Field<ListGraphType<SegmentoProdutoInputType>>("segmentoProduto");
			Field<ListGraphType<SegmentoTipoCoberturaInputType>>("segmentoTipoCobertura");
			Field<ListGraphType<TipoSegmentoComissionamentoInputType>>("tipoSegmentoComissionamento");
			Field<ListGraphType<TipoSegmentoContratoInputType>>("tipoSegmentoContrato");
			Field<ListGraphType<TipoSegmentoPlanoInputType>>("tipoSegmentoPlano");
			Field<ListGraphType<TipoSegmentosComissionamentoInputType>>("tipoSegmentosComissionamento");
			
		}
	}
}