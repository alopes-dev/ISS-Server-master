﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class SegmentoOferta
    {
        [StringLength(50)]
        public string IdSegmentoOferta { get; set; }
        [StringLength(50)]
        public string CanalId { get; set; }
        [Column("OfertaID")]
        [StringLength(50)]
        public string OfertaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("CanalId")]
        [InverseProperty("SegmentoOferta")]
        public virtual Canal Canal { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("SegmentoOferta")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("OfertaId")]
        [InverseProperty("SegmentoOferta")]
        public virtual OperacaoPlano Oferta { get; set; }
    }
}