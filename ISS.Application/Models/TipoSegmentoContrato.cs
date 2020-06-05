﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoSegmentoContrato
    {
        [StringLength(50)]
        public string IdTipoSegmentoContrato { get; set; }
        [StringLength(50)]
        public string TipoSegmentoId { get; set; }
        [StringLength(50)]
        public string ContratoId { get; set; }
        [StringLength(50)]
        public string CodTipoSegmentoContrato { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }

        [ForeignKey("ContratoId")]
        [InverseProperty("TipoSegmentoContrato")]
        public virtual Contrato Contrato { get; set; }
        [ForeignKey("TipoSegmentoId")]
        [InverseProperty("TipoSegmentoContrato")]
        public virtual TipoSegmento TipoSegmento { get; set; }
    }
}