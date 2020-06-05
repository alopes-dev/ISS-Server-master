﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class RiscosExcluidos
    {
        [StringLength(50)]
        public string IdRiscosExcluidos { get; set; }
        public int? NumPonto { get; set; }
        [StringLength(4000)]
        public string Designacao { get; set; }
        [Column("TipoExclusaoID")]
        [StringLength(50)]
        public string TipoExclusaoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(3000)]
        public string Obs { get; set; }
        [Column("TipoCoberturaID")]
        [StringLength(50)]
        public string TipoCoberturaId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("CoberturaProdutoID")]
        [StringLength(50)]
        public string CoberturaProdutoId { get; set; }
        [Column("CoberturasComplementaresID")]
        [StringLength(50)]
        public string CoberturasComplementaresId { get; set; }
        public double? ValorSobrePremio { get; set; }

        [ForeignKey("CoberturaProdutoId")]
        [InverseProperty("RiscosExcluidos")]
        public virtual Cobertura CoberturaProduto { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("RiscosExcluidos")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("TipoCoberturaId")]
        [InverseProperty("RiscosExcluidos")]
        public virtual TipoCobertura TipoCobertura { get; set; }
        [ForeignKey("TipoExclusaoId")]
        [InverseProperty("RiscosExcluidos")]
        public virtual TipoExclusao TipoExclusao { get; set; }
    }
}