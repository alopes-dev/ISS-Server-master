﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CentroResponsabilidade
    {
        public CentroResponsabilidade()
        {
            Contrato = new HashSet<Contrato>();
            Cotacao = new HashSet<Cotacao>();
            Movimento = new HashSet<Movimento>();
        }

        [StringLength(50)]
        public string IdCentroResponsabilidade { get; set; }
        [StringLength(100)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string PessoaId { get; set; }
        [StringLength(50)]
        public string DireccaoId { get; set; }
        [StringLength(50)]
        public string DepartamentoId { get; set; }
        [StringLength(50)]
        public string SeccaoId { get; set; }
        [StringLength(50)]
        public string SectorId { get; set; }
        [StringLength(50)]
        public string AreaId { get; set; }
        [Column("SubContaID")]
        [StringLength(50)]
        public string SubContaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Required]
        public bool? Contabiliza { get; set; }
        [Required]
        [StringLength(50)]
        public string CodCentroResponsabilidade { get; set; }

        [ForeignKey("AreaId")]
        [InverseProperty("CentroResponsabilidade")]
        public virtual Area Area { get; set; }
        [ForeignKey("DepartamentoId")]
        [InverseProperty("CentroResponsabilidade")]
        public virtual Departamento Departamento { get; set; }
        [ForeignKey("DireccaoId")]
        [InverseProperty("CentroResponsabilidade")]
        public virtual Direccao Direccao { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("CentroResponsabilidade")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PessoaId")]
        [InverseProperty("CentroResponsabilidade")]
        public virtual Pessoa Pessoa { get; set; }
        [ForeignKey("SeccaoId")]
        [InverseProperty("CentroResponsabilidade")]
        public virtual Seccao Seccao { get; set; }
        [ForeignKey("SectorId")]
        [InverseProperty("CentroResponsabilidade")]
        public virtual Sector Sector { get; set; }
        [ForeignKey("SubContaId")]
        [InverseProperty("CentroResponsabilidade")]
        public virtual PlanoContas SubConta { get; set; }
        [InverseProperty("CentroResponsabilidade")]
        public virtual ICollection<Contrato> Contrato { get; set; }
        [InverseProperty("CentroResponsabilidade")]
        public virtual ICollection<Cotacao> Cotacao { get; set; }
        public virtual ICollection<Movimento> Movimento { get; set; }
    }
}