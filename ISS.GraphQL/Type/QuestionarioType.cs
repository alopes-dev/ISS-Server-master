using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class QuestionarioType : ObjectGraphType<Questionario>
    {
        public QuestionarioType()
        {
            // Defining the name of the object
            Name = "questionario";

            Field(x => x.IdQuestionario, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.Descricao, nullable: true);
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ListGraphType<ObjectoEnvolvidoType>>("objectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoEnvolvido>(x => x.Where(e => e.HasValue(c.Source.IdQuestionario)))));
            FieldAsync<ListGraphType<RespostaPerguntaType>>("respostaPergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RespostaPergunta>(x => x.Where(e => e.HasValue(c.Source.IdQuestionario)))));
            
        }
    }

    public class QuestionarioInputType : InputObjectGraphType
	{
		public QuestionarioInputType()
		{
			// Defining the name of the object
			Name = "questionarioInput";
			
            //Field<StringGraphType>("idQuestionario");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("descricao");
			Field<CotacaoInputType>("cotacao");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<ListGraphType<ObjectoEnvolvidoInputType>>("objectoEnvolvido");
			Field<ListGraphType<RespostaPerguntaInputType>>("respostaPergunta");
			
		}
	}
}