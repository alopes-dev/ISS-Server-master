using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrioridadeTarefaType : ObjectGraphType<PrioridadeTarefa>
    {
        public PrioridadeTarefaType()
        {
            // Defining the name of the object
            Name = "prioridadeTarefa";

            Field(x => x.IdPrioridadeTarefa, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PrioridadeTarefaInputType : InputObjectGraphType
	{
		public PrioridadeTarefaInputType()
		{
			// Defining the name of the object
			Name = "prioridadeTarefaInput";
			
            //Field<StringGraphType>("idPrioridadeTarefa");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}