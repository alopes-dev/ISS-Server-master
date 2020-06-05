using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSeguroGrupoType : ObjectGraphType<TipoSeguroGrupo>
    {
        public TipoSeguroGrupoType()
        {
            // Defining the name of the object
            Name = "tipoSeguroGrupo";

            Field(x => x.IdTipoSeguroGrupo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoSeguroGrupo)))));
            
        }
    }

    public class TipoSeguroGrupoInputType : InputObjectGraphType
	{
		public TipoSeguroGrupoInputType()
		{
			// Defining the name of the object
			Name = "tipoSeguroGrupoInput";
			
            //Field<StringGraphType>("idTipoSeguroGrupo");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			
		}
	}
}