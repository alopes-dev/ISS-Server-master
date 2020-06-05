using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoImagemProdutoType : ObjectGraphType<TipoImagemProduto>
    {
        public TipoImagemProdutoType()
        {
            // Defining the name of the object
            Name = "tipoImagemProduto";

            Field(x => x.IdTipo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoImagemProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ImagemProdutoType>>("imagemProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImagemProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            
        }
    }

    public class TipoImagemProdutoInputType : InputObjectGraphType
	{
		public TipoImagemProdutoInputType()
		{
			// Defining the name of the object
			Name = "tipoImagemProdutoInput";
			
            //Field<StringGraphType>("idTipo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoImagemProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ImagemProdutoInputType>>("imagemProduto");
			
		}
	}
}