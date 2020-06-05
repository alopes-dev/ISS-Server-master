using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoContadoresRegistosType : ObjectGraphType<HistoricoContadoresRegistos>
    {
        public HistoricoContadoresRegistosType()
        {
            // Defining the name of the object
            Name = "historicoContadoresRegistos";

            Field(x => x.HistoricoContadoresRegistos1, nullable: true);
            Field(x => x.CodContadoresRegistos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.NumRegisto, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Ano, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IdContadoresRegistos, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class HistoricoContadoresRegistosInputType : InputObjectGraphType
	{
		public HistoricoContadoresRegistosInputType()
		{
			// Defining the name of the object
			Name = "historicoContadoresRegistosInput";
			
            Field<StringGraphType>("historicoContadoresRegistos1");
			Field<StringGraphType>("codContadoresRegistos");
			Field<StringGraphType>("designacao");
			Field<IntGraphType>("numRegisto");
			Field<StringGraphType>("ano");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("idContadoresRegistos");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}