using System;

namespace ISS.Application.Dto
{
    public class CartaConducaoDto
    {
        public string IdCartaConducao { get; set; }
        public string NumLicenca { get; set; }
        public DateTime? DataEmissao { get; set; }
        public DateTime? DataPrimeiraEmissao { get; set; }
        public DateTime? DataValidade { get; set; }
        public string CaminhoFicheiro { get; set; }
        public string CaminhoAssinatura { get; set; }
        public string RestricoesPessoaisCartaConducaoId { get; set; }
        public string RestricoesCategoriasCartaConducaoId { get; set; }
        public string RestricoesViaturaCartaConducaoId { get; set; }
        public string TipoCartaConducaoId { get; set; }
        public string PessoaId { get; set; }
        public string EntidadeEmissoraId { get; set; }
        public string EstadoId { get; set; }
    }
}