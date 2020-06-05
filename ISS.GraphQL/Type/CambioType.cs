using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CambioType : ObjectGraphType<Cambio>
    {
        public CambioType()
        {
            // Defining the name of the object
            Name = "cambio";

            Field(x => x.IdCambio, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.DivisaCompra, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DivisaVenda, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NotasCompra, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NotasVenda, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Spreed, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaBaseId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<MoedaType>("moedaBase", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaBaseId)));
            FieldAsync<ListGraphType<PrecosAtosMedicosType>>("precosAtosMedicos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecosAtosMedicos>(x => x.Where(e => e.HasValue(c.Source.IdCambio)))));
            
        }
    }

    public class CambioInputType : InputObjectGraphType
	{
		public CambioInputType()
		{
			// Defining the name of the object
			Name = "cambioInput";
			
            //Field<StringGraphType>("idCambio");
			Field<StringGraphType>("moedaId");
			Field<FloatGraphType>("divisaCompra");
			Field<FloatGraphType>("divisaVenda");
			Field<FloatGraphType>("notasCompra");
			Field<FloatGraphType>("notasVenda");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<FloatGraphType>("spreed");
			Field<StringGraphType>("moedaBaseId");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<MoedaInputType>("moedaBase");
			Field<ListGraphType<PrecosAtosMedicosInputType>>("precosAtosMedicos");
			
		}
	}
}