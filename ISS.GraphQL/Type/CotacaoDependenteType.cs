using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CotacaoDependenteType : ObjectGraphType<CotacaoDependente>
    {
        public CotacaoDependenteType()
        {
            // Defining the name of the object
            Name = "cotacaoDependente";

            Field(x => x.IdCotacaoDependente, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NumOrdem, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ApoliceId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            
        }
    }

    public class CotacaoDependenteInputType : InputObjectGraphType
	{
		public CotacaoDependenteInputType()
		{
			// Defining the name of the object
			Name = "cotacaoDependenteInput";
			
            //Field<StringGraphType>("idCotacaoDependente");
			Field<StringGraphType>("cotacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<IntGraphType>("numOrdem");
			Field<StringGraphType>("apoliceId");
			Field<ApoliceInputType>("apolice");
			Field<CotacaoInputType>("cotacao");
			
		}
	}
}