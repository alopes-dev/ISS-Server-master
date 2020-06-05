using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BeneficioCoberturaType : ObjectGraphType<BeneficioCobertura>
    {
        public BeneficioCoberturaType()
        {
            // Defining the name of the object
            Name = "beneficioCobertura";

            Field(x => x.IdBeneficioCobertura, nullable: true);
            Field(x => x.ValorMonetarioCasoMorte, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorPremioInicialBeneficio, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMensalMaximo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CoberturaProdutoId, nullable: true);
            Field(x => x.CodBeneficioCobertura, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.NumOrdem, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Obs, nullable: true);
            FieldAsync<CoberturaType>("coberturaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaProdutoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<DescricaoBeneficioCoberturaType>>("descricaoBeneficioCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescricaoBeneficioCobertura>(x => x.Where(e => e.HasValue(c.Source.IdBeneficioCobertura)))));
            
        }
    }

    public class BeneficioCoberturaInputType : InputObjectGraphType
	{
		public BeneficioCoberturaInputType()
		{
			// Defining the name of the object
			Name = "beneficioCoberturaInput";
			
            //Field<StringGraphType>("idBeneficioCobertura");
			Field<FloatGraphType>("valorMonetarioCasoMorte");
			Field<FloatGraphType>("valorPremioInicialBeneficio");
			Field<FloatGraphType>("valorMensalMaximo");
			Field<StringGraphType>("coberturaProdutoId");
			Field<StringGraphType>("codBeneficioCobertura");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("descricao");
			Field<IntGraphType>("numOrdem");
			Field<StringGraphType>("obs");
			Field<CoberturaInputType>("coberturaProduto");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<DescricaoBeneficioCoberturaInputType>>("descricaoBeneficioCobertura");
			
		}
	}
}