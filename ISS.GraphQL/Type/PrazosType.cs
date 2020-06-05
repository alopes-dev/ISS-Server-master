using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrazosType : ObjectGraphType<Prazos>
    {
        public PrazosType()
        {
            // Defining the name of the object
            Name = "prazos";

            Field(x => x.IdPrazo, nullable: true);
            Field(x => x.CodPrazos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PrazosInputType : InputObjectGraphType
	{
		public PrazosInputType()
		{
			// Defining the name of the object
			Name = "prazosInput";
			
            //Field<StringGraphType>("idPrazo");
			Field<StringGraphType>("codPrazos");
			Field<StringGraphType>("designacao");
			Field<IntGraphType>("valorMin");
			Field<IntGraphType>("valorMax");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			
		}
	}
}