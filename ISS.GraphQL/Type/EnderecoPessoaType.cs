using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EnderecoPessoaType : ObjectGraphType<EnderecoPessoa>
    {
        public EnderecoPessoaType()
        {
            // Defining the name of the object
            Name = "enderecoPessoa";

            Field(x => x.IdEnderecoPessoa, nullable: true);
            Field(x => x.Principal, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodEnderecoPessoa, nullable: true);
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class EnderecoPessoaInputType : InputObjectGraphType
	{
		public EnderecoPessoaInputType()
		{
			// Defining the name of the object
			Name = "enderecoPessoaInput";
			
            //Field<StringGraphType>("idEnderecoPessoa");
			Field<BooleanGraphType>("principal");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codEnderecoPessoa");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}