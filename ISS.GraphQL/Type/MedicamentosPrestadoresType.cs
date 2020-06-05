using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MedicamentosPrestadoresType : ObjectGraphType<MedicamentosPrestadores>
    {
        public MedicamentosPrestadoresType()
        {
            // Defining the name of the object
            Name = "medicamentosPrestadores";

            Field(x => x.IdMedicamentosPrestadores, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.CodMedicamentosPrestadores, nullable: true);
            Field(x => x.Unidade, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Minima, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PvpAoa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PvpuAoa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FamiliaConta, nullable: true);
            Field(x => x.PrincipioActivo, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataRegistro, nullable: true, type: typeof(IntGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class MedicamentosPrestadoresInputType : InputObjectGraphType
	{
		public MedicamentosPrestadoresInputType()
		{
			// Defining the name of the object
			Name = "medicamentosPrestadoresInput";
			
            //Field<StringGraphType>("idMedicamentosPrestadores");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("codMedicamentosPrestadores");
			Field<IntGraphType>("unidade");
			Field<IntGraphType>("minima");
			Field<FloatGraphType>("pvpAoa");
			Field<FloatGraphType>("pvpuAoa");
			Field<StringGraphType>("familiaConta");
			Field<StringGraphType>("principioActivo");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<IntGraphType>("dataRegistro");
			Field<EstadoInputType>("estado");
			
		}
	}
}