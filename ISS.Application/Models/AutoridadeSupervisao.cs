﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class AutoridadeSupervisao
    {
        public AutoridadeSupervisao()
        {
            Cae = new HashSet<Cae>();
        }

        [StringLength(50)]
        public string IdAutoridadeSupervisao { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("AutoridadeSupervisao")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("AutoridadeSupervisao")]
        public virtual ICollection<Cae> Cae { get; set; }
    }
}