using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CanalPlanoType : ObjectGraphType<CanalPlano>
    {
        public CanalPlanoType()
        {
            // Defining the name of the object
            Name = "canalPlano";

            Field(x => x.IdCanalPlano, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodCanalPlano, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<ComissionamentoPlanoType>>("comissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdCanalPlano)))));
            FieldAsync<ListGraphType<CriterioPlanoType>>("criterioPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CriterioPlano>(x => x.Where(e => e.HasValue(c.Source.IdCanalPlano)))));
            FieldAsync<ListGraphType<LimiteComissionamentoPlanoType>>("limiteComissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdCanalPlano)))));
            
        }
    }

    public class CanalPlanoInputType : InputObjectGraphType
	{
		public CanalPlanoInputType()
		{
			// Defining the name of the object
			Name = "canalPlanoInput";
			
            //Field<StringGraphType>("idCanalPlano");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codCanalPlano");
			Field<CanalInputType>("canal");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<ComissionamentoPlanoInputType>>("comissionamentoPlano");
			Field<ListGraphType<CriterioPlanoInputType>>("criterioPlano");
			Field<ListGraphType<LimiteComissionamentoPlanoInputType>>("limiteComissionamentoPlano");
			
		}
	}
}