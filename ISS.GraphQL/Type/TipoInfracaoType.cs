using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoInfracaoType : ObjectGraphType<TipoInfracao>
    {
        public TipoInfracaoType()
        {
            // Defining the name of the object
            Name = "tipoInfracao";

            Field(x => x.IdTipoInfracao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<InfraccoesType>>("infraccoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Infraccoes>(x => x.Where(e => e.HasValue(c.Source.IdTipoInfracao)))));
            
        }
    }

    public class TipoInfracaoInputType : InputObjectGraphType
	{
		public TipoInfracaoInputType()
		{
			// Defining the name of the object
			Name = "tipoInfracaoInput";
			
            //Field<StringGraphType>("idTipoInfracao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<InfraccoesInputType>>("infraccoes");
			
		}
	}
}