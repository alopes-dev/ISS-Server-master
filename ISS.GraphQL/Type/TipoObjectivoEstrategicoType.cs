using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoObjectivoEstrategicoType : ObjectGraphType<TipoObjectivoEstrategico>
    {
        public TipoObjectivoEstrategicoType()
        {
            // Defining the name of the object
            Name = "tipoObjectivoEstrategico";

            Field(x => x.IdTipoObjectivoEstrategico, nullable: true);
            Field(x => x.CodTipoObjectivo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PlanoObjectivoComercialType>>("planoObjectivoComercial", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoObjectivoComercial>(x => x.Where(e => e.HasValue(c.Source.IdTipoObjectivoEstrategico)))));
            
        }
    }

    public class TipoObjectivoEstrategicoInputType : InputObjectGraphType
	{
		public TipoObjectivoEstrategicoInputType()
		{
			// Defining the name of the object
			Name = "tipoObjectivoEstrategicoInput";
			
            //Field<StringGraphType>("idTipoObjectivoEstrategico");
			Field<StringGraphType>("codTipoObjectivo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PlanoObjectivoComercialInputType>>("planoObjectivoComercial");
			
		}
	}
}