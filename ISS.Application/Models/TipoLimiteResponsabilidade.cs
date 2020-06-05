﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoLimiteResponsabilidade
    {
        public TipoLimiteResponsabilidade()
        {
            LimiteResponsabilidade = new HashSet<LimiteResponsabilidade>();
        }

        [StringLength(50)]
        public string IdTipoLimiteResponsabilidade { get; set; }
        [StringLength(100)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string CodTipoLimiteResponsabilidade { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoLimiteResponsabilidade")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoLimiteResponsabilidade")]
        public virtual ICollection<LimiteResponsabilidade> LimiteResponsabilidade { get; set; }
    }
}