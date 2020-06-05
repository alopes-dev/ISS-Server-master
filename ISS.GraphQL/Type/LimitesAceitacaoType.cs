using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimitesAceitacaoType : ObjectGraphType<LimitesAceitacao>
    {
        public LimitesAceitacaoType()
        {
            // Defining the name of the object
            Name = "limitesAceitacao";

            Field(x => x.IdLimitesAceitacao, nullable: true);
            Field(x => x.NivelRiscoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodLimitesAceitacao, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class LimitesAceitacaoInputType : InputObjectGraphType
	{
		public LimitesAceitacaoInputType()
		{
			// Defining the name of the object
			Name = "limitesAceitacaoInput";
			
            //Field<StringGraphType>("idLimitesAceitacao");
			Field<StringGraphType>("nivelRiscoId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codLimitesAceitacao");
			Field<BooleanGraphType>("isTaxa");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}