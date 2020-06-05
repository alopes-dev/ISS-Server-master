using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoLinhaType : ObjectGraphType<DescontoLinha>
    {
        public DescontoLinhaType()
        {
            // Defining the name of the object
            Name = "descontoLinha";

            Field(x => x.IdDescontoLinha, nullable: true);
            Field(x => x.CodDescontoLinha, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class DescontoLinhaInputType : InputObjectGraphType
	{
		public DescontoLinhaInputType()
		{
			// Defining the name of the object
			Name = "descontoLinhaInput";
			
            //Field<StringGraphType>("idDescontoLinha");
			Field<StringGraphType>("codDescontoLinha");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("descontoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DescontoInputType>("desconto");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}