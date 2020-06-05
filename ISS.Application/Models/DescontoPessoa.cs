﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class DescontoPessoa
    {
        public DescontoPessoa()
        {
            DescontoPessoaPlano = new HashSet<DescontoPessoaPlano>();
        }

        [StringLength(50)]
        public string IdDescontoPessoa { get; set; }
        [StringLength(50)]
        public string DescontoId { get; set; }
        [StringLength(50)]
        public string CodDescontoPessoa { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        public int? IdadeMin { get; set; }
        public int? IdadeMax { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [StringLength(50)]
        public string Obs { get; set; }

        [ForeignKey("DescontoId")]
        [InverseProperty("DescontoPessoa")]
        public virtual Desconto Desconto { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("DescontoPessoa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("DescontoPessoa")]
        public virtual PlanoProduto PlanoProduto { get; set; }
        [InverseProperty("DescontoPessoa")]
        public virtual ICollection<DescontoPessoaPlano> DescontoPessoaPlano { get; set; }
    }
}