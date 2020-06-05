﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoFacturacao
    {
        public TipoFacturacao()
        {
            TipoFacturacaoPlanoProduto = new HashSet<TipoFacturacaoPlanoProduto>();
        }

        [StringLength(50)]
        public string IdTipoFacturacao { get; set; }
        [StringLength(10)]
        public string CodTipoFacturacao { get; set; }
        [StringLength(100)]
        public string Designacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoFacturacao")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoFacturacao")]
        public virtual ICollection<TipoFacturacaoPlanoProduto> TipoFacturacaoPlanoProduto { get; set; }
    }
}