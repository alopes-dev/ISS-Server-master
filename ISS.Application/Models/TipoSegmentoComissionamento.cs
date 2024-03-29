﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoSegmentoComissionamento
    {
        [StringLength(50)]
        public string IdCriterioComissionamento { get; set; }
        [StringLength(50)]
        public string ComissionamentoId { get; set; }
        [StringLength(50)]
        public string CanalId { get; set; }
        [StringLength(50)]
        public string CriterioComissionamentoId { get; set; }
        [StringLength(50)]
        public string TipoSegmentoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CodCriterioComissionamento { get; set; }

        [ForeignKey("CanalId")]
        [InverseProperty("TipoSegmentoComissionamento")]
        public virtual Canal Canal { get; set; }
        [ForeignKey("ComissionamentoId")]
        [InverseProperty("TipoSegmentoComissionamento")]
        public virtual Comissionamento Comissionamento { get; set; }
        [ForeignKey("CriterioComissionamentoId")]
        [InverseProperty("TipoSegmentoComissionamento")]
        public virtual CriterioComissionamento CriterioComissionamento { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("TipoSegmentoComissionamento")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("TipoSegmentoId")]
        [InverseProperty("TipoSegmentoComissionamento")]
        public virtual TipoSegmento TipoSegmento { get; set; }
    }
}