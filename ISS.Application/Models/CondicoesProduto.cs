﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CondicoesProduto
    {
        [StringLength(50)]
        public string IdCondicoesProduto { get; set; }
        [Column("CondicoesID")]
        [StringLength(50)]
        public string CondicoesId { get; set; }
        [Column("ProdutoID")]
        [StringLength(50)]
        public string ProdutoId { get; set; }
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

        [ForeignKey("EstadoId")]
        [InverseProperty("CondicoesProduto")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("LinhaProdutoId")]
        [InverseProperty("CondicoesProduto")]
        public virtual LinhaProduto LinhaProduto { get; set; }
        [ForeignKey("ProdutoId")]
        [InverseProperty("CondicoesProduto")]
        public virtual Produto Produto { get; set; }
    }
}