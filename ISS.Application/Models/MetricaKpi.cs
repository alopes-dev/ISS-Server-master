﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    [Table("MetricaKPI")]
    public partial class MetricaKpi
    {
        public MetricaKpi()
        {
            MetricasProduto = new HashSet<MetricasProduto>();
        }

        [Column("IdMetricaKPI")]
        [StringLength(50)]
        public string IdMetricaKpi { get; set; }
        [Column("PCFID")]
        [StringLength(20)]
        public string Pcfid { get; set; }
        [Column("HierarquiaID")]
        [StringLength(20)]
        public string HierarquiaId { get; set; }
        [StringLength(4000)]
        public string Nome { get; set; }
        [StringLength(3000)]
        public string IndiceDiferenca { get; set; }
        [StringLength(300)]
        public string DetalheMudanca { get; set; }
        [StringLength(50)]
        public string MetricaDisponivel { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("CategoriaMetricaKPID")]
        [StringLength(50)]
        public string CategoriaMetricaKpid { get; set; }

        [ForeignKey("CategoriaMetricaKpid")]
        [InverseProperty("MetricaKpi")]
        public virtual CategoriaMetricaKpi CategoriaMetricaKp { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("MetricaKpi")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("MetricaKpi")]
        public virtual ICollection<MetricasProduto> MetricasProduto { get; set; }
    }
}