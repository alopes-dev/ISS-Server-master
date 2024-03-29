﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class PeriodoPlano
    {
        public PeriodoPlano()
        {
            Cotacao = new HashSet<Cotacao>();
            PeriodoPlanoPlano = new HashSet<PeriodoPlanoPlano>();
            Viagem = new HashSet<Viagem>();
        }

        [StringLength(50)]
        public string IdPeriodo { get; set; }
        public int? PeriodoMin { get; set; }
        [StringLength(2048)]
        public string Designacao { get; set; }
        public int? PeriodoMax { get; set; }
        [StringLength(10)]
        public string CodPeriodoPlano { get; set; }
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
        public string DuracaoTipoContratoId { get; set; }

        [ForeignKey("DuracaoTipoContratoId")]
        [InverseProperty("PeriodoPlano")]
        public virtual DuracaoTipoContrato DuracaoTipoContrato { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("PeriodoPlano")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("PeriodoPlano")]
        public virtual ICollection<Cotacao> Cotacao { get; set; }
        [InverseProperty("PeriodoPlano")]
        public virtual ICollection<PeriodoPlanoPlano> PeriodoPlanoPlano { get; set; }
        [InverseProperty("PeriodoPlano")]
        public virtual ICollection<Viagem> Viagem { get; set; }
    }
}