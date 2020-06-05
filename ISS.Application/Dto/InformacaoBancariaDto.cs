using System.Collections.Generic;

namespace ISS.Application.Dto
{
    public class InformacaoBancariaDtoBase
    {
        public string IdInformacaoBancaria { get; set; }
        public string NumConta { get; set; }
        public string Iban { get; set; }
        public string SwiftCode { get; set; }
        public string NomeBancoId { get; set; }
        public string NomeBanco { get; set; }
        public string Estado { get; set; }
        public string CaminhoFicheiro { get; set; }
        public string Nib { get; set; }
        public string EstadoId { get; set; }
        public string CodInformacaoBancaria { get; set; }

        public IEnumerable<CartaoCreditoDto> CartoesCredito { get; set; }
    }

    public class InformacaoBancariaDto : InformacaoBancariaDtoBase
    {
        public EnderecoDtoBase EnderecoBanco { get; set; }
    }
}
