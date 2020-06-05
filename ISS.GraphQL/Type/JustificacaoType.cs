using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class JustificacaoType : ObjectGraphType<Justificacao>
    {
        public JustificacaoType()
        {
            // Defining the name of the object
            Name = "justificacao";

            Field(x => x.IdJustificacao, nullable: true);
            Field(x => x.Obs, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.CategoriaJustificacaoId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CategoriaJustificacaoType>("categoriaJustificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaJustificacao>(c.Source.CategoriaJustificacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class JustificacaoInputType : InputObjectGraphType
	{
		public JustificacaoInputType()
		{
			// Defining the name of the object
			Name = "justificacaoInput";
			
            //Field<StringGraphType>("idJustificacao");
			Field<StringGraphType>("obs");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("categoriaJustificacaoId");
			Field<StringGraphType>("apoliceId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<ApoliceInputType>("apolice");
			Field<CategoriaJustificacaoInputType>("categoriaJustificacao");
			Field<EstadoInputType>("estado");
			
		}
	}
}