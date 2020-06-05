using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NivelRiscoCoberturaType : ObjectGraphType<NivelRiscoCobertura>
    {
        public NivelRiscoCoberturaType()
        {
            // Defining the name of the object
            Name = "nivelRiscoCobertura";

            Field(x => x.IdNivelRiscoCobertura, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            Field(x => x.NivelRiscoId, nullable: true);
            Field(x => x.ValorDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorAgravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorCapSeguro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LimiteMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LimiteMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CoberturaProdutoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CoberturaType>("coberturaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaProdutoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class NivelRiscoCoberturaInputType : InputObjectGraphType
	{
		public NivelRiscoCoberturaInputType()
		{
			// Defining the name of the object
			Name = "nivelRiscoCoberturaInput";
			
            //Field<StringGraphType>("idNivelRiscoCobertura");
			Field<StringGraphType>("tipoCoberturaId");
			Field<StringGraphType>("nivelRiscoId");
			Field<FloatGraphType>("valorDesconto");
			Field<FloatGraphType>("valorAgravamento");
			Field<FloatGraphType>("valorCapSeguro");
			Field<FloatGraphType>("limiteMin");
			Field<FloatGraphType>("limiteMax");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("coberturaProdutoId");
			Field<StringGraphType>("moedaId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<CoberturaInputType>("coberturaProduto");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}