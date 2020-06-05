using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimitesComissionamentoType : ObjectGraphType<LimitesComissionamento>
    {
        public LimitesComissionamentoType()
        {
            // Defining the name of the object
            Name = "limitesComissionamento";

            Field(x => x.IdLimitesComissionamento, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodLimitesComissionamento, nullable: true);
            Field(x => x.Percentagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaPlano, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaAtribuir, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class LimitesComissionamentoInputType : InputObjectGraphType
	{
		public LimitesComissionamentoInputType()
		{
			// Defining the name of the object
			Name = "limitesComissionamentoInput";
			
            //Field<StringGraphType>("idLimitesComissionamento");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codLimitesComissionamento");
			Field<FloatGraphType>("percentagem");
			Field<FloatGraphType>("taxaPlano");
			Field<FloatGraphType>("taxaAtribuir");
			Field<EstadoInputType>("estado");
			
		}
	}
}