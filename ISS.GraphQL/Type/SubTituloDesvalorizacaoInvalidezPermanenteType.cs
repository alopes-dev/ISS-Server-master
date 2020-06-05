using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubTituloDesvalorizacaoInvalidezPermanenteType : ObjectGraphType<SubTituloDesvalorizacaoInvalidezPermanente>
    {
        public SubTituloDesvalorizacaoInvalidezPermanenteType()
        {
            // Defining the name of the object
            Name = "subTituloDesvalorizacaoInvalidezPermanente";

            Field(x => x.IdSubTituloDesvalorizacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TituloDesvalorizacaoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TituloDesvalorizacaoInvalidezPermanenteType>("tituloDesvalorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TituloDesvalorizacaoInvalidezPermanente>(c.Source.TituloDesvalorizacaoId)));
            FieldAsync<ListGraphType<DesvalorizacaoInvalidezPermanenteType>>("desvalorizacaoInvalidezPermanente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DesvalorizacaoInvalidezPermanente>(x => x.Where(e => e.HasValue(c.Source.IdSubTituloDesvalorizacao)))));
            
        }
    }

    public class SubTituloDesvalorizacaoInvalidezPermanenteInputType : InputObjectGraphType
	{
		public SubTituloDesvalorizacaoInvalidezPermanenteInputType()
		{
			// Defining the name of the object
			Name = "subTituloDesvalorizacaoInvalidezPermanenteInput";
			
            //Field<StringGraphType>("idSubTituloDesvalorizacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tituloDesvalorizacaoId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TituloDesvalorizacaoInvalidezPermanenteInputType>("tituloDesvalorizacao");
			Field<ListGraphType<DesvalorizacaoInvalidezPermanenteInputType>>("desvalorizacaoInvalidezPermanente");
			
		}
	}
}