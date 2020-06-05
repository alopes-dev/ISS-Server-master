using System.ComponentModel.DataAnnotations;
namespace ISS.Application.Dto
{
    public class CoberturaSeleccionadaDtoBase
    {
        public string CoberturaProdutoId { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? PorAnuidade { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? PorCadaSinistro { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? PorCadaPessoaSinistrada { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? PorDanosCoisasAnimais { get; set; }
        public bool? Personalizado { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? ValorPersonalizado { get; set; }

        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Números negativo nao sao permitido.")]
        public double? CoPagamento { get; set; }
    }

    public class CoberturaSeleccionadaDto : CoberturaSeleccionadaDtoBase
    {
        public string IdCoberturaSeleccionada { get; set; }
        public string CotacaoId { get; set; }
        public string ApoliceId { get; set; }
    }
}
