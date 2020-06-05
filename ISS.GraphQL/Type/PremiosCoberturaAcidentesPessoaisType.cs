using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PremiosCoberturaAcidentesPessoaisType : ObjectGraphType<PremiosCoberturaAcidentesPessoais>
    {
        public PremiosCoberturaAcidentesPessoaisType()
        {
            // Defining the name of the object
            Name = "premiosCoberturaAcidentesPessoais";

            Field(x => x.IdPremiosCoberturaAcidentesPessoais, nullable: true);
            Field(x => x.CodPremiosCoberturaAcidentesPessoais, nullable: true);
            Field(x => x.CoberturaPlanoId, nullable: true);
            Field(x => x.NivelRiscoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Ordem, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Nota, nullable: true);
            FieldAsync<CoberturaPlanoType>("coberturaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaPlano>(c.Source.CoberturaPlanoId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            
        }
    }

    public class PremiosCoberturaAcidentesPessoaisInputType : InputObjectGraphType
	{
		public PremiosCoberturaAcidentesPessoaisInputType()
		{
			// Defining the name of the object
			Name = "premiosCoberturaAcidentesPessoaisInput";
			
            //Field<StringGraphType>("idPremiosCoberturaAcidentesPessoais");
			Field<StringGraphType>("codPremiosCoberturaAcidentesPessoais");
			Field<StringGraphType>("coberturaPlanoId");
			Field<StringGraphType>("nivelRiscoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("ordem");
			Field<FloatGraphType>("taxa");
			Field<StringGraphType>("nota");
			Field<CoberturaPlanoInputType>("coberturaPlano");
			Field<NivelRiscoInputType>("nivelRisco");
			
		}
	}
}