using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TomadorType : ObjectGraphType<Tomador>
    {
        public TomadorType()
        {
            // Defining the name of the object
            Name = "tomador";

            Field(x => x.IdTomador, nullable: true);
            Field(x => x.CodTomador, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class TomadorInputType : InputObjectGraphType
	{
		public TomadorInputType()
		{
			// Defining the name of the object
			Name = "tomadorInput";
			
            //Field<StringGraphType>("idTomador");
			Field<StringGraphType>("codTomador");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("apoliceId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ApoliceInputType>("apolice");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}