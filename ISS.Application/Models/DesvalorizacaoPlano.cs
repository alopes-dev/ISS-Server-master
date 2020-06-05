﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class DesvalorizacaoPlano
    {
        [StringLength(50)]
        public string IdDesvalorizacaoPlano { get; set; }
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [StringLength(50)]
        public string DesvalorizacaoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("DesvalorizacaoId")]
        [InverseProperty("DesvalorizacaoPlano")]
        public virtual Desvalorizacao Desvalorizacao { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("DesvalorizacaoPlano")]
        public virtual PlanoProduto PlanoProduto { get; set; }
    }
}