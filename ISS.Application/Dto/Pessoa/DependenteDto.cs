namespace ISS.Application.Dto
{
    /// <summary>
    /// Dto para albergar temporariamento os dados de um dependente.
    /// </summary>
    public class DependenteDto : PessoaSingularDto
    {
        public string Designacao { get; set; }
        public string GrauParentescoId { get; set; }
        public string GrauParentesco { get; set; }
    }
}
