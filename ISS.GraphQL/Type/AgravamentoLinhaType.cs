using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgravamentoLinhaType : ObjectGraphType<AgravamentoLinha>
    {
        public AgravamentoLinhaType()
        {
            // Defining the name of the object
            Name = "agravamentoLinha";

            Field(x => x.IdAgravamentoLinha, nullable: true);
            Field(x => x.AgravamentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodAgravamentoLina, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            FieldAsync<AgravamentoType>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(c.Source.AgravamentoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class AgravamentoLinhaInputType : InputObjectGraphType
	{
		public AgravamentoLinhaInputType()
		{
			// Defining the name of the object
			Name = "agravamentoLinhaInput";
			
            //Field<StringGraphType>("idAgravamentoLinha");
			Field<StringGraphType>("agravamentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codAgravamentoLina");
			Field<StringGraphType>("linhaProdutoId");
			Field<AgravamentoInputType>("agravamento");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}