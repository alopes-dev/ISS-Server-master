using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PerguntasFrequentesProdutoType : ObjectGraphType<PerguntasFrequentesProduto>
    {
        public PerguntasFrequentesProdutoType()
        {
            // Defining the name of the object
            Name = "perguntasFrequentesProduto";

            Field(x => x.IdPerguntasFrequentesProduto, nullable: true);
            Field(x => x.Perguntas, nullable: true);
            Field(x => x.Resposta, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodPerguntasFrequentesProduto, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class PerguntasFrequentesProdutoInputType : InputObjectGraphType
	{
		public PerguntasFrequentesProdutoInputType()
		{
			// Defining the name of the object
			Name = "perguntasFrequentesProdutoInput";
			
            //Field<StringGraphType>("idPerguntasFrequentesProduto");
			Field<StringGraphType>("perguntas");
			Field<StringGraphType>("resposta");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codPerguntasFrequentesProduto");
			Field<EstadoInputType>("estado");
			Field<ProdutoInputType>("produto");
			
		}
	}
}