using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DespesaLinhaType : ObjectGraphType<DespesaLinha>
    {
        public DespesaLinhaType()
        {
            // Defining the name of the object
            Name = "despesaLinha";

            Field(x => x.IdDespesaLinha, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodDespesaLinha, nullable: true);
            Field(x => x.DespesaId, nullable: true);
            FieldAsync<DespesaType>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(c.Source.DespesaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class DespesaLinhaInputType : InputObjectGraphType
	{
		public DespesaLinhaInputType()
		{
			// Defining the name of the object
			Name = "despesaLinhaInput";
			
            //Field<StringGraphType>("idDespesaLinha");
			Field<StringGraphType>("linhaProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codDespesaLinha");
			Field<StringGraphType>("despesaId");
			Field<DespesaInputType>("despesa");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}