using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoSeguroType : ObjectGraphType<CoSeguro>
    {
        public CoSeguroType()
        {
            // Defining the name of the object
            Name = "coSeguro";

            Field(x => x.IdCoSeguro, nullable: true);
            Field(x => x.PercentagemCoAssegurada, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DocumentoDigitalizado, nullable: true);
            Field(x => x.ValorTaxaGestao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.QuotaParte, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FormaTransmissaoInformacaoId, nullable: true);
            Field(x => x.TipoCosseguroId, nullable: true);
            Field(x => x.SistemaLiquidacaoSinistroId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CompanhiaCoAsseguradoraId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodCoSeguro, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<PessoaType>("companhiaCoAsseguradora", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.CompanhiaCoAsseguradoraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoViaNotificacaoType>("formaTransmissaoInformacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoViaNotificacao>(c.Source.FormaTransmissaoInformacaoId)));
            FieldAsync<SistemaLiquidacaoSinistroType>("sistemaLiquidacaoSinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SistemaLiquidacaoSinistro>(c.Source.SistemaLiquidacaoSinistroId)));
            FieldAsync<TipoCosseguroType>("tipoCosseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCosseguro>(c.Source.TipoCosseguroId)));
            FieldAsync<ListGraphType<CoberturaCosseguroType>>("coberturaCosseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaCosseguro>(x => x.Where(e => e.HasValue(c.Source.IdCoSeguro)))));
            FieldAsync<ListGraphType<CondicoesCoSeguroType>>("condicoesCoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicoesCoSeguro>(x => x.Where(e => e.HasValue(c.Source.IdCoSeguro)))));
            
        }
    }

    public class CoSeguroInputType : InputObjectGraphType
	{
		public CoSeguroInputType()
		{
			// Defining the name of the object
			Name = "coSeguroInput";
			
            //Field<StringGraphType>("idCoSeguro");
			Field<FloatGraphType>("percentagemCoAssegurada");
			Field<StringGraphType>("documentoDigitalizado");
			Field<FloatGraphType>("valorTaxaGestao");
			Field<FloatGraphType>("quotaParte");
			Field<StringGraphType>("formaTransmissaoInformacaoId");
			Field<StringGraphType>("tipoCosseguroId");
			Field<StringGraphType>("sistemaLiquidacaoSinistroId");
			Field<StringGraphType>("apoliceId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("companhiaCoAsseguradoraId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codCoSeguro");
			Field<ApoliceInputType>("apolice");
			Field<PessoaInputType>("companhiaCoAsseguradora");
			Field<EstadoInputType>("estado");
			Field<TipoViaNotificacaoInputType>("formaTransmissaoInformacao");
			Field<SistemaLiquidacaoSinistroInputType>("sistemaLiquidacaoSinistro");
			Field<TipoCosseguroInputType>("tipoCosseguro");
			Field<ListGraphType<CoberturaCosseguroInputType>>("coberturaCosseguro");
			Field<ListGraphType<CondicoesCoSeguroInputType>>("condicoesCoSeguro");
			
		}
	}
}