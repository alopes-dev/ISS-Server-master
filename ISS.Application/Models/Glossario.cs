﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Glossario
    {
        [StringLength(50)]
        public string IdGlossario { get; set; }
        [StringLength(50)]
        public string ProcessoElemento { get; set; }
        [Column("HierarquiaID")]
        [StringLength(20)]
        public string HierarquiaId { get; set; }
        [StringLength(300)]
        public string ElementoProcesso { get; set; }
        [StringLength(4000)]
        public string Definicao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(500)]
        public string CodGlossario { get; set; }
        [Column("ProdutoID")]
        [StringLength(50)]
        public string ProdutoId { get; set; }
        [Column("LinhaProdutoID")]
        [StringLength(50)]
        public string LinhaProdutoId { get; set; }
        [Column("CategoriaGlossarioID")]
        [StringLength(50)]
        public string CategoriaGlossarioId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        public int? InApolice { get; set; }

        [ForeignKey("CategoriaGlossarioId")]
        [InverseProperty("Glossario")]
        public virtual CategoriaGlossario CategoriaGlossario { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Glossario")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("LinhaProdutoId")]
        [InverseProperty("Glossario")]
        public virtual LinhaProduto LinhaProduto { get; set; }
        [ForeignKey("ProdutoId")]
        [InverseProperty("Glossario")]
        public virtual Produto Produto { get; set; }
    }
}