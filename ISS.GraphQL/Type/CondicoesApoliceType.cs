using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicoesApoliceType : ObjectGraphType<CondicoesApolice>
    {
        public CondicoesApoliceType()
        {
            // Defining the name of the object
            Name = "condicoesApolice";

            Field(x => x.IdCondicao, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.CondicoesId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CondicoesType>("condicoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Condicoes>(c.Source.CondicoesId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CondicoesApoliceInputType : InputObjectGraphType
	{
		public CondicoesApoliceInputType()
		{
			// Defining the name of the object
			Name = "condicoesApoliceInput";
			
            //Field<StringGraphType>("idCondicao");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("condicoesId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ApoliceInputType>("apolice");
			Field<CondicoesInputType>("condicoes");
			Field<EstadoInputType>("estado");
			
		}
	}
}