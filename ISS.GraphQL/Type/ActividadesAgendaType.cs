using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ActividadesAgendaType : ObjectGraphType<ActividadesAgenda>
    {
        public ActividadesAgendaType()
        {
            // Defining the name of the object
            Name = "actividadesAgenda";

            Field(x => x.IdActividadesAgenda, nullable: true);
            Field(x => x.AgendaId, nullable: true);
            Field(x => x.ActividadeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ActividadeType>("actividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Actividade>(c.Source.ActividadeId)));
            FieldAsync<AgendaType>("agenda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agenda>(c.Source.AgendaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ActividadesAgendaInputType : InputObjectGraphType
	{
		public ActividadesAgendaInputType()
		{
			// Defining the name of the object
			Name = "actividadesAgendaInput";
			
            //Field<StringGraphType>("idActividadesAgenda");
			Field<StringGraphType>("agendaId");
			Field<StringGraphType>("actividadeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ActividadeInputType>("actividade");
			Field<AgendaInputType>("agenda");
			Field<EstadoInputType>("estado");
			
		}
	}
}