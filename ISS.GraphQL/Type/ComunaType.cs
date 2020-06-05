using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComunaType : ObjectGraphType<Comuna>
    {
        public ComunaType()
        {
            // Defining the name of the object
            Name = "comuna";

            Field(x => x.IdComuna, nullable: true);
            Field(x => x.NomeComuna, nullable: true);
            Field(x => x.CodComuna, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.BairroId, nullable: true);
            FieldAsync<BairroType>("bairro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Bairro>(c.Source.BairroId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ComunaInputType : InputObjectGraphType
	{
		public ComunaInputType()
		{
			// Defining the name of the object
			Name = "comunaInput";
			
            //Field<StringGraphType>("idComuna");
			Field<StringGraphType>("nomeComuna");
			Field<StringGraphType>("codComuna");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("bairroId");
			Field<BairroInputType>("bairro");
			Field<EstadoInputType>("estado");
			
		}
	}
}