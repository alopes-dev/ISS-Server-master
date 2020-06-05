using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CapituloType : ObjectGraphType<Capitulo>
    {
        public CapituloType()
        {
            // Defining the name of the object
            Name = "capitulo";

            Field(x => x.IdCapitulo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CondicoesId, nullable: true);
            Field(x => x.Obs, nullable: true);
            Field(x => x.CodCapitulo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.NumCapitulo, nullable: true);
            FieldAsync<CondicoesType>("condicoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Condicoes>(c.Source.CondicoesId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ArtigoType>>("artigo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Artigo>(x => x.Where(e => e.HasValue(c.Source.IdCapitulo)))));
            
        }
    }

    public class CapituloInputType : InputObjectGraphType
	{
		public CapituloInputType()
		{
			// Defining the name of the object
			Name = "capituloInput";
			
            //Field<StringGraphType>("idCapitulo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("condicoesId");
			Field<StringGraphType>("obs");
			Field<StringGraphType>("codCapitulo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("numCapitulo");
			Field<CondicoesInputType>("condicoes");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ArtigoInputType>>("artigo");
			
		}
	}
}