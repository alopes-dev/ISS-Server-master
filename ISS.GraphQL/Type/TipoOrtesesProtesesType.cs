using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoOrtesesProtesesType : ObjectGraphType<TipoOrtesesProteses>
    {
        public TipoOrtesesProtesesType()
        {
            // Defining the name of the object
            Name = "tipoOrtesesProteses";

            Field(x => x.IdTipoOrtesesProteses, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoOrtesesProteses, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CoeficienteLimiteIndemnizacaoProteseOrtesesType>>("coeficienteLimiteIndemnizacaoProteseOrteses", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoeficienteLimiteIndemnizacaoProteseOrteses>(x => x.Where(e => e.HasValue(c.Source.IdTipoOrtesesProteses)))));
            
        }
    }

    public class TipoOrtesesProtesesInputType : InputObjectGraphType
	{
		public TipoOrtesesProtesesInputType()
		{
			// Defining the name of the object
			Name = "tipoOrtesesProtesesInput";
			
            //Field<StringGraphType>("idTipoOrtesesProteses");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoOrtesesProteses");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CoeficienteLimiteIndemnizacaoProteseOrtesesInputType>>("coeficienteLimiteIndemnizacaoProteseOrteses");
			
		}
	}
}