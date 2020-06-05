using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoTarefaReparacaoType : ObjectGraphType<TipoTarefaReparacao>
    {
        public TipoTarefaReparacaoType()
        {
            // Defining the name of the object
            Name = "tipoTarefaReparacao";

            Field(x => x.IdTipoTarefaReparacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoTarefaReparacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TarefaReparacaoType>>("tarefaReparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefaReparacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoTarefaReparacao)))));
            
        }
    }

    public class TipoTarefaReparacaoInputType : InputObjectGraphType
	{
		public TipoTarefaReparacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoTarefaReparacaoInput";
			
            //Field<StringGraphType>("idTipoTarefaReparacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoTarefaReparacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TarefaReparacaoInputType>>("tarefaReparacao");
			
		}
	}
}