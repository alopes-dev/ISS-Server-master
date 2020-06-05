using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ConstrucaoType : ObjectGraphType<Construcao>
    {
        public ConstrucaoType()
        {
            // Defining the name of the object
            Name = "construcao";

            Field(x => x.IdConstrucao, nullable: true);
            Field(x => x.DataInicioConstrucao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFimConstrucao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataEmissaoPermissaoConstrucao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataRenovacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorCustoConstrucao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataHoraCompra, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataHoraVigencia, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataValidade, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PercentagemAdquirida, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.TipoPropriedadeId, nullable: true);
            Field(x => x.ProprietarioId, nullable: true);
            Field(x => x.TipoMaterialConstrucaoId, nullable: true);
            //FieldAsync<ByteType>("numAndares", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Byte>(c.Source.IdConstrucao)));
            Field(x => x.NumApartamentos, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumQuartos, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumQuartosVisitas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumQuartosBanho, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumSalas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumChamines, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumCaves, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumPiscinas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumEscadaRolante, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Antena, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Cave, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PercentagemCompletudePredio, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataEstimativaCompletude, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NumElevadores, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Modificado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.SinalDanoEstrutural, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.NumMaximoVeiculos, nullable: true, type: typeof(IntGraphType));
            Field(x => x.TipoInstalacaoElectricaId, nullable: true);
            Field(x => x.VidrosResistenteFuracao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.MedidaAreaPredio, nullable: true);
            Field(x => x.CaminhoPlanta, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.TipoCasaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodConstrucao, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("proprietario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProprietarioId)));
            FieldAsync<TipoCasaType>("tipoCasa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCasa>(c.Source.TipoCasaId)));
            FieldAsync<TipoInstalacaoElectricaType>("tipoInstalacaoElectrica", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoInstalacaoElectrica>(c.Source.TipoInstalacaoElectricaId)));
            FieldAsync<TipoMaterialConstrucaoType>("tipoMaterialConstrucao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoMaterialConstrucao>(c.Source.TipoMaterialConstrucaoId)));
            FieldAsync<TipoPropriedadeType>("tipoPropriedade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPropriedade>(c.Source.TipoPropriedadeId)));
            FieldAsync<ListGraphType<CaracteristicasConstrucaoType>>("caracteristicasConstrucao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicasConstrucao>(x => x.Where(e => e.HasValue(c.Source.IdConstrucao)))));
            FieldAsync<ListGraphType<DimensaoConstrucaoType>>("dimensaoConstrucao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DimensaoConstrucao>(x => x.Where(e => e.HasValue(c.Source.IdConstrucao)))));
            FieldAsync<ListGraphType<ImagensConstrucaoType>>("imagensConstrucao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImagensConstrucao>(x => x.Where(e => e.HasValue(c.Source.IdConstrucao)))));
            FieldAsync<ListGraphType<ObjectoEnvolvidoType>>("objectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoEnvolvido>(x => x.Where(e => e.HasValue(c.Source.IdConstrucao)))));
            FieldAsync<ListGraphType<SistemaAquecimentoType>>("sistemaAquecimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SistemaAquecimento>(x => x.Where(e => e.HasValue(c.Source.IdConstrucao)))));
            
        }
    }

    public class ConstrucaoInputType : InputObjectGraphType
	{
		public ConstrucaoInputType()
		{
			// Defining the name of the object
			Name = "construcaoInput";
			
            //Field<StringGraphType>("idConstrucao");
			Field<DateTimeGraphType>("dataInicioConstrucao");
			Field<DateTimeGraphType>("dataFimConstrucao");
			Field<DateTimeGraphType>("dataEmissaoPermissaoConstrucao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataRenovacao");
			Field<FloatGraphType>("valorCustoConstrucao");
			Field<DateTimeGraphType>("dataHoraCompra");
			Field<DateTimeGraphType>("dataHoraVigencia");
			Field<DateTimeGraphType>("dataValidade");
			Field<FloatGraphType>("percentagemAdquirida");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("tipoPropriedadeId");
			Field<StringGraphType>("proprietarioId");
			Field<StringGraphType>("tipoMaterialConstrucaoId");
			//Field<ByteInputType>("numAndares");
			Field<IntGraphType>("numApartamentos");
			Field<IntGraphType>("numQuartos");
			Field<IntGraphType>("numQuartosVisitas");
			Field<IntGraphType>("numQuartosBanho");
			Field<IntGraphType>("numSalas");
			Field<IntGraphType>("numChamines");
			Field<IntGraphType>("numCaves");
			Field<IntGraphType>("numPiscinas");
			Field<IntGraphType>("numEscadaRolante");
			Field<BooleanGraphType>("antena");
			Field<BooleanGraphType>("cave");
			Field<FloatGraphType>("percentagemCompletudePredio");
			Field<DateTimeGraphType>("dataEstimativaCompletude");
			Field<IntGraphType>("numElevadores");
			Field<BooleanGraphType>("modificado");
			Field<BooleanGraphType>("sinalDanoEstrutural");
			Field<IntGraphType>("numMaximoVeiculos");
			Field<StringGraphType>("tipoInstalacaoElectricaId");
			Field<BooleanGraphType>("vidrosResistenteFuracao");
			Field<StringGraphType>("medidaAreaPredio");
			Field<StringGraphType>("caminhoPlanta");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("tipoCasaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("apoliceId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codConstrucao");
			Field<ApoliceInputType>("apolice");
			Field<CotacaoInputType>("cotacao");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("proprietario");
			Field<TipoCasaInputType>("tipoCasa");
			Field<TipoInstalacaoElectricaInputType>("tipoInstalacaoElectrica");
			Field<TipoMaterialConstrucaoInputType>("tipoMaterialConstrucao");
			Field<TipoPropriedadeInputType>("tipoPropriedade");
			Field<ListGraphType<CaracteristicasConstrucaoInputType>>("caracteristicasConstrucao");
			Field<ListGraphType<DimensaoConstrucaoInputType>>("dimensaoConstrucao");
			Field<ListGraphType<ImagensConstrucaoInputType>>("imagensConstrucao");
			Field<ListGraphType<ObjectoEnvolvidoInputType>>("objectoEnvolvido");
			Field<ListGraphType<SistemaAquecimentoInputType>>("sistemaAquecimento");
			
		}
	}
}