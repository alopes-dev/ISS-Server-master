using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SobrePremioCoberturaAdicionalType : ObjectGraphType<SobrePremioCoberturaAdicional>
    {
        public SobrePremioCoberturaAdicionalType()
        {
            // Defining the name of the object
            Name = "sobrePremioCoberturaAdicional";

            Field(x => x.IdSobrePremioCoberturaAdicional, nullable: true);
            Field(x => x.CoberturaId, nullable: true);
            Field(x => x.CodSobrePremioCoberturaAdicional, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PorCadaCapitalSeguro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CoberturaAdicionalId, nullable: true);
            Field(x => x.SobrePremio, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<CoberturaType>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaId)));
            FieldAsync<CoberturaType>("coberturaAdicional", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaAdicionalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class SobrePremioCoberturaAdicionalInputType : InputObjectGraphType
	{
		public SobrePremioCoberturaAdicionalInputType()
		{
			// Defining the name of the object
			Name = "sobrePremioCoberturaAdicionalInput";
			
            //Field<StringGraphType>("idSobrePremioCoberturaAdicional");
			Field<StringGraphType>("coberturaId");
			Field<StringGraphType>("codSobrePremioCoberturaAdicional");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("porCadaCapitalSeguro");
			Field<StringGraphType>("coberturaAdicionalId");
			Field<FloatGraphType>("sobrePremio");
			Field<CoberturaInputType>("cobertura");
			Field<CoberturaInputType>("coberturaAdicional");
			Field<EstadoInputType>("estado");
			
		}
	}
}