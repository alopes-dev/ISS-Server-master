﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CrossSelling
    {
        public CrossSelling()
        {
            CrossSellingRate = new HashSet<CrossSellingRate>();
        }

        [StringLength(50)]
        public string IdCrossSelling { get; set; }
        [Column("ProdutoPrincipalID")]
        [StringLength(50)]
        public string ProdutoPrincipalId { get; set; }
        [Column("ProdutoCrossedID")]
        [StringLength(50)]
        public string ProdutoCrossedId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [StringLength(50)]
        public string CodCrossSelling { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("CrossSelling")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ProdutoCrossedId")]
        [InverseProperty("CrossSellingProdutoCrossed")]
        public virtual Produto ProdutoCrossed { get; set; }
        [ForeignKey("ProdutoPrincipalId")]
        [InverseProperty("CrossSellingProdutoPrincipal")]
        public virtual Produto ProdutoPrincipal { get; set; }
        [InverseProperty("CrossSelling")]
        public virtual ICollection<CrossSellingRate> CrossSellingRate { get; set; }
    }
}