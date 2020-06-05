using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormaPagamentoPlanoType : ObjectGraphType<FormaPagamentoPlano>
    {
        public FormaPagamentoPlanoType()
        {
            // Defining the name of the object
            Name = "formaPagamentoPlano";

            Field(x => x.IdFormaPagamentoPlano, nullable: true);
            Field(x => x.FormaPagamentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<ComissionamentoPlanoType>>("comissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamentoPlano)))));
            FieldAsync<ListGraphType<CriterioPlanoType>>("criterioPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CriterioPlano>(x => x.Where(e => e.HasValue(c.Source.IdFormaPagamentoPlano)))));
            
        }
    }

    public class FormaPagamentoPlanoInputType : InputObjectGraphType
	{
		public FormaPagamentoPlanoInputType()
		{
			// Defining the name of the object
			Name = "formaPagamentoPlanoInput";
			
            //Field<StringGraphType>("idFormaPagamentoPlano");
			Field<StringGraphType>("formaPagamentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("planoProdutoId");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoInputType>("formaPagamento");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<ComissionamentoPlanoInputType>>("comissionamentoPlano");
			Field<ListGraphType<CriterioPlanoInputType>>("criterioPlano");
			
		}
	}
}