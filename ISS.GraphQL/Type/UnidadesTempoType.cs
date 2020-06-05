using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class UnidadesTempoType : ObjectGraphType<UnidadesTempo>
    {
        public UnidadesTempoType()
        {
            // Defining the name of the object
            Name = "unidadesTempo";

            Field(x => x.IdUnidadeTempo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodUnidadesTempo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AnimaisType>>("animais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Animais>(x => x.Where(e => e.HasValue(c.Source.IdUnidadeTempo)))));
            FieldAsync<ListGraphType<InstalacoesType>>("instalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Instalacoes>(x => x.Where(e => e.HasValue(c.Source.IdUnidadeTempo)))));
            
        }
    }

    public class UnidadesTempoInputType : InputObjectGraphType
	{
		public UnidadesTempoInputType()
		{
			// Defining the name of the object
			Name = "unidadesTempoInput";
			
            //Field<StringGraphType>("idUnidadeTempo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codUnidadesTempo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AnimaisInputType>>("animais");
			Field<ListGraphType<InstalacoesInputType>>("instalacoes");
			
		}
	}
}