using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoObjectivoProdutoType : ObjectGraphType<TipoObjectivoProduto>
    {
        public TipoObjectivoProdutoType()
        {
            // Defining the name of the object
            Name = "tipoObjectivoProduto";

            Field(x => x.IdTipoObjectivoProduto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoObjectivoProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ObjectivoProdutoType>>("objectivoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectivoProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipoObjectivoProduto)))));
            
        }
    }

    public class TipoObjectivoProdutoInputType : InputObjectGraphType
	{
		public TipoObjectivoProdutoInputType()
		{
			// Defining the name of the object
			Name = "tipoObjectivoProdutoInput";
			
            //Field<StringGraphType>("idTipoObjectivoProduto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoObjectivoProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ObjectivoProdutoInputType>>("objectivoProduto");
			
		}
	}
}