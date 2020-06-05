using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CircunstanciaPerdaType : ObjectGraphType<CircunstanciaPerda>
    {
        public CircunstanciaPerdaType()
        {
            // Defining the name of the object
            Name = "circunstanciaPerda";

            Field(x => x.IdCircunstanciaPerda, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCircunstanciaPerda, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PerdaType>>("perda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perda>(x => x.Where(e => e.HasValue(c.Source.IdCircunstanciaPerda)))));
            
        }
    }

    public class CircunstanciaPerdaInputType : InputObjectGraphType
	{
		public CircunstanciaPerdaInputType()
		{
			// Defining the name of the object
			Name = "circunstanciaPerdaInput";
			
            //Field<StringGraphType>("idCircunstanciaPerda");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCircunstanciaPerda");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PerdaInputType>>("perda");
			
		}
	}
}