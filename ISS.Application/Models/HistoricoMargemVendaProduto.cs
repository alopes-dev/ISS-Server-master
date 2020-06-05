﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class HistoricoMargemVendaProduto
    {
        [StringLength(50)]
        public string IdHistoricoMargemVendaProduto { get; set; }
        [StringLength(50)]
        public string IdMargemVendaProduto { get; set; }
        public double? Taxa { get; set; }
        public double? ValorMinPremioSimples { get; set; }
        public double? ValorMaxPremioSimples { get; set; }
        [StringLength(100)]
        public string Descricao { get; set; }
        [Column("PlanoProdutoID")]
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [StringLength(50)]
        public string MoedaId { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("SubContaID")]
        [StringLength(50)]
        public string SubContaId { get; set; }
        [Column("TipoMargemID")]
        [StringLength(50)]
        public string TipoMargemId { get; set; }
        public bool? IsTaxa { get; set; }
        [StringLength(50)]
        public string NaturezaMovimentoId { get; set; }
        public bool? Contabiliza { get; set; }
        [Column("PrecarioProdutoID")]
        [StringLength(50)]
        public string PrecarioProdutoId { get; set; }
    }
}