using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GrupoPessoasType : ObjectGraphType<GrupoPessoas>
    {
        public GrupoPessoasType()
        {
            // Defining the name of the object
            Name = "grupoPessoas";

            Field(x => x.IdGrupo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.AdministradorId, nullable: true);
            Field(x => x.TipoGrupoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodGrupoPessoas, nullable: true);
            FieldAsync<PessoaType>("administrador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AdministradorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoGrupoType>("tipoGrupo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoGrupo>(c.Source.TipoGrupoId)));
            FieldAsync<ListGraphType<MembrosGrupoType>>("membrosGrupo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MembrosGrupo>(x => x.Where(e => e.HasValue(c.Source.IdGrupo)))));
            
        }
    }

    public class GrupoPessoasInputType : InputObjectGraphType
	{
		public GrupoPessoasInputType()
		{
			// Defining the name of the object
			Name = "grupoPessoasInput";
			
            //Field<StringGraphType>("idGrupo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("administradorId");
			Field<StringGraphType>("tipoGrupoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codGrupoPessoas");
			Field<PessoaInputType>("administrador");
			Field<EstadoInputType>("estado");
			Field<TipoGrupoInputType>("tipoGrupo");
			Field<ListGraphType<MembrosGrupoInputType>>("membrosGrupo");
			
		}
	}
}