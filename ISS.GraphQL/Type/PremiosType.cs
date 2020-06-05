using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PremiosType : ObjectGraphType<Premios>
    {
        public PremiosType()
        {
            // Defining the name of the object
            Name = "premios";

            Field(x => x.IdPremio, nullable: true);
            Field(x => x.Titulo, nullable: true);
            Field(x => x.Conteudo, nullable: true);
            Field(x => x.Risco1, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco2, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco3, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.NivelRiscoId, nullable: true);
            Field(x => x.CodPremios, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Localidade, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            
        }
    }

    public class PremiosInputType : InputObjectGraphType
	{
		public PremiosInputType()
		{
			// Defining the name of the object
			Name = "premiosInput";
			
            //Field<StringGraphType>("idPremio");
			Field<StringGraphType>("titulo");
			Field<StringGraphType>("conteudo");
			Field<FloatGraphType>("risco1");
			Field<FloatGraphType>("risco2");
			Field<FloatGraphType>("risco3");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("nivelRiscoId");
			Field<StringGraphType>("codPremios");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("localidade");
			Field<EstadoInputType>("estado");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<PlanoContasInputType>("subConta");
			
		}
	}
}