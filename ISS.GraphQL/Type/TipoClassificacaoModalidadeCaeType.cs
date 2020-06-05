using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoClassificacaoModalidadeCaeType : ObjectGraphType<TipoClassificacaoModalidadeCae>
    {
        public TipoClassificacaoModalidadeCaeType()
        {
            // Defining the name of the object
            Name = "tipoClassificacaoModalidadeCae";

            Field(x => x.IdClassificacaoModalidadeCae, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ClassificacaoModalidadeCaeId, nullable: true);
            Field(x => x.CodTipoClassificacaoModalidadeCae, nullable: true);
            Field(x => x.Descricao, nullable: true);
            FieldAsync<ClassificacaoModalidadeCaeType>("classificacaoModalidadeCae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoModalidadeCae>(c.Source.ClassificacaoModalidadeCaeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoClassificacaoModalidadeCaeInputType : InputObjectGraphType
	{
		public TipoClassificacaoModalidadeCaeInputType()
		{
			// Defining the name of the object
			Name = "tipoClassificacaoModalidadeCaeInput";
			
            //Field<StringGraphType>("idClassificacaoModalidadeCae");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("classificacaoModalidadeCaeId");
			Field<StringGraphType>("codTipoClassificacaoModalidadeCae");
			Field<StringGraphType>("descricao");
			Field<ClassificacaoModalidadeCaeInputType>("classificacaoModalidadeCae");
			Field<EstadoInputType>("estado");
			
		}
	}
}