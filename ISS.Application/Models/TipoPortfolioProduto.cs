﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoPortfolioProduto
    {
        public TipoPortfolioProduto()
        {
            PortfolioProduto = new HashSet<PortfolioProduto>();
        }

        [StringLength(50)]
        public string IdTipoPortfolioProduto { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string CodTipoPortfolioProduto { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoPortfolioProduto")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoPortfolioProduto")]
        public virtual ICollection<PortfolioProduto> PortfolioProduto { get; set; }
    }
}