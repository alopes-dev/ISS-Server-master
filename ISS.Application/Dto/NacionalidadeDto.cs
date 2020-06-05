namespace ISS.Application.Dto
{
    /// <summary>
    /// Dto para abergar temporáriamente os dados da nacionalidade da pessoa.
    /// </summary>
    public class NacionalidadeDto
    {
        public string IdNacionalidadePessoa { get; set; }
        public bool? Principal { get; set; }
        public string NacionalidadeId { get; set; }
        public string NomePais { get; set; }
    }
}
