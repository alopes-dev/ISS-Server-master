using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoGrupoType : ObjectGraphType<ClassificacaoGrupo>
    {
        public ClassificacaoGrupoType()
        {
            // Defining the name of the object
            Name = "classificacaoGrupo";

            Field(x => x.IdClassificacaoGrupo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Datatualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodClassificacaoGrupo, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoGrupo)))));
            FieldAsync<ListGraphType<TipoClassificacaoGrupoType>>("tipoClassificacaoGrupo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoClassificacaoGrupo>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoGrupo)))));
            
        }
    }

    public class ClassificacaoGrupoInputType : InputObjectGraphType
	{
		public ClassificacaoGrupoInputType()
		{
			// Defining the name of the object
			Name = "classificacaoGrupoInput";
			
            //Field<StringGraphType>("idClassificacaoGrupo");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("datatualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codClassificacaoGrupo");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<TipoClassificacaoGrupoInputType>>("tipoClassificacaoGrupo");
			
		}
	}
}