using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimiteResponsablidadeCivilAutomovelType : ObjectGraphType<LimiteResponsablidadeCivilAutomovel>
    {
        public LimiteResponsablidadeCivilAutomovelType()
        {
            // Defining the name of the object
            Name = "limiteResponsablidadeCivilAutomovel";

            Field(x => x.IdLimiteResponsablidadeCivilAutomovel, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.OutrasGarantias, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Nota, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            
        }
    }

    public class LimiteResponsablidadeCivilAutomovelInputType : InputObjectGraphType
	{
		public LimiteResponsablidadeCivilAutomovelInputType()
		{
			// Defining the name of the object
			Name = "limiteResponsablidadeCivilAutomovelInput";
			
            //Field<StringGraphType>("idLimiteResponsablidadeCivilAutomovel");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("moedaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("outrasGarantias");
			Field<StringGraphType>("nota");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			
		}
	}
}