﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CartaoPagamento
    {
        public CartaoPagamento()
        {
            InformacaoBancaria = new HashSet<InformacaoBancaria>();
        }

        [StringLength(50)]
        public string IdCartaoPagamento { get; set; }
        [StringLength(50)]
        public string NumCartao { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataValidade { get; set; }
        [Column("TipoCartaoPagamentoID")]
        [StringLength(50)]
        public string TipoCartaoPagamentoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CodCartaoPagamento { get; set; }
        [StringLength(50)]
        public string Conta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataEmissao { get; set; }
        [StringLength(200)]
        public string NomeCartao { get; set; }
        [StringLength(50)]
        public string ContaFinanceiraId { get; set; }
        [Column(TypeName = "money")]
        public decimal? SaldoDisponivel { get; set; }
        [Column(TypeName = "money")]
        public decimal? SaldoContablistico { get; set; }
        [Column(TypeName = "money")]
        public decimal? Saldo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataUltimaUtilizacao { get; set; }

        [ForeignKey("ContaFinanceiraId")]
        [InverseProperty("CartaoPagamento")]
        public virtual ContaFinanceira ContaFinanceira { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("CartaoPagamento")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("TipoCartaoPagamentoId")]
        [InverseProperty("CartaoPagamento")]
        public virtual TipoCartaoPagamento TipoCartaoPagamento { get; set; }
        [InverseProperty("CartaoPagamento")]
        public virtual ICollection<InformacaoBancaria> InformacaoBancaria { get; set; }
    }
}