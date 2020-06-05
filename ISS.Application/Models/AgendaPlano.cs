﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class AgendaPlano
    {
        [StringLength(50)]
        public string IdAgendaPlano { get; set; }
        [StringLength(50)]
        public string AgendaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }

        [ForeignKey("AgendaId")]
        [InverseProperty("AgendaPlano")]
        public virtual Agenda Agenda { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("AgendaPlano")]
        public virtual PlanoProduto PlanoProduto { get; set; }
    }
}