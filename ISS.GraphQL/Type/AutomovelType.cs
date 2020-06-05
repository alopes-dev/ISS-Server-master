using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AutomovelType : ObjectGraphType<Automovel>
    {
        public AutomovelType()
        {
            // Defining the name of the object
            Name = "automovel";

            Field(x => x.IdAutomovel, nullable: true);
            Field(x => x.TipoCaixaId, nullable: true);
            Field(x => x.ProprietarioId, nullable: true);
            Field(x => x.LadoVolanteId, nullable: true);
            Field(x => x.VelocidadeId, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.Detalhe, nullable: true);
            Field(x => x.NivelDesempenhoId, nullable: true);
            Field(x => x.PaisMatriculaId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.Matricula, nullable: true);
            Field(x => x.NumeroChassi, nullable: true);
            Field(x => x.ExemplarModeloId, nullable: true);
            Field(x => x.CilindragemAutomovelId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodAutomovel, nullable: true);
            Field(x => x.CorId, nullable: true);
            Field(x => x.InformacaoAdicionalId, nullable: true);
            Field(x => x.TipoMotorId, nullable: true);
            Field(x => x.TipoCorpoId, nullable: true);
            Field(x => x.DataPrimeiraMatricula, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorEmNovo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorActual, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ClassificacaoAutomovelId, nullable: true);
            Field(x => x.NumMotor, nullable: true);
            Field(x => x.DataUltimoSinistroParticipado, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoUsoId, nullable: true);
            Field(x => x.AnoConstrucao, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Potencia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumLugares, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.MoedaValorActualId, nullable: true);
            Field(x => x.TipoMatriculaId, nullable: true);
            Field(x => x.PesoBruto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PesoReboque, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Tara, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CilindragemAutomovelType>("cilindragemAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CilindragemAutomovel>(c.Source.CilindragemAutomovelId)));
            FieldAsync<ClassificacaoAutomovelType>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(c.Source.ClassificacaoAutomovelId)));
            FieldAsync<CorType>("cor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cor>(c.Source.CorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ExemplarModeloAutomovelType>("exemplarModelo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExemplarModeloAutomovel>(c.Source.ExemplarModeloId)));
            FieldAsync<InformacaoAdicionalType>("informacaoAdicional", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoAdicional>(c.Source.InformacaoAdicionalId)));
            FieldAsync<LadoVolanteType>("ladoVolante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LadoVolante>(c.Source.LadoVolanteId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<MoedaType>("moedaValorActual", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaValorActualId)));
            FieldAsync<NivelDesempenhoType>("nivelDesempenho", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelDesempenho>(c.Source.NivelDesempenhoId)));
            FieldAsync<PaisType>("paisMatricula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisMatriculaId)));
            FieldAsync<PessoaType>("proprietario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProprietarioId)));
            FieldAsync<TipoCaixaType>("tipoCaixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCaixa>(c.Source.TipoCaixaId)));
            FieldAsync<TipoCorpoType>("tipoCorpo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCorpo>(c.Source.TipoCorpoId)));
            FieldAsync<TipoMatriculaType>("tipoMatricula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoMatricula>(c.Source.TipoMatriculaId)));
            FieldAsync<TipoMotorType>("tipoMotor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoMotor>(c.Source.TipoMotorId)));
            FieldAsync<TipoUsoType>("tipoUso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoUso>(c.Source.TipoUsoId)));
            FieldAsync<VelocidadeType>("velocidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Velocidade>(c.Source.VelocidadeId)));
            FieldAsync<ListGraphType<AnexosAutomovelType>>("anexosAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AnexosAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<CaracteristicaAtutomovelType>>("caracteristicaAtutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaAtutomovel>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<DocumentosAutomovelType>>("documentosAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<GpsautomovelType>>("gpsautomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Gpsautomovel>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<ModificacaoType>>("modificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Modificacao>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<MotoristaType>>("motorista", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Motorista>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<MotoristaAutomovelType>>("motoristaAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MotoristaAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<ObjectoEnvolvidoType>>("objectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoEnvolvido>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<ObjectoSeguradoType>>("objectoSegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoSegurado>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<PneuType>>("pneu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pneu>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            FieldAsync<ListGraphType<RespostaPerguntaType>>("respostaPergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RespostaPergunta>(x => x.Where(e => e.HasValue(c.Source.IdAutomovel)))));
            
        }
    }

    public class AutomovelInputType : InputObjectGraphType
	{
		public AutomovelInputType()
		{
			// Defining the name of the object
			Name = "automovelInput";
			
            //Field<StringGraphType>("idAutomovel");
			Field<StringGraphType>("tipoCaixaId");
			Field<StringGraphType>("proprietarioId");
			Field<StringGraphType>("ladoVolanteId");
			Field<StringGraphType>("velocidadeId");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("detalhe");
			Field<StringGraphType>("nivelDesempenhoId");
			Field<StringGraphType>("paisMatriculaId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("matricula");
			Field<StringGraphType>("numeroChassi");
			Field<StringGraphType>("exemplarModeloId");
			Field<StringGraphType>("cilindragemAutomovelId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codAutomovel");
			Field<StringGraphType>("corId");
			Field<StringGraphType>("informacaoAdicionalId");
			Field<StringGraphType>("tipoMotorId");
			Field<StringGraphType>("tipoCorpoId");
			Field<DateTimeGraphType>("dataPrimeiraMatricula");
			Field<FloatGraphType>("valorEmNovo");
			Field<FloatGraphType>("valorActual");
			Field<StringGraphType>("classificacaoAutomovelId");
			Field<StringGraphType>("numMotor");
			Field<DateTimeGraphType>("dataUltimoSinistroParticipado");
			Field<StringGraphType>("tipoUsoId");
			Field<IntGraphType>("anoConstrucao");
			Field<FloatGraphType>("potencia");
			Field<IntGraphType>("numLugares");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("moedaValorActualId");
			Field<StringGraphType>("tipoMatriculaId");
			Field<FloatGraphType>("pesoBruto");
			Field<FloatGraphType>("pesoReboque");
			Field<FloatGraphType>("tara");
			Field<ApoliceInputType>("apolice");
			Field<CilindragemAutomovelInputType>("cilindragemAutomovel");
			Field<ClassificacaoAutomovelInputType>("classificacaoAutomovel");
			Field<CorInputType>("cor");
			Field<EstadoInputType>("estado");
			Field<ExemplarModeloAutomovelInputType>("exemplarModelo");
			Field<InformacaoAdicionalInputType>("informacaoAdicional");
			Field<LadoVolanteInputType>("ladoVolante");
			Field<MoedaInputType>("moeda");
			Field<MoedaInputType>("moedaValorActual");
			Field<NivelDesempenhoInputType>("nivelDesempenho");
			Field<PaisInputType>("paisMatricula");
			Field<PessoaInputType>("proprietario");
			Field<TipoCaixaInputType>("tipoCaixa");
			Field<TipoCorpoInputType>("tipoCorpo");
			Field<TipoMatriculaInputType>("tipoMatricula");
			Field<TipoMotorInputType>("tipoMotor");
			Field<TipoUsoInputType>("tipoUso");
			Field<VelocidadeInputType>("velocidade");
			Field<ListGraphType<AnexosAutomovelInputType>>("anexosAutomovel");
			Field<ListGraphType<CaracteristicaAtutomovelInputType>>("caracteristicaAtutomovel");
			Field<ListGraphType<DocumentosAutomovelInputType>>("documentosAutomovel");
			Field<ListGraphType<GpsautomovelInputType>>("gpsautomovel");
			Field<ListGraphType<ModificacaoInputType>>("modificacao");
			Field<ListGraphType<MotoristaInputType>>("motorista");
			Field<ListGraphType<MotoristaAutomovelInputType>>("motoristaAutomovel");
			Field<ListGraphType<ObjectoEnvolvidoInputType>>("objectoEnvolvido");
			Field<ListGraphType<ObjectoSeguradoInputType>>("objectoSegurado");
			Field<ListGraphType<PneuInputType>>("pneu");
			Field<ListGraphType<RespostaPerguntaInputType>>("respostaPergunta");
			
		}
	}
}