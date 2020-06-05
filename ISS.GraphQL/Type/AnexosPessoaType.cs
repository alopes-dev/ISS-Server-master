using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AnexosPessoaType : ObjectGraphType<AnexosPessoa>
    {
        public AnexosPessoaType()
        {
            // Defining the name of the object
            Name = "anexosPessoa";

            Field(x => x.IdAnexosPessoa, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodAnexosPessoa, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class AnexosPessoaInputType : InputObjectGraphType
	{
		public AnexosPessoaInputType()
		{
			// Defining the name of the object
			Name = "anexosPessoaInput";
			
            //Field<StringGraphType>("idAnexosPessoa");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codAnexosPessoa");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}