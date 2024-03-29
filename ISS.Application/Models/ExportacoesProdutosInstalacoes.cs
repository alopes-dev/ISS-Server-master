﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ExportacoesProdutosInstalacoes
    {
        [StringLength(50)]
        public string IdExportacaoProdutosInstalacoes { get; set; }
        [Column("ParaEUACanada")]
        public bool? ParaEuacanada { get; set; }
        public double? EstimativaAnual { get; set; }
        [StringLength(512)]
        public string CaminhoFicheiro { get; set; }
        [Column("MoedaID")]
        [StringLength(50)]
        public string MoedaId { get; set; }
        [Column("PaisID")]
        [StringLength(50)]
        public string PaisId { get; set; }
        [Column("ProdutoInstalacaoID")]
        [StringLength(50)]
        public string ProdutoInstalacaoId { get; set; }
        [StringLength(10)]
        public string CodExportacoesProdutosInstalacoes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ExportacoesProdutosInstalacoes")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("MoedaId")]
        [InverseProperty("ExportacoesProdutosInstalacoes")]
        public virtual Moeda Moeda { get; set; }
        [ForeignKey("PaisId")]
        [InverseProperty("ExportacoesProdutosInstalacoes")]
        public virtual Pais Pais { get; set; }
        [ForeignKey("ProdutoInstalacaoId")]
        [InverseProperty("ExportacoesProdutosInstalacoes")]
        public virtual ProdutosInstalacoes ProdutoInstalacao { get; set; }
    }
}