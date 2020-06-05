using System;

namespace ISS.Application.Dto
{
    public class CartaoCreditoDto
    {
        public string IdCartaoCredito { get; set; }
        public string NomeCartao { get; set; }
        public int? NumeroCartao { get; set; }
        public string Estado { get; set; }
        public string EstadoId { get; set; }
        public string CodCartaoCredito { get; set; }
        public DateTime? DataExpiracao { get; set; }
    }
}
