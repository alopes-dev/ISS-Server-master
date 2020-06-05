using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ViagemType : ObjectGraphType<Viagem>
    {
        public ViagemType()
        {
            // Defining the name of the object
            Name = "viagem";

            Field(x => x.IdDadosViagem, nullable: true);
            Field(x => x.PaisOrigemId, nullable: true);
            Field(x => x.PaisDestinoId, nullable: true);
            Field(x => x.MeioTransporteId, nullable: true);
            Field(x => x.DataCompraBilhete, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CompanhiaViagemId, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.PeriodoPlanoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.ProvinciaOrigemId, nullable: true);
            Field(x => x.ProvinciaDestinoId, nullable: true);
            FieldAsync<CompanhiaViagemType>("companhiaViagem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CompanhiaViagem>(c.Source.CompanhiaViagemId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MeioTransporteType>("meioTransporte", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MeioTransporte>(c.Source.MeioTransporteId)));
            FieldAsync<PaisType>("paisDestino", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisDestinoId)));
            FieldAsync<PaisType>("paisOrigem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisOrigemId)));
            FieldAsync<PeriodoPlanoType>("periodoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoPlano>(c.Source.PeriodoPlanoId)));
            FieldAsync<ProvinciaType>("provinciaDestino", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(c.Source.ProvinciaDestinoId)));
            FieldAsync<ProvinciaType>("provinciaOrigem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(c.Source.ProvinciaOrigemId)));
            
        }
    }

    public class ViagemInputType : InputObjectGraphType
	{
		public ViagemInputType()
		{
			// Defining the name of the object
			Name = "viagemInput";
			
            //Field<StringGraphType>("idDadosViagem");
			Field<StringGraphType>("paisOrigemId");
			Field<StringGraphType>("paisDestinoId");
			Field<StringGraphType>("meioTransporteId");
			Field<DateTimeGraphType>("dataCompraBilhete");
			Field<StringGraphType>("companhiaViagemId");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("periodoPlanoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("provinciaOrigemId");
			Field<StringGraphType>("provinciaDestinoId");
			Field<CompanhiaViagemInputType>("companhiaViagem");
			Field<CotacaoInputType>("cotacao");
			Field<EstadoInputType>("estado");
			Field<MeioTransporteInputType>("meioTransporte");
			Field<PaisInputType>("paisDestino");
			Field<PaisInputType>("paisOrigem");
			Field<PeriodoPlanoInputType>("periodoPlano");
			Field<ProvinciaInputType>("provinciaDestino");
			Field<ProvinciaInputType>("provinciaOrigem");
			
		}
	}
}