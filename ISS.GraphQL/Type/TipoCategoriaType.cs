using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCategoriaType : ObjectGraphType<TipoCategoria>
    {
        public TipoCategoriaType()
        {
            // Defining the name of the object
            Name = "tipoCategoria";

            Field(x => x.IdTipoCategoria, nullable: true);
            Field(x => x.CodTipoCategoria, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CategoriaType>>("categoria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Categoria>(x => x.Where(e => e.HasValue(c.Source.IdTipoCategoria)))));
            
        }
    }

    public class TipoCategoriaInputType : InputObjectGraphType
	{
		public TipoCategoriaInputType()
		{
			// Defining the name of the object
			Name = "tipoCategoriaInput";
			
            //Field<StringGraphType>("idTipoCategoria");
			Field<StringGraphType>("codTipoCategoria");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CategoriaInputType>>("categoria");
			
		}
	}
}