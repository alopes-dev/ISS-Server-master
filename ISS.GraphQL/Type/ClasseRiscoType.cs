using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClasseRiscoType : ObjectGraphType<ClasseRisco>
    {
        public ClasseRiscoType()
        {
            // Defining the name of the object
            Name = "classeRisco";

            Field(x => x.IdClasseRisco, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Acrescimo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.CodClasseRisco, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TarifaType>>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            
        }
    }

    public class ClasseRiscoInputType : InputObjectGraphType
	{
		public ClasseRiscoInputType()
		{
			// Defining the name of the object
			Name = "classeRiscoInput";
			
            //Field<StringGraphType>("idClasseRisco");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("acrescimo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("codClasseRisco");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TarifaInputType>>("tarifa");
			
		}
	}
}