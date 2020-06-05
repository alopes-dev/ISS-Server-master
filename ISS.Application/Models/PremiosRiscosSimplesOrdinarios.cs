﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class PremiosRiscosSimplesOrdinarios
    {
        [StringLength(50)]
        public string IdRiscosSimplesOrdinarios { get; set; }
        [StringLength(100)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string Localidade { get; set; }
        [StringLength(50)]
        public string CodPremiosRiscosSimplesOrdinarios { get; set; }
        public double? Risco1 { get; set; }
        public double? Risco2 { get; set; }
        public double? Risco3 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("PremiosRiscosSimplesOrdinarios")]
        public virtual Estado Estado { get; set; }
    }
}