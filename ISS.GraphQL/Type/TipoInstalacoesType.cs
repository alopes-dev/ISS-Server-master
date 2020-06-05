using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoInstalacoesType : ObjectGraphType<TipoInstalacoes>
    {
        public TipoInstalacoesType()
        {
            // Defining the name of the object
            Name = "tipoInstalacoes";

            Field(x => x.IdTipoInstalacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoInstalacoes, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<LocalizacaoInstalacoesType>>("localizacaoInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalizacaoInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdTipoInstalacao)))));
            
        }
    }

    public class TipoInstalacoesInputType : InputObjectGraphType
	{
		public TipoInstalacoesInputType()
		{
			// Defining the name of the object
			Name = "tipoInstalacoesInput";
			
            //Field<StringGraphType>("idTipoInstalacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoInstalacoes");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<LocalizacaoInstalacoesInputType>>("localizacaoInstalacoes");
			
		}
	}
}