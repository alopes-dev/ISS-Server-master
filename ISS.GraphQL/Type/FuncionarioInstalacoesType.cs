using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FuncionarioInstalacoesType : ObjectGraphType<FuncionarioInstalacoes>
    {
        public FuncionarioInstalacoesType()
        {
            // Defining the name of the object
            Name = "funcionarioInstalacoes";

            Field(x => x.IdFuncionarioInstalacoes, nullable: true);
            Field(x => x.NumIdFuncionario, nullable: true);
            Field(x => x.InstalacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodFuncionarioInstalacoes, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<InstalacoesType>("instalacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Instalacoes>(c.Source.InstalacaoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class FuncionarioInstalacoesInputType : InputObjectGraphType
	{
		public FuncionarioInstalacoesInputType()
		{
			// Defining the name of the object
			Name = "funcionarioInstalacoesInput";
			
            //Field<StringGraphType>("idFuncionarioInstalacoes");
			Field<StringGraphType>("numIdFuncionario");
			Field<StringGraphType>("instalacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codFuncionarioInstalacoes");
			Field<EstadoInputType>("estado");
			Field<InstalacoesInputType>("instalacao");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}