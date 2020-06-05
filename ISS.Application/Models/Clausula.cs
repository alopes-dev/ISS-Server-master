﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Clausula
    {
        public Clausula()
        {
            ContratoClausula = new HashSet<ContratoClausula>();
            ContratoPrestadorEmpresa = new HashSet<ContratoPrestadorEmpresa>();
            PontosClausula = new HashSet<PontosClausula>();
        }

        [StringLength(50)]
        public string IdClausula { get; set; }
        [StringLength(100)]
        public string NumClausula { get; set; }
        [StringLength(4000)]
        public string Titulo { get; set; }
        [Column("OBS")]
        [StringLength(2048)]
        public string Obs { get; set; }
        [Column("RegiaoID")]
        [StringLength(50)]
        public string RegiaoId { get; set; }
        [StringLength(10)]
        public string CodClausula { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [StringLength(50)]
        public string ArtigoId { get; set; }
        [StringLength(50)]
        public string CapituloId { get; set; }

        [ForeignKey("ArtigoId")]
        [InverseProperty("Clausula")]
        public virtual Artigo Artigo { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Clausula")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("RegiaoId")]
        [InverseProperty("Clausula")]
        public virtual Regiao Regiao { get; set; }
        [InverseProperty("Clausula")]
        public virtual ICollection<ContratoClausula> ContratoClausula { get; set; }
        [InverseProperty("ClausulasNavigation")]
        public virtual ICollection<ContratoPrestadorEmpresa> ContratoPrestadorEmpresa { get; set; }
        [InverseProperty("Clausula")]
        public virtual ICollection<PontosClausula> PontosClausula { get; set; }
    }
}