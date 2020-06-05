using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MedicamentosType : ObjectGraphType<Medicamentos>
    {
        public MedicamentosType()
        {
            // Defining the name of the object
            Name = "medicamentos";

            Field(x => x.IdMedicamento, nullable: true);
            Field(x => x.CodigoMedicamento, nullable: true);
            Field(x => x.Ean, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.FamiliaConta, nullable: true);
            Field(x => x.PrincipioAtivo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataEntrada, nullable: true, type: typeof(IntGraphType));
            FieldAsync<ListGraphType<PrecosMedicamentosType>>("precosMedicamentos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecosMedicamentos>(x => x.Where(e => e.HasValue(c.Source.IdMedicamento)))));
            
        }
    }

    public class MedicamentosInputType : InputObjectGraphType
	{
		public MedicamentosInputType()
		{
			// Defining the name of the object
			Name = "medicamentosInput";
			
            //Field<StringGraphType>("idMedicamento");
			Field<StringGraphType>("codigoMedicamento");
			Field<StringGraphType>("ean");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("familiaConta");
			Field<StringGraphType>("principioAtivo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<IntGraphType>("dataEntrada");
			Field<ListGraphType<PrecosMedicamentosInputType>>("precosMedicamentos");
			
		}
	}
}