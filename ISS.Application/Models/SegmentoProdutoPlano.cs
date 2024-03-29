﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class SegmentoProdutoPlano
    {
        [StringLength(50)]
        public string IdSegmentoPlanoProduto { get; set; }
        [StringLength(50)]
        public string SegmentoProdutoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string PessoaId { get; set; }
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("SegmentoProdutoPlano")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PessoaId")]
        [InverseProperty("SegmentoProdutoPlano")]
        public virtual Pessoa Pessoa { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("SegmentoProdutoPlano")]
        public virtual PlanoProduto PlanoProduto { get; set; }
        [ForeignKey("SegmentoProdutoId")]
        [InverseProperty("SegmentoProdutoPlano")]
        public virtual SegmentoProduto SegmentoProduto { get; set; }
    }
}