using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimiteCompetenciaType : ObjectGraphType<LimiteCompetencia>
    {
        public LimiteCompetenciaType()
        {
            // Defining the name of the object
            Name = "limiteCompetencia";

            Field(x => x.IdLimiteCompetencia, nullable: true);
            Field(x => x.TaxaMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NivelAcessoId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.FuncaoId, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoSegmentoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodLimiteCompetencia, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncaoType>("funcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(c.Source.FuncaoId)));
            FieldAsync<NivelAcessoType>("nivelAcesso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelAcesso>(c.Source.NivelAcessoId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<OperacoesPagamentoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesPagamento>(c.Source.TipoOperacaoId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            FieldAsync<ListGraphType<LocaisLimiteCompetenciaType>>("locaisLimiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisLimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdLimiteCompetencia)))));
            FieldAsync<ListGraphType<TipoOperacaoProcessoLimiteCompetenciaType>>("tipoOperacaoProcessoLimiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacaoProcessoLimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdLimiteCompetencia)))));
            
        }
    }

    public class LimiteCompetenciaInputType : InputObjectGraphType
	{
		public LimiteCompetenciaInputType()
		{
			// Defining the name of the object
			Name = "limiteCompetenciaInput";
			
            //Field<StringGraphType>("idLimiteCompetencia");
			Field<FloatGraphType>("taxaMin");
			Field<FloatGraphType>("taxaMax");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<StringGraphType>("nivelAcessoId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<StringGraphType>("funcaoId");
			Field<StringGraphType>("produtorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("tipoSegmentoId");
			Field<StringGraphType>("canalId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codLimiteCompetencia");
			Field<CanalInputType>("canal");
			Field<EstadoInputType>("estado");
			Field<FuncaoInputType>("funcao");
			Field<NivelAcessoInputType>("nivelAcesso");
			Field<PessoaInputType>("produtor");
			Field<OperacoesPagamentoInputType>("tipoOperacao");
			Field<TipoSegmentoInputType>("tipoSegmento");
			Field<ListGraphType<LocaisLimiteCompetenciaInputType>>("locaisLimiteCompetencia");
			Field<ListGraphType<TipoOperacaoProcessoLimiteCompetenciaInputType>>("tipoOperacaoProcessoLimiteCompetencia");
			
		}
	}
}