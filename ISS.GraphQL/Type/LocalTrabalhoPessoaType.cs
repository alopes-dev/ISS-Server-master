using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocalTrabalhoPessoaType : ObjectGraphType<LocalTrabalhoPessoa>
    {
        public LocalTrabalhoPessoaType()
        {
            // Defining the name of the object
            Name = "localTrabalhoPessoa";

            Field(x => x.IdLocalTrabalhoPessoa, nullable: true);
            Field(x => x.LocalTrabalhoId, nullable: true);
            Field(x => x.PessoaProfissaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LocalTrabalhoType>("localTrabalho", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalTrabalho>(c.Source.LocalTrabalhoId)));
            FieldAsync<PessoaProfissaoType>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(c.Source.PessoaProfissaoId)));
            
        }
    }

    public class LocalTrabalhoPessoaInputType : InputObjectGraphType
	{
		public LocalTrabalhoPessoaInputType()
		{
			// Defining the name of the object
			Name = "localTrabalhoPessoaInput";
			
            //Field<StringGraphType>("idLocalTrabalhoPessoa");
			Field<StringGraphType>("localTrabalhoId");
			Field<StringGraphType>("pessoaProfissaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LocalTrabalhoInputType>("localTrabalho");
			Field<PessoaProfissaoInputType>("pessoaProfissao");
			
		}
	}
}