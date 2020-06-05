using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoGrupoType : ObjectGraphType<TipoGrupo>
    {
        public TipoGrupoType()
        {
            // Defining the name of the object
            Name = "tipoGrupo";

            Field(x => x.IdTipoGrupo, nullable: true);
            Field(x => x.CodTipoGrupo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.TipoPessoaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoPessoaType>("tipoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPessoa>(c.Source.TipoPessoaId)));
            FieldAsync<ListGraphType<GrupoPessoasType>>("grupoPessoas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GrupoPessoas>(x => x.Where(e => e.HasValue(c.Source.IdTipoGrupo)))));
            
        }
    }

    public class TipoGrupoInputType : InputObjectGraphType
	{
		public TipoGrupoInputType()
		{
			// Defining the name of the object
			Name = "tipoGrupoInput";
			
            //Field<StringGraphType>("idTipoGrupo");
			Field<StringGraphType>("codTipoGrupo");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("tipoPessoaId");
			Field<EstadoInputType>("estado");
			Field<TipoPessoaInputType>("tipoPessoa");
			Field<ListGraphType<GrupoPessoasInputType>>("grupoPessoas");
			
		}
	}
}