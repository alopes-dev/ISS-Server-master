﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TarifasAutomovel
    {
        [StringLength(50)]
        public string IdTarifa { get; set; }
        public int? Valor { get; set; }
        [Column("AnosID")]
        [StringLength(50)]
        public string AnosId { get; set; }
        [Column("MesesID")]
        [StringLength(50)]
        public string MesesId { get; set; }
        [Column("ProdutoID")]
        [StringLength(50)]
        public string ProdutoId { get; set; }
        [Column("SubContaID")]
        [StringLength(50)]
        public string SubContaId { get; set; }
        [StringLength(10)]
        public string CodTarifasAutomovel { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("LinhaProdutoID")]
        [StringLength(50)]
        public string LinhaProdutoId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string NaturezaMovimentoId { get; set; }
        [Required]
        public bool? Contabiliza { get; set; }
        [StringLength(50)]
        public string CodInformacoesAdicionaisProduto { get; set; }

        [ForeignKey("AnosId")]
        [InverseProperty("TarifasAutomovel")]
        public virtual Anos Anos { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("TarifasAutomovel")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("LinhaProdutoId")]
        [InverseProperty("TarifasAutomovel")]
        public virtual LinhaProduto LinhaProduto { get; set; }
        [ForeignKey("MesesId")]
        [InverseProperty("TarifasAutomovel")]
        public virtual Meses Meses { get; set; }
        [ForeignKey("NaturezaMovimentoId")]
        [InverseProperty("TarifasAutomovel")]
        public virtual NaturezaMovimento NaturezaMovimento { get; set; }
        [ForeignKey("ProdutoId")]
        [InverseProperty("TarifasAutomovel")]
        public virtual Produto Produto { get; set; }
        [ForeignKey("SubContaId")]
        [InverseProperty("TarifasAutomovel")]
        public virtual PlanoContas SubConta { get; set; }
    }
}