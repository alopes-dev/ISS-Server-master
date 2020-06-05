using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExclusoesSelecionadaLinhaProdutoType : ObjectGraphType<ExclusoesSelecionadaLinhaProduto>
    {
        public ExclusoesSelecionadaLinhaProdutoType()
        {
            // Defining the name of the object
            Name = "exclusoesSelecionadaLinhaProduto";

            Field(x => x.IdExclusoesSelecionadaLinhaProduto, nullable: true);
            Field(x => x.CodExclusoesSelecionadaLinhaProduto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.ExclusoesId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ExclusoesType>("exclusoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exclusoes>(c.Source.ExclusoesId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class ExclusoesSelecionadaLinhaProdutoInputType : InputObjectGraphType
	{
		public ExclusoesSelecionadaLinhaProdutoInputType()
		{
			// Defining the name of the object
			Name = "exclusoesSelecionadaLinhaProdutoInput";
			
            //Field<StringGraphType>("idExclusoesSelecionadaLinhaProduto");
			Field<StringGraphType>("codExclusoesSelecionadaLinhaProduto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("exclusoesId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ExclusoesInputType>("exclusoes");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}