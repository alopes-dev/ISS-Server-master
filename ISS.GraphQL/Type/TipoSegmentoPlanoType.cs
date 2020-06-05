using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSegmentoPlanoType : ObjectGraphType<TipoSegmentoPlano>
    {
        public TipoSegmentoPlanoType()
        {
            // Defining the name of the object
            Name = "tipoSegmentoPlano";

            Field(x => x.IdTipoSegmentoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodTipoSegmentoPlano, nullable: true);
            Field(x => x.TipoSegmentoId, nullable: true);
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            FieldAsync<ListGraphType<ComissionamentoPlanoType>>("comissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmentoPlano)))));
            FieldAsync<ListGraphType<CriterioComissionamentoType>>("criterioComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CriterioComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmentoPlano)))));
            FieldAsync<ListGraphType<CriterioPlanoType>>("criterioPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CriterioPlano>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmentoPlano)))));
            FieldAsync<ListGraphType<LimiteComissionamentoPlanoType>>("limiteComissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmentoPlano)))));
            FieldAsync<ListGraphType<LimiteComissionamentoProdutorType>>("limiteComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdTipoSegmentoPlano)))));
            
        }
    }

    public class TipoSegmentoPlanoInputType : InputObjectGraphType
	{
		public TipoSegmentoPlanoInputType()
		{
			// Defining the name of the object
			Name = "tipoSegmentoPlanoInput";
			
            //Field<StringGraphType>("idTipoSegmentoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codTipoSegmentoPlano");
			Field<StringGraphType>("tipoSegmentoId");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoSegmentoInputType>("tipoSegmento");
			Field<ListGraphType<ComissionamentoPlanoInputType>>("comissionamentoPlano");
			Field<ListGraphType<CriterioComissionamentoInputType>>("criterioComissionamento");
			Field<ListGraphType<CriterioPlanoInputType>>("criterioPlano");
			Field<ListGraphType<LimiteComissionamentoPlanoInputType>>("limiteComissionamentoPlano");
			Field<ListGraphType<LimiteComissionamentoProdutorInputType>>("limiteComissionamentoProdutor");
			
		}
	}
}