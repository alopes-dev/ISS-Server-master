﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CondicoesCoSeguro
    {
        [StringLength(50)]
        public string IdCondicoesCoSeguro { get; set; }
        [StringLength(500)]
        public string CaminhoDocumento { get; set; }
        [Column("CondicoesID")]
        [StringLength(50)]
        public string CondicoesId { get; set; }
        [Column("CoSeguroID")]
        [StringLength(50)]
        public string CoSeguroId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("CoSeguroId")]
        [InverseProperty("CondicoesCoSeguro")]
        public virtual CoSeguro CoSeguro { get; set; }
        [ForeignKey("CondicoesId")]
        [InverseProperty("CondicoesCoSeguro")]
        public virtual Condicoes Condicoes { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("CondicoesCoSeguro")]
        public virtual Estado Estado { get; set; }
    }
}