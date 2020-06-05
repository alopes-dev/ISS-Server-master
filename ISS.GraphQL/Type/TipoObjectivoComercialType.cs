using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoObjectivoComercialType : ObjectGraphType<TipoObjectivoComercial>
    {
        public TipoObjectivoComercialType()
        {
            // Defining the name of the object
            Name = "tipoObjectivoComercial";

            Field(x => x.IdTipoObjectivoComercial, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoObjectivoComercial, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ObjectivoComercialType>>("objectivoComercial", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectivoComercial>(x => x.Where(e => e.HasValue(c.Source.IdTipoObjectivoComercial)))));
            
        }
    }

    public class TipoObjectivoComercialInputType : InputObjectGraphType
	{
		public TipoObjectivoComercialInputType()
		{
			// Defining the name of the object
			Name = "tipoObjectivoComercialInput";
			
            //Field<StringGraphType>("idTipoObjectivoComercial");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoObjectivoComercial");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ObjectivoComercialInputType>>("objectivoComercial");
			
		}
	}
}