using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RedeSocialPessoaType : ObjectGraphType<RedeSocialPessoa>
    {
        public RedeSocialPessoaType()
        {
            // Defining the name of the object
            Name = "redeSocialPessoa";

            Field(x => x.IdRedeSocialPessoa, nullable: true);
            Field(x => x.CodRedeSocialPessoa, nullable: true);
            Field(x => x.RedeSocialId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<RedeSociaisType>("redeSocial", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RedeSociais>(c.Source.RedeSocialId)));
            
        }
    }

    public class RedeSocialPessoaInputType : InputObjectGraphType
	{
		public RedeSocialPessoaInputType()
		{
			// Defining the name of the object
			Name = "redeSocialPessoaInput";
			
            //Field<StringGraphType>("idRedeSocialPessoa");
			Field<StringGraphType>("codRedeSocialPessoa");
			Field<StringGraphType>("redeSocialId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<PessoaInputType>("pessoa");
			Field<RedeSociaisInputType>("redeSocial");
			
		}
	}
}