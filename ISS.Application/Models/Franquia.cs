﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Franquia
    {
        public Franquia()
        {
            Cobertura = new HashSet<Cobertura>();
            Cotacao = new HashSet<Cotacao>();
            FranquiaSeleccionado = new HashSet<FranquiaSeleccionado>();
            LocaisFranquia = new HashSet<LocaisFranquia>();
            SegmentoFranquia = new HashSet<SegmentoFranquia>();
        }

        [StringLength(50)]
        public string IdFranquia { get; set; }
        public double? ValorMin { get; set; }
        public double? ValorMax { get; set; }
        [Column("TipoFranquiaID")]
        [StringLength(50)]
        public string TipoFranquiaId { get; set; }
        [Column("CategoriaFranquiaID")]
        [StringLength(50)]
        public string CategoriaFranquiaId { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(100)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodFranquia { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        public double? Desconto { get; set; }
        [Required]
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
        [Column("LinhaProdutoID")]
        [StringLength(50)]
        public string LinhaProdutoId { get; set; }
        [Column("MoedaID")]
        [StringLength(50)]
        public string MoedaId { get; set; }
        [StringLength(50)]
        public string NaturezaMovimentoId { get; set; }
        [StringLength(50)]
        public string SubContaId { get; set; }

        [InverseProperty("Franquia")]
        public virtual ICollection<Cobertura> Cobertura { get; set; }
        [InverseProperty("Franquia")]
        public virtual ICollection<Cotacao> Cotacao { get; set; }
        [InverseProperty("Franquia")]
        public virtual ICollection<FranquiaSeleccionado> FranquiaSeleccionado { get; set; }
        [InverseProperty("Franquia")]
        public virtual ICollection<LocaisFranquia> LocaisFranquia { get; set; }
        [InverseProperty("Franquia")]
        public virtual ICollection<SegmentoFranquia> SegmentoFranquia { get; set; }
    }
}