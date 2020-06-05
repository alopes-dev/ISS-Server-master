using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RespostaPerguntaType : ObjectGraphType<RespostaPergunta>
    {
        public RespostaPerguntaType()
        {
            // Defining the name of the object
            Name = "respostaPergunta";

            Field(x => x.IdRespostaQuestionario, nullable: true);
            Field(x => x.PerguntaId, nullable: true);
            Field(x => x.Resposta, nullable: true);
            Field(x => x.Detalhes, nullable: true);
            Field(x => x.QuestionarioId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ItemPerguntaId, nullable: true);
            Field(x => x.AutomovelId, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ItensPerguntaType>("itemPergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ItensPergunta>(c.Source.ItemPerguntaId)));
            FieldAsync<PerguntasType>("pergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perguntas>(c.Source.PerguntaId)));
            FieldAsync<QuestionarioType>("questionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Questionario>(c.Source.QuestionarioId)));
            
        }
    }

    public class RespostaPerguntaInputType : InputObjectGraphType
	{
		public RespostaPerguntaInputType()
		{
			// Defining the name of the object
			Name = "respostaPerguntaInput";
			
            //Field<StringGraphType>("idRespostaQuestionario");
			Field<StringGraphType>("perguntaId");
			Field<StringGraphType>("resposta");
			Field<StringGraphType>("detalhes");
			Field<StringGraphType>("questionarioId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("itemPerguntaId");
			Field<StringGraphType>("automovelId");
			Field<AutomovelInputType>("automovel");
			Field<EstadoInputType>("estado");
			Field<ItensPerguntaInputType>("itemPergunta");
			Field<PerguntasInputType>("pergunta");
			Field<QuestionarioInputType>("questionario");
			
		}
	}
}