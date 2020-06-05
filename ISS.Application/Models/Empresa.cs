﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Comite = new HashSet<Comite>();
            ContactoEmpresa = new HashSet<ContactoEmpresa>();
            DireccaoEmpresa = new HashSet<DireccaoEmpresa>();
            InformacaoBancaria = new HashSet<InformacaoBancaria>();
            Movimento = new HashSet<Movimento>();
            PerguntasFrequentesEmpresa = new HashSet<PerguntasFrequentesEmpresa>();
            TipoContratoEmpresa = new HashSet<TipoContratoEmpresa>();
        }

        [StringLength(50)]
        public string IdDadosEmpresa { get; set; }
        [StringLength(100)]
        public string NomeEmpresa { get; set; }
        [StringLength(4000)]
        public string RazaoSocial { get; set; }
        public double? CapitalSocial { get; set; }
        [Column("NIF")]
        [StringLength(100)]
        public string Nif { get; set; }
        [Column("CAEid")]
        [StringLength(50)]
        public string Caeid { get; set; }
        [Column("EnderecoID")]
        [StringLength(50)]
        public string EnderecoId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [Column("INSS")]
        [StringLength(100)]
        public string Inss { get; set; }
        [StringLength(100)]
        public string NumAlvara { get; set; }
        [StringLength(50)]
        public string CaixaPostal { get; set; }
        [StringLength(50)]
        public string DireccaoId { get; set; }
        [Required]
        [StringLength(50)]
        public string CodEmpresa { get; set; }
        [StringLength(200)]
        public string Carimbo { get; set; }

        [ForeignKey("Caeid")]
        [InverseProperty("Empresa")]
        public virtual Cae Cae { get; set; }
        [ForeignKey("DireccaoId")]
        [InverseProperty("Empresa")]
        public virtual Direccao Direccao { get; set; }
        [ForeignKey("EnderecoId")]
        [InverseProperty("Empresa")]
        public virtual Endereco Endereco { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Empresa")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("Empresa")]
        public virtual ICollection<Comite> Comite { get; set; }
        [InverseProperty("Empresa")]
        public virtual ICollection<ContactoEmpresa> ContactoEmpresa { get; set; }
        [InverseProperty("Empresa")]
        public virtual ICollection<DireccaoEmpresa> DireccaoEmpresa { get; set; }
        [InverseProperty("Empresa")]
        public virtual ICollection<InformacaoBancaria> InformacaoBancaria { get; set; }
        public virtual ICollection<Movimento> Movimento { get; set; }
        [InverseProperty("Empresa")]
        public virtual ICollection<PerguntasFrequentesEmpresa> PerguntasFrequentesEmpresa { get; set; }
        [InverseProperty("Empresa")]
        public virtual ICollection<TipoContratoEmpresa> TipoContratoEmpresa { get; set; }
    }
}