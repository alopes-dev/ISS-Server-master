using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ConjuguePessoaType : ObjectGraphType<ConjuguePessoa>
    {
        public ConjuguePessoaType()
        {
            // Defining the name of the object
            Name = "conjuguePessoa";

            Field(x => x.IdConjuguePessoa, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.ConjugueId, nullable: true);
            Field(x => x.CodConjuguePessoa, nullable: true);
            FieldAsync<PessoaType>("conjugue", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ConjugueId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class ConjuguePessoaInputType : InputObjectGraphType
	{
		public ConjuguePessoaInputType()
		{
			// Defining the name of the object
			Name = "conjuguePessoaInput";
			
            //Field<StringGraphType>("idConjuguePessoa");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("conjugueId");
			Field<StringGraphType>("codConjuguePessoa");
			Field<PessoaInputType>("conjugue");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}