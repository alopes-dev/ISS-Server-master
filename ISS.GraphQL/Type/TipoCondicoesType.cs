using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCondicoesType : ObjectGraphType<TipoCondicoes>
    {
        public TipoCondicoesType()
        {
            // Defining the name of the object
            Name = "tipoCondicoes";

            Field(x => x.IdTipoCondicoes, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoCondicoes, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CondicoesType>>("condicoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Condicoes>(x => x.Where(e => e.HasValue(c.Source.IdTipoCondicoes)))));
            
        }
    }

    public class TipoCondicoesInputType : InputObjectGraphType
	{
		public TipoCondicoesInputType()
		{
			// Defining the name of the object
			Name = "tipoCondicoesInput";
			
            //Field<StringGraphType>("idTipoCondicoes");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoCondicoes");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CondicoesInputType>>("condicoes");
			
		}
	}
}