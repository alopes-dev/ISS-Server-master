namespace ISS.Application.Dto
{
    public class ContactoDto
    {
        public string IdContacto { get; set; }
        public bool? Principal { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public string Telemovel { get; set; }
        //[RegularExpression(@"^[0-9]{9}", ErrorMessage = "O campo nif so aceita valor do tipo 999999999")]
        public string Telefone { get; set; }
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email invalido. por favor insira um email valido.")]
        public string Email { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }
        public string TipoContactoId { get; set; }
        public string TipoContacto { get; set; }
        public string PaisId { get; set; }
        public string Pais { get; set; }
        public string Indicativo { get; set; }
        public string CaminhoImagem { get; set; }
    }
}
