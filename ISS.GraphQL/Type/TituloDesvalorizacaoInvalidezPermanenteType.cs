using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TituloDesvalorizacaoInvalidezPermanenteType : ObjectGraphType<TituloDesvalorizacaoInvalidezPermanente>
    {
        public TituloDesvalorizacaoInvalidezPermanenteType()
        {
            // Defining the name of the object
            Name = "tituloDesvalorizacaoInvalidezPermanente";

            Field(x => x.IdTituloDesvalorizacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<SubTituloDesvalorizacaoInvalidezPermanenteType>>("subTituloDesvalorizacaoInvalidezPermanente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTituloDesvalorizacaoInvalidezPermanente>(x => x.Where(e => e.HasValue(c.Source.IdTituloDesvalorizacao)))));
            
        }
    }

    public class TituloDesvalorizacaoInvalidezPermanenteInputType : InputObjectGraphType
	{
		public TituloDesvalorizacaoInvalidezPermanenteInputType()
		{
			// Defining the name of the object
			Name = "tituloDesvalorizacaoInvalidezPermanenteInput";
			
            //Field<StringGraphType>("idTituloDesvalorizacao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<SubTituloDesvalorizacaoInvalidezPermanenteInputType>>("subTituloDesvalorizacaoInvalidezPermanente");
			
		}
	}
}