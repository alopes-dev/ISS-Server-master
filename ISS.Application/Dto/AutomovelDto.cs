using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISS.Application.Dto
{
    /// <summary>
    /// Dto para albergar temporariamente os dados sobre o automóvel.
    /// </summary>
    public class AutomovelDto
    {
        public string IdAutomovel { get; set; }
        [Required(ErrorMessage = "O campo Comprimento é Obrigatorio")]
        public double? Comprimento { get; set; }
        [Required(ErrorMessage = "O campo Peso Bruto é Obrigatorio")]
        public double? PesoBruto { get; set; }
        [Required(ErrorMessage = "O campo Largura é Obrigatorio")]
        public double? Largura { get; set; }
        [Required(ErrorMessage = "O campo Altura é Obrigatorio")]
        public double? Altura { get; set; }
        public byte? NumAirbags { get; set; }
        [Required(ErrorMessage = "O campo Distancia Entre Eixos é Obrigatorio")]

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? DistanciaEntreEixos { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        [Required(ErrorMessage = "O campo Numero do Lugar é Obrigatorio")]
        public int? NumLugares { get; set; }
        [Required(ErrorMessage = "O campo Modificado é Obrigatorio")]
        public bool? Modificado { get; set; }
        [Required(ErrorMessage = "O campo Garangem é Obrigatorio")]
        public bool? Garagem { get; set; }
        [Required(ErrorMessage = "O campo Alarme é Obrigatorio")]
        public bool? Alarme { get; set; }
        [Required(ErrorMessage = "O campo Numero do Motor é Obrigatorio")]
        public string NumeroMotor { get; set; }
        public string CorId { get; set; }
        public string TipoCaixaId { get; set; }
        public string QualidadeEmQueSeguraId { get; set; }
        public string PessoaFavorecidaId { get; set; }
        public string ProprietarioId { get; set; }
        public string TipoPinturaId { get; set; }
        public string TransmissaoId { get; set; }
        public string CategoriaAutomovelId { get; set; }
        public string LadoVolanteId { get; set; }
        public string VelocidadeId { get; set; }
        public string CotacaoId { get; set; }
        public string ApoliceId { get; set; }
        public string Detalhe { get; set; }
        public string NivelDesempenhoId { get; set; }
        public string DescricaoCondicao { get; set; }
        public string PaisMatriculaId { get; set; }
        [Required(ErrorMessage = "O campo Potencia é Obrigatorio")]

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? Potencia { get; set; }
        [Required(ErrorMessage = "O campo Valor Em Novo é Obrigatorio")]

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? ValorEmNovo { get; set; }
        public string MoedaId { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        [Required(ErrorMessage = "O campo Valor Actual é Obrigatorio")]
        [DisplayFormat(DataFormatString = "{0,c}")]
        public double? ValorActual { get; set; }
        [Required(ErrorMessage = "O campo  Matricula é Obrigatorio")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "O campo  Numero de Chassi é Obrigatorio")]
        public string NumeroChassi { get; set; }
        public string TipoGaragemId { get; set; }
        public string ExemplarModeloId { get; set; }
        [Required(ErrorMessage = "O campo  Numero da Portas  é Obrigatorio")]
        public byte? NumPortas { get; set; }
        [Required(ErrorMessage = "O campo  Codigo Automovel é Obrigatorio")]
        public string CodAutomovel { get; set; }
        public string CilindragemAutomovelId { get; set; }
        [Required(ErrorMessage = "O campo  Motorista é Obrigatorio")]
        public IEnumerable<MotoristaDto> MotoristasDto { get; set; }
    }
}
