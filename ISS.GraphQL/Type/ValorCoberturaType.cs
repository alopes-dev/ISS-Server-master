using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ValorCoberturaType : ObjectGraphType<ValorCobertura>
    {
        public ValorCoberturaType()
        {
            // Defining the name of the object
            Name = "valorCobertura";

            Field(x => x.IdValorCobertura, nullable: true);
            Field(x => x.PremioRisco, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SinistroEsperado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MargemComnercial, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioComercial, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaComercial, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PremioBruto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioCobrado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodValorCobertura, nullable: true);
            Field(x => x.CoberturaApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ClassificacaoAutomovelId, nullable: true);
            FieldAsync<ClassificacaoAutomovelType>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(c.Source.ClassificacaoAutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ValorCoberturaInputType : InputObjectGraphType
	{
		public ValorCoberturaInputType()
		{
			// Defining the name of the object
			Name = "valorCoberturaInput";
			
            //Field<StringGraphType>("idValorCobertura");
			Field<FloatGraphType>("premioRisco");
			Field<FloatGraphType>("premioSimples");
			Field<FloatGraphType>("sinistroEsperado");
			Field<FloatGraphType>("margemComnercial");
			Field<FloatGraphType>("premioComercial");
			Field<FloatGraphType>("taxaComercial");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("premioBruto");
			Field<FloatGraphType>("premioCobrado");
			Field<StringGraphType>("codValorCobertura");
			Field<StringGraphType>("coberturaApoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("classificacaoAutomovelId");
			Field<ClassificacaoAutomovelInputType>("classificacaoAutomovel");
			Field<EstadoInputType>("estado");
			
		}
	}
}