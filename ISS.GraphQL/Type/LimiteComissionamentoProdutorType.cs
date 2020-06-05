using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimiteComissionamentoProdutorType : ObjectGraphType<LimiteComissionamentoProdutor>
    {
        public LimiteComissionamentoProdutorType()
        {
            // Defining the name of the object
            Name = "limiteComissionamentoProdutor";

            Field(x => x.IdLimiteComissionamentoProdutor, nullable: true);
            Field(x => x.ProvinciaProdutorId, nullable: true);
            Field(x => x.ComissionamentoProdutorId, nullable: true);
            Field(x => x.FidelizacaoProdutorId, nullable: true);
            Field(x => x.PremioMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoSegmentoProdutorId, nullable: true);
            Field(x => x.SectorActividadeProdutorId, nullable: true);
            Field(x => x.TaxaPercentagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TaxaAtribuir, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaPlano, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.DescontoMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescontoMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ProdutorId, nullable: true);
            FieldAsync<ComissionamentoPlanoType>("comissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissionamentoPlano>(c.Source.ComissionamentoProdutorId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<FidelizacaoPlanoType>("fidelizacaoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FidelizacaoPlano>(c.Source.FidelizacaoProdutorId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<ProvinciaPlanoType>("provinciaProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciaPlano>(c.Source.ProvinciaProdutorId)));
            FieldAsync<SectorActividadePlanoType>("sectorActividadeProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadePlano>(c.Source.SectorActividadeProdutorId)));
            FieldAsync<TipoSegmentoPlanoType>("tipoSegmentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoPlano>(c.Source.TipoSegmentoProdutorId)));
            FieldAsync<ListGraphType<PlanoLimiteComissionamentoProdutorType>>("planoLimiteComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoLimiteComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdLimiteComissionamentoProdutor)))));
            FieldAsync<ListGraphType<ProvinciasLimitesComissionamentoProdutorType>>("provinciasLimitesComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciasLimitesComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdLimiteComissionamentoProdutor)))));
            FieldAsync<ListGraphType<SectorActividadeComissionamentoType>>("sectorActividadeComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadeComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdLimiteComissionamentoProdutor)))));
            
        }
    }

    public class LimiteComissionamentoProdutorInputType : InputObjectGraphType
	{
		public LimiteComissionamentoProdutorInputType()
		{
			// Defining the name of the object
			Name = "limiteComissionamentoProdutorInput";
			
            //Field<StringGraphType>("idLimiteComissionamentoProdutor");
			Field<StringGraphType>("provinciaProdutorId");
			Field<StringGraphType>("comissionamentoProdutorId");
			Field<StringGraphType>("fidelizacaoProdutorId");
			Field<FloatGraphType>("premioMin");
			Field<FloatGraphType>("premioMax");
			Field<StringGraphType>("tipoSegmentoProdutorId");
			Field<StringGraphType>("sectorActividadeProdutorId");
			Field<FloatGraphType>("taxaPercentagem");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("taxaAtribuir");
			Field<FloatGraphType>("taxaPlano");
			Field<StringGraphType>("contratoId");
			Field<FloatGraphType>("descontoMin");
			Field<FloatGraphType>("descontoMax");
			Field<StringGraphType>("produtorId");
			Field<ComissionamentoPlanoInputType>("comissionamentoProdutor");
			Field<ContratoInputType>("contrato");
			Field<FidelizacaoPlanoInputType>("fidelizacaoProdutor");
			Field<PessoaInputType>("produtor");
			Field<ProvinciaPlanoInputType>("provinciaProdutor");
			Field<SectorActividadePlanoInputType>("sectorActividadeProdutor");
			Field<TipoSegmentoPlanoInputType>("tipoSegmentoProdutor");
			Field<ListGraphType<PlanoLimiteComissionamentoProdutorInputType>>("planoLimiteComissionamentoProdutor");
			Field<ListGraphType<ProvinciasLimitesComissionamentoProdutorInputType>>("provinciasLimitesComissionamentoProdutor");
			Field<ListGraphType<SectorActividadeComissionamentoInputType>>("sectorActividadeComissionamento");
			
		}
	}
}