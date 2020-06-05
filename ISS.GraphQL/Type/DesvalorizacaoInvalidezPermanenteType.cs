using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DesvalorizacaoInvalidezPermanenteType : ObjectGraphType<DesvalorizacaoInvalidezPermanente>
    {
        public DesvalorizacaoInvalidezPermanenteType()
        {
            // Defining the name of the object
            Name = "desvalorizacaoInvalidezPermanente";

            Field(x => x.IdDesvalorizacaoInvalidezPermanente, nullable: true);
            Field(x => x.PontosDesvalorizacao, nullable: true);
            Field(x => x.PorCentoDesvalorizacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.D, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.E, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SubTituloDesvalorizacaoId, nullable: true);
            Field(x => x.CodDesvalorizacaoInvalidezPermanente, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SubTituloDesvalorizacaoInvalidezPermanenteType>("subTituloDesvalorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTituloDesvalorizacaoInvalidezPermanente>(c.Source.SubTituloDesvalorizacaoId)));
            
        }
    }

    public class DesvalorizacaoInvalidezPermanenteInputType : InputObjectGraphType
	{
		public DesvalorizacaoInvalidezPermanenteInputType()
		{
			// Defining the name of the object
			Name = "desvalorizacaoInvalidezPermanenteInput";
			
            //Field<StringGraphType>("idDesvalorizacaoInvalidezPermanente");
			Field<StringGraphType>("pontosDesvalorizacao");
			Field<FloatGraphType>("porCentoDesvalorizacao");
			Field<FloatGraphType>("d");
			Field<FloatGraphType>("e");
			Field<StringGraphType>("subTituloDesvalorizacaoId");
			Field<StringGraphType>("codDesvalorizacaoInvalidezPermanente");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<SubTituloDesvalorizacaoInvalidezPermanenteInputType>("subTituloDesvalorizacao");
			
		}
	}
}