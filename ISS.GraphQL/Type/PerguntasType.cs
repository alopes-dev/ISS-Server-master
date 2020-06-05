using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PerguntasType : ObjectGraphType<Perguntas>
    {
        public PerguntasType()
        {
            // Defining the name of the object
            Name = "perguntas";

            Field(x => x.IdPergunta, nullable: true);
            Field(x => x.NumPergunta, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Pergunta, nullable: true);
            Field(x => x.TipoQuestionarioId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.IsRadioButton, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsTextBox, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsCheckBox, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsComboBox, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsNumber, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodPerguntas, nullable: true);
            Field(x => x.IsDatePicker, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Legenda, nullable: true);
            Field(x => x.Agravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PerguntaMaeId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.ModalidadeSeguroId, nullable: true);
            Field(x => x.Nota, nullable: true);
            Field(x => x.Sourc, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ModalidadeSeguroType>("modalidadeSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadeSeguro>(c.Source.ModalidadeSeguroId)));
            FieldAsync<PerguntasType>("perguntaMae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perguntas>(c.Source.PerguntaMaeId)));
            FieldAsync<TipoQuestionarioType>("tipoQuestionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoQuestionario>(c.Source.TipoQuestionarioId)));
            FieldAsync<ListGraphType<PerguntasType>>("inversePerguntaMae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perguntas>(x => x.Where(e => e.HasValue(c.Source.IdPergunta)))));
            FieldAsync<ListGraphType<ItensPerguntaType>>("itensPergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ItensPergunta>(x => x.Where(e => e.HasValue(c.Source.IdPergunta)))));
            FieldAsync<ListGraphType<RespostaPerguntaType>>("respostaPergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RespostaPergunta>(x => x.Where(e => e.HasValue(c.Source.IdPergunta)))));
            
        }
    }

    public class PerguntasInputType : InputObjectGraphType
	{
		public PerguntasInputType()
		{
			// Defining the name of the object
			Name = "perguntasInput";
			
            //Field<StringGraphType>("idPergunta");
			Field<IntGraphType>("numPergunta");
			Field<StringGraphType>("pergunta");
			Field<StringGraphType>("tipoQuestionarioId");
			Field<StringGraphType>("linhaProdutoId");
			Field<BooleanGraphType>("isRadioButton");
			Field<BooleanGraphType>("isTextBox");
			Field<BooleanGraphType>("isCheckBox");
			Field<BooleanGraphType>("isComboBox");
			Field<BooleanGraphType>("isNumber");
			Field<StringGraphType>("codPerguntas");
			Field<BooleanGraphType>("isDatePicker");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("legenda");
			Field<FloatGraphType>("agravamento");
			Field<StringGraphType>("perguntaMaeId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("modalidadeSeguroId");
			Field<StringGraphType>("nota");
			Field<StringGraphType>("sourc");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ModalidadeSeguroInputType>("modalidadeSeguro");
			Field<PerguntasInputType>("perguntaMae");
			Field<TipoQuestionarioInputType>("tipoQuestionario");
			Field<ListGraphType<PerguntasInputType>>("inversePerguntaMae");
			Field<ListGraphType<ItensPerguntaInputType>>("itensPergunta");
			Field<ListGraphType<RespostaPerguntaInputType>>("respostaPergunta");
			
		}
	}
}