﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ExcepcoesPlano
    {
        [StringLength(50)]
        public string IdExcepcaoPlano { get; set; }
        [StringLength(50)]
        public string ExcepcaoId { get; set; }
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string CodExcepcoesPlano { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("ExcepcaoId")]
        [InverseProperty("ExcepcoesPlano")]
        public virtual Excepcoes Excepcao { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("ExcepcoesPlano")]
        public virtual PlanoProduto PlanoProduto { get; set; }
    }
}