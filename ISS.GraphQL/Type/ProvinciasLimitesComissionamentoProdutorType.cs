using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProvinciasLimitesComissionamentoProdutorType : ObjectGraphType<ProvinciasLimitesComissionamentoProdutor>
    {
        public ProvinciasLimitesComissionamentoProdutorType()
        {
            // Defining the name of the object
            Name = "provinciasLimitesComissionamentoProdutor";

            Field(x => x.IdProvinciasLimitesComissionamentoProdutor, nullable: true);
            Field(x => x.CodProvinciasLimitesComissionamentoProdutor, nullable: true);
            Field(x => x.LimitesComissionamentoProdutorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ProvinciaId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<LimiteComissionamentoProdutorType>("limitesComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoProdutor>(c.Source.LimitesComissionamentoProdutorId)));
            FieldAsync<ProvinciaType>("provincia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(c.Source.ProvinciaId)));
            
        }
    }

    public class ProvinciasLimitesComissionamentoProdutorInputType : InputObjectGraphType
	{
		public ProvinciasLimitesComissionamentoProdutorInputType()
		{
			// Defining the name of the object
			Name = "provinciasLimitesComissionamentoProdutorInput";
			
            //Field<StringGraphType>("idProvinciasLimitesComissionamentoProdutor");
			Field<StringGraphType>("codProvinciasLimitesComissionamentoProdutor");
			Field<StringGraphType>("limitesComissionamentoProdutorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("provinciaId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<LimiteComissionamentoProdutorInputType>("limitesComissionamentoProdutor");
			Field<ProvinciaInputType>("provincia");
			
		}
	}
}