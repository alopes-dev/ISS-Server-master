﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class OperacoesPagamento
    {
        public OperacoesPagamento()
        {
            Apolice = new HashSet<Apolice>();
            Aprovacao = new HashSet<Aprovacao>();
            ClassificacaoOperacao = new HashSet<ClassificacaoOperacao>();
            LimiteCompetencia = new HashSet<LimiteCompetencia>();
            Nota = new HashSet<Nota>();
            PlanoProduto = new HashSet<PlanoProduto>();
        }

        [StringLength(50)]
        public string IdOperacoesPagamento { get; set; }
        [StringLength(100)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string CodOperacoesPagamento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(1)]
        public string ValorRegraOperacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [StringLength(50)]
        public string ContaId { get; set; }
        [StringLength(500)]
        public string CaminhoIcome { get; set; }
        [StringLength(50)]
        public string PapelId { get; set; }
        [StringLength(50)]
        public string TipoOperacaoId { get; set; }

        [ForeignKey("ContaId")]
        [InverseProperty("OperacoesPagamento")]
        public virtual PlanoContas Conta { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("OperacoesPagamento")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PapelId")]
        [InverseProperty("OperacoesPagamento")]
        public virtual Papel Papel { get; set; }
        [ForeignKey("TipoOperacaoId")]
        [InverseProperty("OperacoesPagamento")]
        public virtual TipoOperacao TipoOperacao { get; set; }
        [InverseProperty("OperacoesPagamento")]
        public virtual ICollection<Apolice> Apolice { get; set; }
        [InverseProperty("TipoOperacao")]
        public virtual ICollection<Aprovacao> Aprovacao { get; set; }
        [InverseProperty("TipoOperacao")]
        public virtual ICollection<ClassificacaoOperacao> ClassificacaoOperacao { get; set; }
        [InverseProperty("TipoOperacao")]
        public virtual ICollection<LimiteCompetencia> LimiteCompetencia { get; set; }
        [InverseProperty("TipoOperacao")]
        public virtual ICollection<Nota> Nota { get; set; }
        [InverseProperty("OperacoesPagamento")]
        public virtual ICollection<PlanoProduto> PlanoProduto { get; set; }
    }
}