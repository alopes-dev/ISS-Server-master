﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ProvinciaPlano
    {
        public ProvinciaPlano()
        {
            CriterioPlano = new HashSet<CriterioPlano>();
            LimiteComissionamentoPlano = new HashSet<LimiteComissionamentoPlano>();
            LimiteComissionamentoProdutor = new HashSet<LimiteComissionamentoProdutor>();
        }

        [StringLength(50)]
        public string IdProvinciaPlano { get; set; }
        [StringLength(50)]
        public string ProvinciaId { get; set; }
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [StringLength(50)]
        public string CodProvinciaPlano { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string ComissionamentoId { get; set; }
        public double? TaxaAgravamento { get; set; }
        [StringLength(50)]
        public string NivelRiscoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ProvinciaPlano")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("NivelRiscoId")]
        [InverseProperty("ProvinciaPlano")]
        public virtual NivelRisco NivelRisco { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("ProvinciaPlano")]
        public virtual PlanoProduto PlanoProduto { get; set; }
        [ForeignKey("ProvinciaId")]
        [InverseProperty("ProvinciaPlano")]
        public virtual Provincia Provincia { get; set; }
        [InverseProperty("ProvinciaPlano")]
        public virtual ICollection<CriterioPlano> CriterioPlano { get; set; }
        [InverseProperty("ProvinciaPlano")]
        public virtual ICollection<LimiteComissionamentoPlano> LimiteComissionamentoPlano { get; set; }
        [InverseProperty("ProvinciaProdutor")]
        public virtual ICollection<LimiteComissionamentoProdutor> LimiteComissionamentoProdutor { get; set; }
    }
}