﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CanalComissionamento
    {
        [StringLength(50)]
        public string IdCriterioComissionamento { get; set; }
        [StringLength(50)]
        public string ComissionamentoId { get; set; }
        [StringLength(50)]
        public string CanalId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [StringLength(50)]
        public string CriterioComissionamentoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CodCriterioComissionamento { get; set; }

        [ForeignKey("CanalId")]
        [InverseProperty("CanalComissionamento")]
        public virtual Canal Canal { get; set; }
        [ForeignKey("ComissionamentoId")]
        [InverseProperty("CanalComissionamento")]
        public virtual Comissionamento Comissionamento { get; set; }
        [ForeignKey("CriterioComissionamentoId")]
        [InverseProperty("CanalComissionamento")]
        public virtual CriterioComissionamento CriterioComissionamento { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("CanalComissionamento")]
        public virtual Estado Estado { get; set; }
    }
}