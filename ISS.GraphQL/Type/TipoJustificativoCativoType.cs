using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoJustificativoCativoType : ObjectGraphType<TipoJustificativoCativo>
    {
        public TipoJustificativoCativoType()
        {
            // Defining the name of the object
            Name = "tipoJustificativoCativo";

            Field(x => x.IdTipoJustificativo, nullable: true);
            Field(x => x.CodTipoJustificativo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ValorCativoType>>("valorCativo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValorCativo>(x => x.Where(e => e.HasValue(c.Source.IdTipoJustificativo)))));
            
        }
    }

    public class TipoJustificativoCativoInputType : InputObjectGraphType
	{
		public TipoJustificativoCativoInputType()
		{
			// Defining the name of the object
			Name = "tipoJustificativoCativoInput";
			
            //Field<StringGraphType>("idTipoJustificativo");
			Field<StringGraphType>("codTipoJustificativo");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ValorCativoInputType>>("valorCativo");
			
		}
	}
}