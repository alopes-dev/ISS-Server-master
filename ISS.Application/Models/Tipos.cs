﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Tipos
    {
        [StringLength(50)]
        public string IdTipos { get; set; }
        [StringLength(50)]
        public string CodTipos { get; set; }
        [StringLength(200)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string ContaCredito { get; set; }
        [StringLength(50)]
        public string SubContaCredito { get; set; }
        [StringLength(50)]
        public string ContaDebito { get; set; }
        [StringLength(50)]
        public string SubContaDebito { get; set; }
        [StringLength(200)]
        public string HistoricoPadraoParaLancamentoContabil { get; set; }
        [StringLength(50)]
        public string TipoSubDesembolsoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }

        [ForeignKey("TipoSubDesembolsoId")]
        [InverseProperty("Tipos")]
        public virtual TipoSubDesembolso TipoSubDesembolso { get; set; }
    }
}