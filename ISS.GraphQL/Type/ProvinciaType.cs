using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProvinciaType : ObjectGraphType<Provincia>
    {
        public ProvinciaType()
        {
            // Defining the name of the object
            Name = "provincia";

            Field(x => x.IdProvincia, nullable: true);
            Field(x => x.NomeProvincia, nullable: true);
            Field(x => x.RegiaoId, nullable: true);
            Field(x => x.PaisId, nullable: true);
            Field(x => x.CodProvincia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PaisType>("pais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisId)));
            FieldAsync<RegiaoType>("regiao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Regiao>(c.Source.RegiaoId)));
            FieldAsync<ListGraphType<CidadeType>>("cidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cidade>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<LocaisCoberturaType>>("locaisCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisCobertura>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<LocaisDescontoType>>("locaisDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisDesconto>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<LocaisEncargoType>>("locaisEncargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisEncargo>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<LocaisFranquiaType>>("locaisFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisFranquia>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<LocaisImpostoType>>("locaisImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisImposto>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<LocaisLimiteCompetenciaType>>("locaisLimiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisLimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<LocaisObjectivosComerciaisType>>("locaisObjectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<LocaisOfertaType>>("locaisOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisOferta>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<MunicipioType>>("municipio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Municipio>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<ProvinciaComissionamentoType>>("provinciaComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciaComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<ProvinciaPlanoType>>("provinciaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciaPlano>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<ProvinciasLimitesComissionamentoProdutorType>>("provinciasLimitesComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciasLimitesComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<ViagemType>>("viagemProvinciaDestino", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Viagem>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            FieldAsync<ListGraphType<ViagemType>>("viagemProvinciaOrigem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Viagem>(x => x.Where(e => e.HasValue(c.Source.IdProvincia)))));
            
        }
    }

    public class ProvinciaInputType : InputObjectGraphType
	{
		public ProvinciaInputType()
		{
			// Defining the name of the object
			Name = "provinciaInput";
			
            //Field<StringGraphType>("idProvincia");
			Field<StringGraphType>("nomeProvincia");
			Field<StringGraphType>("regiaoId");
			Field<StringGraphType>("paisId");
			Field<StringGraphType>("codProvincia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<PaisInputType>("pais");
			Field<RegiaoInputType>("regiao");
			Field<ListGraphType<CidadeInputType>>("cidade");
			Field<ListGraphType<LocaisCoberturaInputType>>("locaisCobertura");
			Field<ListGraphType<LocaisDescontoInputType>>("locaisDesconto");
			Field<ListGraphType<LocaisEncargoInputType>>("locaisEncargo");
			Field<ListGraphType<LocaisFranquiaInputType>>("locaisFranquia");
			Field<ListGraphType<LocaisImpostoInputType>>("locaisImposto");
			Field<ListGraphType<LocaisLimiteCompetenciaInputType>>("locaisLimiteCompetencia");
			Field<ListGraphType<LocaisObjectivosComerciaisInputType>>("locaisObjectivosComerciais");
			Field<ListGraphType<LocaisOfertaInputType>>("locaisOferta");
			Field<ListGraphType<MunicipioInputType>>("municipio");
			Field<ListGraphType<ProvinciaComissionamentoInputType>>("provinciaComissionamento");
			Field<ListGraphType<ProvinciaPlanoInputType>>("provinciaPlano");
			Field<ListGraphType<ProvinciasLimitesComissionamentoProdutorInputType>>("provinciasLimitesComissionamentoProdutor");
			Field<ListGraphType<ViagemInputType>>("viagemProvinciaDestino");
			Field<ListGraphType<ViagemInputType>>("viagemProvinciaOrigem");
			
		}
	}
}