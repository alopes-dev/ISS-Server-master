﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoSegmentosComissionamento
    {
        [StringLength(50)]
        public string IdTipoSegmentosComissionamento { get; set; }
        [StringLength(50)]
        public string CodLimiteComissionamento { get; set; }
        [StringLength(50)]
        public string TipoSegmentoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string ComissionamentoId { get; set; }

        [ForeignKey("ComissionamentoId")]
        [InverseProperty("TipoSegmentosComissionamento")]
        public virtual Comissionamento Comissionamento { get; set; }
        [ForeignKey("TipoSegmentoId")]
        [InverseProperty("TipoSegmentosComissionamento")]
        public virtual TipoSegmento TipoSegmento { get; set; }
    }
}