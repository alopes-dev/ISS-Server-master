using System;

namespace ISS.Application.Dto
{
    public class EnderecoDtoBase
    {
        public string IdEndereco { get; set; }
        public string MunicipioId { get; set; }
        public string Municipio { get; set; }
        public string BairroId { get; set; }
        public string Bairro { get; set; }
        public string RuaId { get; set; }
        public string Rua { get; set; }
        public string DistritoId { get; set; }
        public string Distrito { get; set; }
        public string CaixaPostal { get; set; }
        public string NumCasa { get; set; }
        public string NumAndar { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TipoEnderecoId { get; set; }
        public string TipoEndereco { get; set; }
        public string PontoReferencia { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string CidadeId { get; set; }
        public string Cidade { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public string ProvinciaId { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string Continente { get; set; }
    }

    public class EnderecoDto : EnderecoDtoBase
    {
        public bool? Principal { get; set; }
    }

}
