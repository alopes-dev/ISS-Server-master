namespace ISS.Application.Dto
{
    public class PapelDtoBase
    {
        public virtual string PapelId { get; set; }
        public bool? Contabiliza { get; set; }
    }

    public class PapelDto : PapelDtoBase
    {
        public string IdPapelPessoa { get; private set; }
        public string Designacao { get; private set; }
        public string CodPapelPessoa { get; private set; }
    }
}