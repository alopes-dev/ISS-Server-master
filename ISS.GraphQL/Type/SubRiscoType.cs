using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubRiscoType : ObjectGraphType<SubRisco>
    {
        public SubRiscoType()
        {
            // Defining the name of the object
            Name = "subRisco";

            Field(x => x.IdSubRisco, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.RiscoId, nullable: true);
            Field(x => x.CodSubRisco, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<RiscoType>("risco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Risco>(c.Source.RiscoId)));
            
        }
    }

    public class SubRiscoInputType : InputObjectGraphType
	{
		public SubRiscoInputType()
		{
			// Defining the name of the object
			Name = "subRiscoInput";
			
            //Field<StringGraphType>("idSubRisco");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("riscoId");
			Field<StringGraphType>("codSubRisco");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<RiscoInputType>("risco");
			
		}
	}
}