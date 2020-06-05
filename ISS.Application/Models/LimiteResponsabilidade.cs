﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class LimiteResponsabilidade
    {
        [StringLength(50)]
        public string IdLimiteResponsabilidade { get; set; }
        [StringLength(50)]
        public string ExcessoPerdaId { get; set; }
        public double? Valor { get; set; }
        [StringLength(50)]
        public string TipoLimiteResponsabilidadeId { get; set; }
        [StringLength(50)]
        public string CodLimiteResponsabilidade { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("LimiteResponsabilidade")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ExcessoPerdaId")]
        [InverseProperty("LimiteResponsabilidade")]
        public virtual ExcessoPerda ExcessoPerda { get; set; }
        [ForeignKey("TipoLimiteResponsabilidadeId")]
        [InverseProperty("LimiteResponsabilidade")]
        public virtual TipoLimiteResponsabilidade TipoLimiteResponsabilidade { get; set; }
    }
}