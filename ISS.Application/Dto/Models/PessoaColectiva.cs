using ISS.Application.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Dto.Models
{
    public class PessoaColectiva
    {
        [Column("CAEid")]
        [StringLength(50)]
        public string Caeid { get; set; }
        [Column("NumRegistoINAPEM")]
        [StringLength(100)]
        public string NumRegistoInapem { get; set; }
        [StringLength(100)]
        public string NumAlvara { get; set; }
        public double? CapitalSocial { get; set; }
        public int? NumeroProprietarios { get; set; }
        public int? NumeroMembros { get; set; }
        [Column("DimensaoEmpresaID")]
        [StringLength(50)]
        public string DimensaoEmpresaId { get; set; }
        [StringLength(50)]
        public string Sigla { get; set; }
        [StringLength(50)]
        public string NumRegistroComercial { get; set; }
        [StringLength(50)]
        public string DespesaTotalDosFuncionarios { get; set; }
        [StringLength(50)]
        public string NumRegistroEmpresa { get; set; }
        public int? DespesaTotalFuncionarios { get; set; }
        [StringLength(50)]
        public string TipoSociedadeId { get; set; }

        [ForeignKey("Caeid")]
        [InverseProperty("Pessoa")]
        public virtual Cae Cae { get; set; }

        [ForeignKey("DimensaoEmpresaId")]
        [InverseProperty("Pessoa")]
        public virtual DimensaoEmpresa DimensaoEmpresa { get; set; }
        [ForeignKey("TipoSociedadeId")]
        [InverseProperty("Pessoa")]
        public virtual TipoSociedade TipoSociedade { get; set; }
    }
}
