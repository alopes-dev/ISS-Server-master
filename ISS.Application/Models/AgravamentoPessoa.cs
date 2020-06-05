﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class AgravamentoPessoa
    {
        [StringLength(50)]
        public string IdAgravamentoPessoa { get; set; }
        public int? IdadeMin { get; set; }
        public int? IdadeMax { get; set; }
        public double Percentagem { get; set; }
        [StringLength(2048)]
        public string DescricaoAgravamentoPessoa { get; set; }
        [Column("ProdutoID")]
        [StringLength(50)]
        public string ProdutoId { get; set; }
        [StringLength(10)]
        public string CodAgravamentoPessoa { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("LinhaProdutoID")]
        [StringLength(50)]
        public string LinhaProdutoId { get; set; }
        [Required]
        public bool? IsTaxa { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [StringLength(50)]
        public string AgravamentoId { get; set; }

        [ForeignKey("AgravamentoId")]
        [InverseProperty("AgravamentoPessoa")]
        public virtual Agravamento Agravamento { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("AgravamentoPessoa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("LinhaProdutoId")]
        [InverseProperty("AgravamentoPessoa")]
        public virtual LinhaProduto LinhaProduto { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("AgravamentoPessoa")]
        public virtual PlanoProduto PlanoProduto { get; set; }
        [ForeignKey("ProdutoId")]
        [InverseProperty("AgravamentoPessoa")]
        public virtual Produto Produto { get; set; }
    }
}