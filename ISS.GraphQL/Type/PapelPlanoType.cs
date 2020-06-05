using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PapelPlanoType : ObjectGraphType<PapelPlano>
    {
        public PapelPlanoType()
        {
            // Defining the name of the object
            Name = "papelPlano";

            Field(x => x.IdPapelPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PapelId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<ComissionamentoPlanoType>>("comissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdPapelPlano)))));
            FieldAsync<ListGraphType<CriterioPlanoType>>("criterioPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CriterioPlano>(x => x.Where(e => e.HasValue(c.Source.IdPapelPlano)))));
            
        }
    }

    public class PapelPlanoInputType : InputObjectGraphType
	{
		public PapelPlanoInputType()
		{
			// Defining the name of the object
			Name = "papelPlanoInput";
			
            //Field<StringGraphType>("idPapelPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("papelId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PapelInputType>("papel");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<ComissionamentoPlanoInputType>>("comissionamentoPlano");
			Field<ListGraphType<CriterioPlanoInputType>>("criterioPlano");
			
		}
	}
}