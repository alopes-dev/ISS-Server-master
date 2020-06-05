using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LinhaProdutoImpostoType : ObjectGraphType<LinhaProdutoImposto>
    {
        public LinhaProdutoImpostoType()
        {
            // Defining the name of the object
            Name = "linhaProdutoImposto";

            Field(x => x.IdLinhaImposto, nullable: true);
            Field(x => x.LinhaProdutoImposto1, nullable: true);
            Field(x => x.ImpostoId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PrecarioProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ImpostoType>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(c.Source.ImpostoId)));
            FieldAsync<LinhaProdutoType>("linhaProdutoImposto1Navigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoImposto1)));
            FieldAsync<PrecarioProdutoType>("precarioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecarioProduto>(c.Source.PrecarioProdutoId)));
            
        }
    }

    public class LinhaProdutoImpostoInputType : InputObjectGraphType
	{
		public LinhaProdutoImpostoInputType()
		{
			// Defining the name of the object
			Name = "linhaProdutoImpostoInput";
			
            //Field<StringGraphType>("idLinhaImposto");
			Field<StringGraphType>("linhaProdutoImposto1");
			Field<StringGraphType>("impostoId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("precarioProdutoId");
			Field<EstadoInputType>("estado");
			Field<ImpostoInputType>("imposto");
			Field<LinhaProdutoInputType>("linhaProdutoImposto1Navigation");
			Field<PrecarioProdutoInputType>("precarioProduto");
			
		}
	}
}