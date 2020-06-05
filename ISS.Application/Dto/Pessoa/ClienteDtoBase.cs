
using System.ComponentModel.DataAnnotations;

namespace ISS.Application.Dto.Pessoa
{
    public class ClienteDtoBase : PessoaDtoBase
    {

        [Required(ErrorMessage = "O campo  Preferencia é Obrigatorio")]
        public bool? Preferencias { get; set; }
        [Required(ErrorMessage = "O campo  Tipo Cliente é Obrigatorio")]
        public string TipoCliente { get; set; }
        public string TipoClienteId { get; set; }
        [Required(ErrorMessage = "O campo  Fidelizacao é Obrigatorio")]
        public string Fidelizacao { get; set; }
        public string FidelizacaoId { get; set; }
        [Required(ErrorMessage = "O campo  Numero de Ordem Cliente é Obrigatorio")]
        public long NumOrdemCliente { get; set; }
    }
}
