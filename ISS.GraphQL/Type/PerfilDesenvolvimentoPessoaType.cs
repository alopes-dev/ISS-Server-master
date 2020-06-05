using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PerfilDesenvolvimentoPessoaType : ObjectGraphType<PerfilDesenvolvimentoPessoa>
    {
        public PerfilDesenvolvimentoPessoaType()
        {
            // Defining the name of the object
            Name = "perfilDesenvolvimentoPessoa";

            Field(x => x.IdPerfilDesenvolvimentoPessoa, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PerfilDesenvolvimentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodPerfilDesenvolvimentoPessoa, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PerfilDesenvolvimentoType>("perfilDesenvolvimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PerfilDesenvolvimento>(c.Source.PerfilDesenvolvimentoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class PerfilDesenvolvimentoPessoaInputType : InputObjectGraphType
	{
		public PerfilDesenvolvimentoPessoaInputType()
		{
			// Defining the name of the object
			Name = "perfilDesenvolvimentoPessoaInput";
			
            //Field<StringGraphType>("idPerfilDesenvolvimentoPessoa");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("perfilDesenvolvimentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codPerfilDesenvolvimentoPessoa");
			Field<EstadoInputType>("estado");
			Field<PerfilDesenvolvimentoInputType>("perfilDesenvolvimento");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}