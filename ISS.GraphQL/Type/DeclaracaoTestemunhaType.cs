using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DeclaracaoTestemunhaType : ObjectGraphType<DeclaracaoTestemunha>
    {
        public DeclaracaoTestemunhaType()
        {
            // Defining the name of the object
            Name = "declaracaoTestemunha";

            Field(x => x.IdDeclaracaoTestemunha, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodDeclaracaoTestemunha, nullable: true);
            Field(x => x.Declaracoes, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            FieldAsync<ListGraphType<TestemunhaType>>("testemunha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Testemunha>(x => x.Where(e => e.HasValue(c.Source.IdDeclaracaoTestemunha)))));
            
        }
    }

    public class DeclaracaoTestemunhaInputType : InputObjectGraphType
	{
		public DeclaracaoTestemunhaInputType()
		{
			// Defining the name of the object
			Name = "declaracaoTestemunhaInput";
			
            //Field<StringGraphType>("idDeclaracaoTestemunha");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codDeclaracaoTestemunha");
			Field<StringGraphType>("declaracoes");
			Field<StringGraphType>("sinistroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<PessoaInputType>("pessoa");
			Field<SinistroInputType>("sinistro");
			Field<ListGraphType<TestemunhaInputType>>("testemunha");
			
		}
	}
}