using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoClassificacaoGrupoType : ObjectGraphType<TipoClassificacaoGrupo>
    {
        public TipoClassificacaoGrupoType()
        {
            // Defining the name of the object
            Name = "tipoClassificacaoGrupo";

            Field(x => x.IdTipoClassificacaoGrupo, nullable: true);
            Field(x => x.ClassificacaoGrupoId, nullable: true);
            Field(x => x.FormaContratacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodTipoClassificacaoGrupo, nullable: true);
            Field(x => x.NumMinParticipantes, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumMaxParticipantes, nullable: true, type: typeof(IntGraphType));
            FieldAsync<ClassificacaoGrupoType>("classificacaoGrupo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoGrupo>(c.Source.ClassificacaoGrupoId)));
            FieldAsync<FormaContratacaoType>("formaContratacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaContratacao>(c.Source.FormaContratacaoId)));
            
        }
    }

    public class TipoClassificacaoGrupoInputType : InputObjectGraphType
	{
		public TipoClassificacaoGrupoInputType()
		{
			// Defining the name of the object
			Name = "tipoClassificacaoGrupoInput";
			
            //Field<StringGraphType>("idTipoClassificacaoGrupo");
			Field<StringGraphType>("classificacaoGrupoId");
			Field<StringGraphType>("formaContratacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codTipoClassificacaoGrupo");
			Field<IntGraphType>("numMinParticipantes");
			Field<IntGraphType>("numMaxParticipantes");
			Field<ClassificacaoGrupoInputType>("classificacaoGrupo");
			Field<FormaContratacaoInputType>("formaContratacao");
			
		}
	}
}