using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoEmbalagemType : ObjectGraphType<TipoEmbalagem>
    {
        public TipoEmbalagemType()
        {
            // Defining the name of the object
            Name = "tipoEmbalagem";

            Field(x => x.IdTipoEmbalagem, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoEmbalagem, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<InstalacoesType>>("instalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Instalacoes>(x => x.Where(e => e.HasValue(c.Source.IdTipoEmbalagem)))));
            
        }
    }

    public class TipoEmbalagemInputType : InputObjectGraphType
	{
		public TipoEmbalagemInputType()
		{
			// Defining the name of the object
			Name = "tipoEmbalagemInput";
			
            //Field<StringGraphType>("idTipoEmbalagem");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoEmbalagem");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<InstalacoesInputType>>("instalacoes");
			
		}
	}
}