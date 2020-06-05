using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPartoType : ObjectGraphType<TipoParto>
    {
        public TipoPartoType()
        {
            // Defining the name of the object
            Name = "tipoParto";

            Field(x => x.IdTipoParto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoParto, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CoeficienteLimiteIndemnizacaoPartoType>>("coeficienteLimiteIndemnizacaoParto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoeficienteLimiteIndemnizacaoParto>(x => x.Where(e => e.HasValue(c.Source.IdTipoParto)))));
            
        }
    }

    public class TipoPartoInputType : InputObjectGraphType
	{
		public TipoPartoInputType()
		{
			// Defining the name of the object
			Name = "tipoPartoInput";
			
            //Field<StringGraphType>("idTipoParto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoParto");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CoeficienteLimiteIndemnizacaoPartoInputType>>("coeficienteLimiteIndemnizacaoParto");
			
		}
	}
}