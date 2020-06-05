using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ItensPerguntaType : ObjectGraphType<ItensPergunta>
    {
        public ItensPerguntaType()
        {
            // Defining the name of the object
            Name = "itensPergunta";

            Field(x => x.IdItem, nullable: true);
            Field(x => x.CodItem, nullable: true);
            Field(x => x.NumItem, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Agravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PerguntaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.SubCategoriaItensId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoAgravamentoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PerguntasType>("pergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perguntas>(c.Source.PerguntaId)));
            FieldAsync<SubCategoriaItensType>("subCategoriaItens", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubCategoriaItens>(c.Source.SubCategoriaItensId)));
            FieldAsync<TipoAgravamentoType>("tipoAgravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoAgravamento>(c.Source.TipoAgravamentoId)));
            FieldAsync<ListGraphType<RespostaPerguntaType>>("respostaPergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RespostaPergunta>(x => x.Where(e => e.HasValue(c.Source.IdItem)))));
            
        }
    }

    public class ItensPerguntaInputType : InputObjectGraphType
	{
		public ItensPerguntaInputType()
		{
			// Defining the name of the object
			Name = "itensPerguntaInput";
			
            //Field<StringGraphType>("idItem");
			Field<StringGraphType>("codItem");
			Field<IntGraphType>("numItem");
			Field<FloatGraphType>("agravamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("perguntaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("subCategoriaItensId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoAgravamentoId");
			Field<EstadoInputType>("estado");
			Field<PerguntasInputType>("pergunta");
			Field<SubCategoriaItensInputType>("subCategoriaItens");
			Field<TipoAgravamentoInputType>("tipoAgravamento");
			Field<ListGraphType<RespostaPerguntaInputType>>("respostaPergunta");
			
		}
	}
}