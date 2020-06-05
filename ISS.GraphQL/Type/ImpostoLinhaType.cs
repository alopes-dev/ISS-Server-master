using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ImpostoLinhaType : ObjectGraphType<ImpostoLinha>
    {
        public ImpostoLinhaType()
        {
            // Defining the name of the object
            Name = "impostoLinha";

            Field(x => x.IdImpostoLinha, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ImpostoId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ImpostoType>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(c.Source.ImpostoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class ImpostoLinhaInputType : InputObjectGraphType
	{
		public ImpostoLinhaInputType()
		{
			// Defining the name of the object
			Name = "impostoLinhaInput";
			
            //Field<StringGraphType>("idImpostoLinha");
			Field<StringGraphType>("linhaProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("impostoId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ImpostoInputType>("imposto");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}