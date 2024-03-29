﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Justificacao
    {
        [StringLength(50)]
        public string IdJustificacao { get; set; }
        [StringLength(100)]
        public string Obs { get; set; }
        [StringLength(50)]
        public string Descricao { get; set; }
        [StringLength(50)]
        public string CategoriaJustificacaoId { get; set; }
        [StringLength(50)]
        public string ApoliceId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("ApoliceId")]
        [InverseProperty("Justificacao")]
        public virtual Apolice Apolice { get; set; }
        [ForeignKey("CategoriaJustificacaoId")]
        [InverseProperty("Justificacao")]
        public virtual CategoriaJustificacao CategoriaJustificacao { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Justificacao")]
        public virtual Estado Estado { get; set; }
    }
}