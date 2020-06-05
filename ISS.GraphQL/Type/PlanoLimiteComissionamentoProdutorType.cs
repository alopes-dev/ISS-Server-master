using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PlanoLimiteComissionamentoProdutorType : ObjectGraphType<PlanoLimiteComissionamentoProdutor>
    {
        public PlanoLimiteComissionamentoProdutorType()
        {
            // Defining the name of the object
            Name = "planoLimiteComissionamentoProdutor";

            Field(x => x.IdPlanoLimiteComissionamentoProdutor, nullable: true);
            Field(x => x.CodPlanoLimiteComissionamentoProdutor, nullable: true);
            Field(x => x.LimitesComissionamentoProdutorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<LimiteComissionamentoProdutorType>("limitesComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoProdutor>(c.Source.LimitesComissionamentoProdutorId)));
            
        }
    }

    public class PlanoLimiteComissionamentoProdutorInputType : InputObjectGraphType
	{
		public PlanoLimiteComissionamentoProdutorInputType()
		{
			// Defining the name of the object
			Name = "planoLimiteComissionamentoProdutorInput";
			
            //Field<StringGraphType>("idPlanoLimiteComissionamentoProdutor");
			Field<StringGraphType>("codPlanoLimiteComissionamentoProdutor");
			Field<StringGraphType>("limitesComissionamentoProdutorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<LimiteComissionamentoProdutorInputType>("limitesComissionamentoProdutor");
			
		}
	}
}