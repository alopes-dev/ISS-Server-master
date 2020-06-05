using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PeriodoPlanoPlanoType : ObjectGraphType<PeriodoPlanoPlano>
    {
        public PeriodoPlanoPlanoType()
        {
            // Defining the name of the object
            Name = "periodoPlanoPlano";

            Field(x => x.IdPeriodoPlanoPlano, nullable: true);
            Field(x => x.PeriodoPlanoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodPeriodoPlanoPlano, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PeriodoPlanoType>("periodoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoPlano>(c.Source.PeriodoPlanoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class PeriodoPlanoPlanoInputType : InputObjectGraphType
	{
		public PeriodoPlanoPlanoInputType()
		{
			// Defining the name of the object
			Name = "periodoPlanoPlanoInput";
			
            //Field<StringGraphType>("idPeriodoPlanoPlano");
			Field<StringGraphType>("periodoPlanoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codPeriodoPlanoPlano");
			Field<EstadoInputType>("estado");
			Field<PeriodoPlanoInputType>("periodoPlano");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}