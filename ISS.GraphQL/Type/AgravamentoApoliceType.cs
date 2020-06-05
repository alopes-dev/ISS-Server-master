using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgravamentoApoliceType : ObjectGraphType<AgravamentoApolice>
    {
        public AgravamentoApoliceType()
        {
            // Defining the name of the object
            Name = "agravamentoApolice";

            Field(x => x.IdAgravamentoApolice, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.AgravamentoId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<AgravamentoType>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(c.Source.AgravamentoId)));
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            
        }
    }

    public class AgravamentoApoliceInputType : InputObjectGraphType
	{
		public AgravamentoApoliceInputType()
		{
			// Defining the name of the object
			Name = "agravamentoApoliceInput";
			
            //Field<StringGraphType>("idAgravamentoApolice");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("agravamentoId");
			Field<StringGraphType>("apoliceId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<AgravamentoInputType>("agravamento");
			Field<ApoliceInputType>("apolice");
			
		}
	}
}