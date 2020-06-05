﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class PapelPessoa
    {
        public PapelPessoa()
        {
            PapelModuloPessoa = new HashSet<PapelModuloPessoa>();
            PapelPessoaResseguroIdPessoCedenteNavigation = new HashSet<PapelPessoaResseguro>();
            PapelPessoaResseguroIdPessoaRetenteNavigation = new HashSet<PapelPessoaResseguro>();
        }

        [StringLength(50)]
        public string IdPapelPessoa { get; set; }
        [Column("PapelID")]
        [StringLength(50)]
        public string PapelId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string PessoaId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [Required]
        public bool? Contabiliza { get; set; }
        [StringLength(50)]
        public string CodPapelPessoa { get; set; }
        [StringLength(50)]
        public string TipoSegmentoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("PapelPessoa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PapelId")]
        [InverseProperty("PapelPessoa")]
        public virtual Papel Papel { get; set; }
        [ForeignKey("PessoaId")]
        [InverseProperty("PapelPessoa")]
        public virtual Pessoa Pessoa { get; set; }
        [ForeignKey("TipoSegmentoId")]
        [InverseProperty("PapelPessoa")]
        public virtual TipoSegmento TipoSegmento { get; set; }
        [InverseProperty("PapelPessoa")]
        public virtual ICollection<PapelModuloPessoa> PapelModuloPessoa { get; set; }
        [InverseProperty("IdPessoCedenteNavigation")]
        public virtual ICollection<PapelPessoaResseguro> PapelPessoaResseguroIdPessoCedenteNavigation { get; set; }
        [InverseProperty("IdPessoaRetenteNavigation")]
        public virtual ICollection<PapelPessoaResseguro> PapelPessoaResseguroIdPessoaRetenteNavigation { get; set; }
    }
}