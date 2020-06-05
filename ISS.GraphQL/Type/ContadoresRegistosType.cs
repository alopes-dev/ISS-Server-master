using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContadoresRegistosType : ObjectGraphType<ContadoresRegistos>
    {
        public ContadoresRegistosType()
        {
            // Defining the name of the object
            Name = "contadoresRegistos";

            Field(x => x.IdContadoresRegistos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.NumRegistoAnual, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Ano, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodContadoresRegistos, nullable: true);
            Field(x => x.NumRegistoDiario, nullable: true, type: typeof(IntGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ContadoresRegistosInputType : InputObjectGraphType
	{
		public ContadoresRegistosInputType()
		{
			// Defining the name of the object
			Name = "contadoresRegistosInput";
			
            //Field<StringGraphType>("idContadoresRegistos");
			Field<StringGraphType>("designacao");
			Field<IntGraphType>("numRegistoAnual");
			Field<StringGraphType>("ano");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codContadoresRegistos");
			Field<IntGraphType>("numRegistoDiario");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}