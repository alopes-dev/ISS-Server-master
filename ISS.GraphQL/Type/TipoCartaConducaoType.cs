using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCartaConducaoType : ObjectGraphType<TipoCartaConducao>
    {
        public TipoCartaConducaoType()
        {
            // Defining the name of the object
            Name = "tipoCartaConducao";

            Field(x => x.IdTipo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoCartaConducao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CartaConducaoType>>("cartaConducao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CartaConducao>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            
        }
    }

    public class TipoCartaConducaoInputType : InputObjectGraphType
	{
		public TipoCartaConducaoInputType()
		{
			// Defining the name of the object
			Name = "tipoCartaConducaoInput";
			
            //Field<StringGraphType>("idTipo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoCartaConducao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CartaConducaoInputType>>("cartaConducao");
			
		}
	}
}