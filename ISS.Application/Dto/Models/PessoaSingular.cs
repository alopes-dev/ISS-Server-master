using ISS.Application.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Dto.Models
{
    public class PessoaSingular
    {
        [StringLength(100)]
        public string PrimeiroNome { get; set; }
        [StringLength(100)]
        public string NomeDoMeio { get; set; }
        [StringLength(100)]
        public string UltimoNome { get; set; }
        [StringLength(100)]
        public string NomeCurto { get; set; }
        [StringLength(100)]
        public string Pseudonimo { get; set; }
        [Column("EstadoCivilID")]
        [StringLength(50)]
        public string EstadoCivilId { get; set; }
        [StringLength(50)]
        public string SexoId { get; set; }
        [Column("TituloID")]
        [StringLength(50)]
        public string TituloId { get; set; }
        [Column("SituacaoEmpregoID")]
        [StringLength(50)]
        public string SituacaoEmpregoId { get; set; }
        [StringLength(1000)]
        public string RazoesDesemprego { get; set; }
        [Column("FaixaEtariaID")]
        [StringLength(50)]
        public string FaixaEtariaId { get; set; }
        [StringLength(50)]
        public string Alias { get; set; }
        [StringLength(50)]
        public string DeficienciaId { get; set; }
        [StringLength(50)]
        public string TipoSanguineoId { get; set; }

        [ForeignKey("DeficienciaId")]
        [InverseProperty("Pessoa")]
        public virtual Deficiencia Deficiencia { get; set; }
        [ForeignKey("EstadoCivilId")]
        [InverseProperty("Pessoa")]
        public virtual EstadoCivil EstadoCivil { get; set; }
        [ForeignKey("FaixaEtariaId")]
        [InverseProperty("Pessoa")]
        public virtual FaixaEtaria FaixaEtaria { get; set; }
        [ForeignKey("SexoId")]
        [InverseProperty("Pessoa")]
        public virtual Sexo Sexo { get; set; }
        [ForeignKey("SituacaoEmpregoId")]
        [InverseProperty("Pessoa")]
        public virtual SituacaoEmprego SituacaoEmprego { get; set; }
        [ForeignKey("TipoSanguineoId")]
        [InverseProperty("Pessoa")]
        public virtual TipoSanguineo TipoSanguineo { get; set; }
        [ForeignKey("TituloId")]
        [InverseProperty("Pessoa")]
        public virtual Titulo Titulo { get; set; }
        [InverseProperty("Pessoa")]
        public virtual Filiacao Filiacao { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<CartaConducao> CartaConducao { get; set; }
        [InverseProperty("Causador")]
        public virtual ICollection<CausadorSinistro> CausadorSinistro { get; set; }
        [InverseProperty("Conjugue")]
        public virtual ICollection<ConjuguePessoa> ConjuguePessoaConjugue { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<ConjuguePessoa> ConjuguePessoaPessoa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<HabilitacoesLiterariasPessoa> HabilitacoesLiterariasPessoa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<IdiomaPessoa> IdiomaPessoa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<PessoaProfissao> PessoaProfissao { get; set; }
         [InverseProperty("Pessoa")]
        public virtual ICollection<RendimentoPessoa> RendimentoPessoaPessoa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Animais> Animais { get; set; }
    }
}
