using System.Collections.Generic;

namespace ISS.Application.Dto
{
    /// <summary>
    /// Dto para albergar temporariamente os dados do motoristas.
    /// </summary>
    public class MotoristaDto : PessoaSingularDto
    {
        public bool Principal { get; set; }

        public IEnumerable<CartaConducaoDto> CartaConducaoDto { get; set; }
    }
}
