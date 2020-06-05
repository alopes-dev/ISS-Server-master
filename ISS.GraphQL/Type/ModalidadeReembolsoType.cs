using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModalidadeReembolsoType : ObjectGraphType<ModalidadeReembolso>
    {
        public ModalidadeReembolsoType()
        {
            // Defining the name of the object
            Name = "modalidadeReembolso";

            Field(x => x.IdModalidadeReembolso, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodModalidadeReembolso, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IdFormaPagamento, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoType>("idFormaPagamentoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.IdFormaPagamento)));
            FieldAsync<ListGraphType<PlanoProdutoType>>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeReembolso)))));
            
        }
    }

    public class ModalidadeReembolsoInputType : InputObjectGraphType
	{
		public ModalidadeReembolsoInputType()
		{
			// Defining the name of the object
			Name = "modalidadeReembolsoInput";
			
            //Field<StringGraphType>("idModalidadeReembolso");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codModalidadeReembolso");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("idFormaPagamento");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoInputType>("idFormaPagamentoNavigation");
			Field<ListGraphType<PlanoProdutoInputType>>("planoProduto");
			
		}
	}
}