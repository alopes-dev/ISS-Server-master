using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoQuestionarioType : ObjectGraphType<TipoQuestionario>
    {
        public TipoQuestionarioType()
        {
            // Defining the name of the object
            Name = "tipoQuestionario";

            Field(x => x.IdTipoQuestionario, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoQuestionario, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PerguntasType>>("perguntas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perguntas>(x => x.Where(e => e.HasValue(c.Source.IdTipoQuestionario)))));
            
        }
    }

    public class TipoQuestionarioInputType : InputObjectGraphType
	{
		public TipoQuestionarioInputType()
		{
			// Defining the name of the object
			Name = "tipoQuestionarioInput";
			
            //Field<StringGraphType>("idTipoQuestionario");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoQuestionario");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PerguntasInputType>>("perguntas");
			
		}
	}
}