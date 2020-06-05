using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExercicioType : ObjectGraphType<Exercicio>
    {
        public ExercicioType()
        {
            // Defining the name of the object
            Name = "exercicio";

            Field(x => x.IdExercicio, nullable: true);
            Field(x => x.Mes, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Estado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodExercicio, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estadoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdExercicio)))));
            FieldAsync<ListGraphType<PeriodoType>>("periodo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Periodo>(x => x.Where(e => e.HasValue(c.Source.IdExercicio)))));
            
        }
    }

    public class ExercicioInputType : InputObjectGraphType
	{
		public ExercicioInputType()
		{
			// Defining the name of the object
			Name = "exercicioInput";
			
            //Field<StringGraphType>("idExercicio");
			Field<IntGraphType>("mes");
			Field<BooleanGraphType>("estado");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codExercicio");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estadoNavigation");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<PeriodoInputType>>("periodo");
			
		}
	}
}