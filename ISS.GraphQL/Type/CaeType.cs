using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CaeType : ObjectGraphType<Cae>
    {
        public CaeType()
        {
            // Defining the name of the object
            Name = "cae";

            Field(x => x.IdCae, nullable: true);
            Field(x => x.CodCae, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TituloCaeId, nullable: true);
            Field(x => x.TaxaComercial, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NivelRiscoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.AutoridadeSupervisaoId, nullable: true);
            Field(x => x.ClassificacaoModalidadeCaeId, nullable: true);
            FieldAsync<AutoridadeSupervisaoType>("autoridadeSupervisao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AutoridadeSupervisao>(c.Source.AutoridadeSupervisaoId)));
            FieldAsync<ClassificacaoModalidadeCaeType>("classificacaoModalidadeCae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoModalidadeCae>(c.Source.ClassificacaoModalidadeCaeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<SectorAtividadeEconomicaType>("tituloCae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorAtividadeEconomica>(c.Source.TituloCaeId)));
            FieldAsync<ListGraphType<BancoType>>("banco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Banco>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<CaePlanoType>>("caePlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaePlano>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<ContratoCaeType>>("contratoCae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoCae>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<EmpresaType>>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<EntidadeEmpregadoraType>>("entidadeEmpregadora", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EntidadeEmpregadora>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<RendimentosPessoaType>>("rendimentosPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RendimentosPessoa>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<SegmentoFranquiaType>>("segmentoFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoFranquia>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<SegmentoProdutoType>>("segmentoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoProduto>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<SegmentoTipoCoberturaType>>("segmentoTipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoTipoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<SimulacaoType>>("simulacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Simulacao>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            FieldAsync<ListGraphType<SubSectorType>>("subSector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubSector>(x => x.Where(e => e.HasValue(c.Source.IdCae)))));
            
        }
    }

    public class CaeInputType : InputObjectGraphType
	{
		public CaeInputType()
		{
			// Defining the name of the object
			Name = "caeInput";
			
            //Field<StringGraphType>("idCae");
			Field<StringGraphType>("codCae");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("tituloCaeId");
			Field<FloatGraphType>("taxaComercial");
			Field<StringGraphType>("nivelRiscoId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("autoridadeSupervisaoId");
			Field<StringGraphType>("classificacaoModalidadeCaeId");
			Field<AutoridadeSupervisaoInputType>("autoridadeSupervisao");
			Field<ClassificacaoModalidadeCaeInputType>("classificacaoModalidadeCae");
			Field<EstadoInputType>("estado");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<SectorAtividadeEconomicaInputType>("tituloCae");
			Field<ListGraphType<BancoInputType>>("banco");
			Field<ListGraphType<CaePlanoInputType>>("caePlano");
			Field<ListGraphType<ContratoCaeInputType>>("contratoCae");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<EmpresaInputType>>("empresa");
			Field<ListGraphType<EntidadeEmpregadoraInputType>>("entidadeEmpregadora");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			Field<ListGraphType<RendimentosPessoaInputType>>("rendimentosPessoa");
			Field<ListGraphType<SegmentoFranquiaInputType>>("segmentoFranquia");
			Field<ListGraphType<SegmentoProdutoInputType>>("segmentoProduto");
			Field<ListGraphType<SegmentoTipoCoberturaInputType>>("segmentoTipoCobertura");
			Field<ListGraphType<SimulacaoInputType>>("simulacao");
			Field<ListGraphType<SubSectorInputType>>("subSector");
			
		}
	}
}