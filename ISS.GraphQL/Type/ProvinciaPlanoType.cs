using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProvinciaPlanoType : ObjectGraphType<ProvinciaPlano>
    {
        public ProvinciaPlanoType()
        {
            // Defining the name of the object
            Name = "provinciaPlano";

            Field(x => x.IdProvinciaPlano, nullable: true);
            Field(x => x.ProvinciaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodProvinciaPlano, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ComissionamentoId, nullable: true);
            Field(x => x.TaxaAgravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NivelRiscoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ProvinciaType>("provincia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(c.Source.ProvinciaId)));
            FieldAsync<ListGraphType<CriterioPlanoType>>("criterioPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CriterioPlano>(x => x.Where(e => e.HasValue(c.Source.IdProvinciaPlano)))));
            FieldAsync<ListGraphType<LimiteComissionamentoPlanoType>>("limiteComissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdProvinciaPlano)))));
            FieldAsync<ListGraphType<LimiteComissionamentoProdutorType>>("limiteComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdProvinciaPlano)))));
            
        }
    }

    public class ProvinciaPlanoInputType : InputObjectGraphType
	{
		public ProvinciaPlanoInputType()
		{
			// Defining the name of the object
			Name = "provinciaPlanoInput";
			
            //Field<StringGraphType>("idProvinciaPlano");
			Field<StringGraphType>("provinciaId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codProvinciaPlano");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("comissionamentoId");
			Field<FloatGraphType>("taxaAgravamento");
			Field<StringGraphType>("nivelRiscoId");
			Field<EstadoInputType>("estado");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ProvinciaInputType>("provincia");
			Field<ListGraphType<CriterioPlanoInputType>>("criterioPlano");
			Field<ListGraphType<LimiteComissionamentoPlanoInputType>>("limiteComissionamentoPlano");
			Field<ListGraphType<LimiteComissionamentoProdutorInputType>>("limiteComissionamentoProdutor");
			
		}
	}
}