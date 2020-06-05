﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Exercicio
    {
        public Exercicio()
        {
            Movimento = new HashSet<Movimento>();
            Periodo = new HashSet<Periodo>();
        }

        [StringLength(50)]
        public string IdExercicio { get; set; }
        public int? Mes { get; set; }
        public bool? Estado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Required]
        [StringLength(50)]
        public string CodExercicio { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("Exercicio")]
        public virtual Estado EstadoNavigation { get; set; }
        public virtual ICollection<Movimento> Movimento { get; set; }
        [InverseProperty("Exercicio")]
        public virtual ICollection<Periodo> Periodo { get; set; }
    }
}