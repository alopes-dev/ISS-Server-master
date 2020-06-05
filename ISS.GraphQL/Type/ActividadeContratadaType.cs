using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ActividadeContratadaType : ObjectGraphType<ActividadeContratada>
    {
        public ActividadeContratadaType()
        {
            // Defining the name of the object
            Name = "actividadeContratada";

            Field(x => x.IdActividadeContratada, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodActividadeContratada, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdActividadeContratada)))));
            
        }
    }

    public class ActividadeContratadaInputType : InputObjectGraphType
	{
		public ActividadeContratadaInputType()
		{
			// Defining the name of the object
			Name = "actividadeContratadaInput";
			
            //Field<StringGraphType>("idActividadeContratada");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codActividadeContratada");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			
		}
	}
}