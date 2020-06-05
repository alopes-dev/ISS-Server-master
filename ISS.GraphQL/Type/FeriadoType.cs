using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FeriadoType : ObjectGraphType<Feriado>
    {
        public FeriadoType()
        {
            // Defining the name of the object
            Name = "feriado";

            Field(x => x.IdFeriado, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFeriado, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Dia, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Mes, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Ano, nullable: true, type: typeof(IntGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class FeriadoInputType : InputObjectGraphType
	{
		public FeriadoInputType()
		{
			// Defining the name of the object
			Name = "feriadoInput";
			
            //Field<StringGraphType>("idFeriado");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFeriado");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<IntGraphType>("dia");
			Field<IntGraphType>("mes");
			Field<IntGraphType>("ano");
			Field<EstadoInputType>("estado");
			
		}
	}
}