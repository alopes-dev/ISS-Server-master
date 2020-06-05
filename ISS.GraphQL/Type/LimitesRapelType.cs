using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimitesRapelType : ObjectGraphType<LimitesRapel>
    {
        public LimitesRapelType()
        {
            // Defining the name of the object
            Name = "limitesRapel";

            Field(x => x.IdLimitesRapel, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodLimitesRapel, nullable: true);
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<ListGraphType<RapelProdutorType>>("rapelProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RapelProdutor>(x => x.Where(e => e.HasValue(c.Source.IdLimitesRapel)))));
            
        }
    }

    public class LimitesRapelInputType : InputObjectGraphType
	{
		public LimitesRapelInputType()
		{
			// Defining the name of the object
			Name = "limitesRapelInput";
			
            //Field<StringGraphType>("idLimitesRapel");
			Field<FloatGraphType>("valorMin");
			Field<StringGraphType>("codLimitesRapel");
			Field<FloatGraphType>("valorMax");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("moedaId");
			Field<FloatGraphType>("taxa");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<ListGraphType<RapelProdutorInputType>>("rapelProdutor");
			
		}
	}
}