﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CategoriaTarefa
    {
        public CategoriaTarefa()
        {
            Nota = new HashSet<Nota>();
            TarefasAgendamento = new HashSet<TarefasAgendamento>();
        }

        [StringLength(50)]
        public string IdCategoria { get; set; }
        [StringLength(50)]
        public string Descricao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CorId { get; set; }

        [ForeignKey("CorId")]
        [InverseProperty("CategoriaTarefa")]
        public virtual Cor Cor { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("CategoriaTarefa")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("Categoria")]
        public virtual ICollection<Nota> Nota { get; set; }
        [InverseProperty("CategoriaTarefa")]
        public virtual ICollection<TarefasAgendamento> TarefasAgendamento { get; set; }
    }
}