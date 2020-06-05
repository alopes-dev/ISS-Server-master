using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PeriodoType : ObjectGraphType<Periodo>
    {
        public PeriodoType()
        {
            // Defining the name of the object
            Name = "periodo";

            Field(x => x.IdPeriodo, nullable: true);
            Field(x => x.Ano, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Estado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodPeriodo, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ExercicioId, nullable: true);
            FieldAsync<EstadoType>("estadoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ExercicioType>("exercicio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exercicio>(c.Source.ExercicioId)));
            
        }
    }

    public class PeriodoInputType : InputObjectGraphType
	{
		public PeriodoInputType()
		{
			// Defining the name of the object
			Name = "periodoInput";
			
            //Field<StringGraphType>("idPeriodo");
			Field<IntGraphType>("ano");
			Field<BooleanGraphType>("estado");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codPeriodo");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("exercicioId");
			Field<EstadoInputType>("estadoNavigation");
			Field<ExercicioInputType>("exercicio");
			
		}
	}
}