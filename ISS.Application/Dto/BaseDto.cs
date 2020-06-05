
using System.ComponentModel.DataAnnotations;
namespace ISS.Application.Dto
{
    /// <summary>
    /// Objecto base transporte de informações básicas.
    /// </summary>
    public class BaseDto
    {
        /// <summary>
        /// Id do objecto.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Descrição do objecto.
        /// </summary>
        [Required(ErrorMessage = "O campo Designacao é Obrigatorio ")]
        public string Designacao { get; set; }

        /// <summary>
        /// Codigo do objecto.
        /// </summary>
        [Required(ErrorMessage = "O campo Codigo é Obrigatorio ")]
        public string Codigo { get; set; }
    }
}
