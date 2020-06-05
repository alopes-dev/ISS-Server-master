using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GarantiasContratadasType : ObjectGraphType<GarantiasContratadas>
    {
        public GarantiasContratadasType()
        {
            // Defining the name of the object
            Name = "garantiasContratadas";

            Field(x => x.IdGarantiasContratadas, nullable: true);
            Field(x => x.CodGarantiasContratadas, nullable: true);
            Field(x => x.PeriodoCarencia, nullable: true, type: typeof(IntGraphType));
            Field(x => x.LimiteAnualIntervencoes, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SublimiteDespesasFuneral, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FranquiaPessoaSeguraePorSinistro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PeriodoCarenciaInternamento, nullable: true, type: typeof(IntGraphType));
            Field(x => x.SubsidioDiario, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ComparticipacaoDespesas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FranquiaAbsolutaPorEmbalagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FranquiaAbsolutaPorReceita, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FranquiaRelativa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LimiteIndemnizacaoPartoNormal, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LimiteIndemnizacaoCesariana, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LimiteIndemnizacaoInterrupcaoEsponstanea, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Incluida, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class GarantiasContratadasInputType : InputObjectGraphType
	{
		public GarantiasContratadasInputType()
		{
			// Defining the name of the object
			Name = "garantiasContratadasInput";
			
            //Field<StringGraphType>("idGarantiasContratadas");
			Field<StringGraphType>("codGarantiasContratadas");
			Field<IntGraphType>("periodoCarencia");
			Field<FloatGraphType>("limiteAnualIntervencoes");
			Field<FloatGraphType>("sublimiteDespesasFuneral");
			Field<FloatGraphType>("franquiaPessoaSeguraePorSinistro");
			Field<IntGraphType>("periodoCarenciaInternamento");
			Field<FloatGraphType>("subsidioDiario");
			Field<FloatGraphType>("comparticipacaoDespesas");
			Field<FloatGraphType>("franquiaAbsolutaPorEmbalagem");
			Field<FloatGraphType>("franquiaAbsolutaPorReceita");
			Field<FloatGraphType>("franquiaRelativa");
			Field<FloatGraphType>("limiteIndemnizacaoPartoNormal");
			Field<FloatGraphType>("limiteIndemnizacaoCesariana");
			Field<FloatGraphType>("limiteIndemnizacaoInterrupcaoEsponstanea");
			Field<BooleanGraphType>("incluida");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}