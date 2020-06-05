using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicaoOperacaoType : ObjectGraphType<CondicaoOperacao>
    {
        public CondicaoOperacaoType()
        {
            // Defining the name of the object
            Name = "condicaoOperacao";

            Field(x => x.IdCondicaoOperacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.OperacaoId, nullable: true);
            Field(x => x.CodCondicaoOperacao, nullable: true);
            Field(x => x.NivelAbrangenciaId, nullable: true);
            Field(x => x.ValorMaxPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMinPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumDias, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PapelId, nullable: true);
            Field(x => x.LimiteMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LimiteMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumDiasMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumDiasMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.LocalAplicacaoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<EnderecoType>("localAplicacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.LocalAplicacaoId)));
            FieldAsync<NivelAbrangenciaType>("nivelAbrangencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelAbrangencia>(c.Source.NivelAbrangenciaId)));
            FieldAsync<OperacaoType>("operacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Operacao>(c.Source.OperacaoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            
        }
    }

    public class CondicaoOperacaoInputType : InputObjectGraphType
	{
		public CondicaoOperacaoInputType()
		{
			// Defining the name of the object
			Name = "condicaoOperacaoInput";
			
            //Field<StringGraphType>("idCondicaoOperacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("operacaoId");
			Field<StringGraphType>("codCondicaoOperacao");
			Field<StringGraphType>("nivelAbrangenciaId");
			Field<FloatGraphType>("valorMaxPremioSimples");
			Field<FloatGraphType>("valorMinPremioSimples");
			Field<FloatGraphType>("taxa");
			Field<IntGraphType>("numDias");
			Field<StringGraphType>("papelId");
			Field<FloatGraphType>("limiteMax");
			Field<FloatGraphType>("limiteMin");
			Field<IntGraphType>("numDiasMax");
			Field<IntGraphType>("numDiasMin");
			Field<StringGraphType>("localAplicacaoId");
			Field<StringGraphType>("canalId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<CanalInputType>("canal");
			Field<EstadoInputType>("estado");
			Field<EnderecoInputType>("localAplicacao");
			Field<NivelAbrangenciaInputType>("nivelAbrangencia");
			Field<OperacaoInputType>("operacao");
			Field<PapelInputType>("papel");
			
		}
	}
}