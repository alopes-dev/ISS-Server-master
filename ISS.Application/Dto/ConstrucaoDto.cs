using System;
using System.ComponentModel.DataAnnotations;

namespace ISS.Application.Dto
{
    public partial class ConstrucaoDto
    {
        public string IdConstrucao { get; set; }
        public DateTime? DataInicioConstrucao { get; set; }
        public DateTime? DataFimConstrucao { get; set; }
        public DateTime? DataEmissaoPermissaoConstrucao { get; set; }
        public string Designacao { get; set; }
        public DateTime? DataRenovacao { get; set; }
        public double? ValorCustoConstrucao { get; set; }
        public DateTime? DataHoraCompra { get; set; }
        public DateTime? DataHoraVigencia { get; set; }
        public DateTime? DataValidade { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? PercentagemAdquirida { get; set; }
        public string EnderecoId { get; set; }
        public string TipoPropriedadeId { get; set; }
        public string ProprietarioId { get; set; }
        public string TipoMaterialConstrucaoId { get; set; }
        public byte? NumAndares { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumApartamentos { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumQuartos { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumQuartosVisitas { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumQuartosBanho { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumSalas { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumChamines { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumCaves { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumPiscinas { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumEscadaRolante { get; set; }
        public bool? Antena { get; set; }
        public bool? Cave { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? PercentagemCompletudePredio { get; set; }
        public DateTime? DataEstimativaCompletude { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumElevadores { get; set; }
        public bool? Modificado { get; set; }
        public bool? SinalDanoEstrutural { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumMaximoVeiculos { get; set; }
        public string TipoInstalacaoElectricaId { get; set; }
        public bool? VidrosResistenteFuracao { get; set; }
        public string MedidaAreaPredio { get; set; }
        public string CaminhoPlanta { get; set; }
        public string CotacaoId { get; set; }
        public string TipoCasaId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string ApoliceId { get; set; }

        public virtual EnderecoDto EnderecoDto { get; set; }
        public virtual TipoCasaDto TipoCasaDto { get; set; }
        public virtual TipoInstalacaoElectricaDto TipoInstalacaoElectricaDto { get; set; }
        public virtual TipoMaterialConstrucaoDto TipoMaterialConstrucaoDto { get; set; }
        public virtual TipoPropriedadeDto TipoPropriedadeDto { get; set; }
        public virtual CaracteristicasConstrucaoDto CaracteristicasConstrucaoDto { get; set; }
        public virtual DimensaoConstrucaoDto DimensaoConstrucaoDto { get; set; }
        public virtual ImagensConstrucaoDto ImagensConstrucaoDto { get; set; }
        public virtual ObjectoEnvolvidoDto ObjectoEnvolvidoDto { get; set; }
        public virtual SistemaAquecimentoDto SistemaAquecimentoDto { get; set; }
    }

    public partial class SistemaAquecimentoDto
    {
        public string IdSistemaAquecimento { get; set; }
        public bool? TermostaticamenteControlado { get; set; }
        public string AreaAquecida { get; set; }
        public DateTime? DataHoraInstalacao { get; set; }
        public bool? Certificado { get; set; }
        public string MetodoSistemaAquecimentoId { get; set; }
        public string CombustivelId { get; set; }
        public string ConstrucaoId { get; set; }
        public string CodSistemaAquecimento { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual CombustivelDto CombustivelDto { get; set; }
        public virtual ConstrucaoDto ConstrucaoDto { get; set; }
        public virtual MetodoSistemaAquecimentoDto MetodoSistemaAquecimentoDto { get; set; }
    }

    public partial class MetodoSistemaAquecimentoDto
    {
        public string IdMetodoSistemaAquecimento { get; set; }
        public string Designacao { get; set; }
        public string CodMetodoSistemaAquecimento { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual SistemaAquecimentoDto SistemaAquecimentoDto { get; set; }
    }

    public partial class CombustivelDto
    {
        public string IdCombustivel { get; set; }
        public string Designacao { get; set; }
        public string CodCombustivel { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual ExemplarModeloAutomovelDto ExemplarModeloAutomovelDto { get; set; }
        public virtual SistemaAquecimentoDto SistemaAquecimentoDto { get; set; }
    }

    public partial class ExemplarModeloAutomovelDto
    {
        public string IdExemplar { get; set; }
        public string Nome { get; set; }
        public string Referencia { get; set; }
        public int? AnoFabrico { get; set; }
        public string ModeloAutomovelId { get; set; }
        public string CombustivelId { get; set; }
        public string CodExemplarModeloAutomovel { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual CombustivelDto CombustivelDto { get; set; }
        public virtual ModeloAutomovelDto ModeloAutomovelDto { get; set; }
        public virtual AutomovelDto AutomovelDto { get; set; }
    }

    public partial class ObjectoEnvolvidoDto
    {
        public string IdObjectoEnvolvido { get; set; }
        public string Designacao { get; set; }
        public double? AvaliacaoValor { get; set; }
        public string InicioPontoEmbate { get; set; }
        public string DanosVisiveis { get; set; }
        public string TipoObjectoEnvolvidoId { get; set; }
        public string NomeCompanhiaSeguradoraId { get; set; }
        public string AutomovelId { get; set; }
        public string ConstrucaoId { get; set; }
        public string DonoId { get; set; }
        public string SinistroId { get; set; }
        public string DetalheCircunstancia { get; set; }
        public bool? Proprio { get; set; }
        public string CondutorSinistroId { get; set; }
        public string QuestionarioId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }

    public partial class CondutorSinistroDto
    {
        public string IdCondutor { get; set; }
        public bool? CondutorHabitual { get; set; }
        public bool? SeguroCarta { get; set; }
        public string NumApolice { get; set; }
        public string NomeCompanhiaSeguradoraId { get; set; }
        public string PessoaId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }

    public partial class ImagensConstrucaoDto
    {
        public string IdImagensPredio { get; set; }
        public string CaminhoImagemConstrucao { get; set; }
        public string ConstrucaoId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }

    public partial class DimensaoConstrucaoDto
    {
        public string IdDimensaoConstrucao { get; set; }
        public string Dimensao { get; set; }
        public string Comprimento { get; set; }
        public string Largura { get; set; }
        public string Altura { get; set; }
        public string Profundidade { get; set; }
        public string ConstrucaoId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }

    public partial class CaracteristicasConstrucaoDto
    {
        public string IdCaracteristicasConstrucao { get; set; }
        public string DimensaoOcupadaPeloSegurado { get; set; }
        public string UtilidadePredio { get; set; }
        public bool? ReparacaoTerreno { get; set; }
        public int? NumSalasUsadaNegocio { get; set; }
        public bool? ClientesNegocioVisitaPropriedade { get; set; }
        public string DescricaoNegocio { get; set; }
        public bool? BensGuardadosPropriedade { get; set; }
        public bool? PossuiGuarda { get; set; }
        public bool? Alarme { get; set; }
        public byte? NumeroPisosOcupados { get; set; }
        public bool? SinalDefeito { get; set; }
        public bool? AlgumaAreaArrendada { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public int? NumVeiculoGaragem { get; set; }
        public bool? EntradaBloqueavelSeparada { get; set; }
        public DateTime? DataUltimaInspecaoCabos { get; set; }
        public string ConstrucaoId { get; set; }
        public string CodCaracteristicasConstrucao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual CofreDto CofreDto { get; set; }
    }

    public partial class CofreDto
    {
        public string IdCofre { get; set; }
        public bool? TimeLock { get; set; }
        public bool? RelockingDevice { get; set; }
        public bool? Alarme { get; set; }
        public string NumSerial { get; set; }
        public string ConteudoCofre { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? Altura { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? Largura { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? Comprimento { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? Peso { get; set; }
        public string Fabricante { get; set; }
        public string ClasseCofreId { get; set; }
        public string TipoCofreId { get; set; }
        public string CaracteristicasConstrucaoId { get; set; }
        public string CodCofre { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }

    public partial class TipoCasaDto
    {
        public string IdTipoCasa { get; set; }
        public string Designacao { get; set; }
        public string CodTipoCasa { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual ConstrucaoDto ConstrucaoDto { get; set; }
    }

    public partial class TipoInstalacaoElectricaDto
    {
        public string IdTipoInstalacaoElectrica { get; set; }
        public string Designacao { get; set; }
        public string CodTipoInstalacaoElectrica { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual ConstrucaoDto ConstrucaoDto { get; set; }

    }

    public partial class TipoMaterialConstrucaoDto
    {
        public string IdTipoMaterialConstrucao { get; set; }
        public string Designacao { get; set; }
        public string CodTipoMaterialConstrucao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual ConstrucaoDto ConstrucaoDto { get; set; }
    }

    public partial class TipoPropriedadeDto
    {
        public string IdTipoPropriedade { get; set; }
        public string Designacao { get; set; }
        public string CodTipoPropriedade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual ConstrucaoDto ConstrucaoDto { get; set; }
    }


}