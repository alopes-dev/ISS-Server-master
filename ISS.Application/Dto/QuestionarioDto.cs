using System.ComponentModel.DataAnnotations;

namespace ISS.Application.Dto
{
    /// <summary>
    /// Objecto para albergar as respostas.
    /// </summary>
    public class QuestionarioDto
    {
        [StringLength(50)]
        [Required]
        public string PerguntaId { get; set; }
        public string Resposta { get; set; }
        public string Detalhes { get; set; }
        public string ItemPerguntaId { get; set; }
    }
}