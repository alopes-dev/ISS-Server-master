﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class HistoricoFranquia
    {
        [StringLength(50)]
        public string IdHistoricoFranquia { get; set; }
        [StringLength(50)]
        public string IdFranquia { get; set; }
        public double? TaxaMinFranquia { get; set; }
        public double? ValorFranquiaMin { get; set; }
        public double? ValorFranquiaMax { get; set; }
        [Column("TipoFranquiaID")]
        [StringLength(50)]
        public string TipoFranquiaId { get; set; }
        [Column("CategoriaFranquiaID")]
        [StringLength(50)]
        public string CategoriaFranquiaId { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("PlanoProdutoID")]
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [StringLength(100)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodFranquia { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        public double? TaxaMaxFranquia { get; set; }
        public double? Desconto { get; set; }
        public bool? IsTaxa { get; set; }
        [Column("CoberturaProdutoID")]
        [StringLength(50)]
        public string CoberturaProdutoId { get; set; }
        [Column("CoberturasComplementaresID")]
        [StringLength(50)]
        public string CoberturasComplementaresId { get; set; }
        public int? DiaMin { get; set; }
        public int? DiaMax { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [Column("ProdutoID")]
        [StringLength(50)]
        public string ProdutoId { get; set; }
        [Column("LinhaProdutoID")]
        [StringLength(50)]
        public string LinhaProdutoId { get; set; }
    }
}