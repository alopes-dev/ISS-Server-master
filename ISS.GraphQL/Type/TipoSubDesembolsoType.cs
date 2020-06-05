using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSubDesembolsoType : ObjectGraphType<TipoSubDesembolso>
    {
        public TipoSubDesembolsoType()
        {
            // Defining the name of the object
            Name = "tipoSubDesembolso";

            Field(x => x.IdTipoSubDesembolso, nullable: true);
            Field(x => x.CodTipoSubDesembolsos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoDesembolsoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ListGraphType<TiposType>>("tipos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tipos>(x => x.Where(e => e.HasValue(c.Source.IdTipoSubDesembolso)))));
            
        }
    }

    public class TipoSubDesembolsoInputType : InputObjectGraphType
	{
		public TipoSubDesembolsoInputType()
		{
			// Defining the name of the object
			Name = "tipoSubDesembolsoInput";
			
            //Field<StringGraphType>("idTipoSubDesembolso");
			Field<StringGraphType>("codTipoSubDesembolsos");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoDesembolsoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<ListGraphType<TiposInputType>>("tipos");
			
		}
	}
}