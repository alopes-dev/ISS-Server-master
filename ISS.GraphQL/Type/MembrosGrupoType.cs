using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MembrosGrupoType : ObjectGraphType<MembrosGrupo>
    {
        public MembrosGrupoType()
        {
            // Defining the name of the object
            Name = "membrosGrupo";

            Field(x => x.IdMembro, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.GrupoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.IsAdministrador, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodMembrosGrupo, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<GrupoPessoasType>("grupo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GrupoPessoas>(c.Source.GrupoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class MembrosGrupoInputType : InputObjectGraphType
	{
		public MembrosGrupoInputType()
		{
			// Defining the name of the object
			Name = "membrosGrupoInput";
			
            //Field<StringGraphType>("idMembro");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("grupoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("isAdministrador");
			Field<StringGraphType>("codMembrosGrupo");
			Field<EstadoInputType>("estado");
			Field<GrupoPessoasInputType>("grupo");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}