﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class GarantiasCobertura
    {
        public GarantiasCobertura()
        {
            GarantiasAfetasDespesasMedicas = new HashSet<GarantiasAfetasDespesasMedicas>();
        }

        [StringLength(50)]
        public string IdGarantia { get; set; }
        public int? NumGarantia { get; set; }
        [StringLength(2000)]
        public string Designacao { get; set; }
        [Column("CoberturaProdutoID")]
        [StringLength(50)]
        public string CoberturaProdutoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("CoberturaProdutoId")]
        [InverseProperty("GarantiasCobertura")]
        public virtual Cobertura CoberturaProduto { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("GarantiasCobertura")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("GarantiasProduto")]
        public virtual ICollection<GarantiasAfetasDespesasMedicas> GarantiasAfetasDespesasMedicas { get; set; }
    }
}