using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoProvisaoType : ObjectGraphType<TipoProvisao>
    {
        public TipoProvisaoType()
        {
            // Defining the name of the object
            Name = "tipoProvisao";

            Field(x => x.IdProvisao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoProvisao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ReservasTecnicasType>>("reservasTecnicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReservasTecnicas>(x => x.Where(e => e.HasValue(c.Source.IdProvisao)))));
            
        }
    }

    public class TipoProvisaoInputType : InputObjectGraphType
	{
		public TipoProvisaoInputType()
		{
			// Defining the name of the object
			Name = "tipoProvisaoInput";
			
            //Field<StringGraphType>("idProvisao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoProvisao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ReservasTecnicasInputType>>("reservasTecnicas");
			
		}
	}
}