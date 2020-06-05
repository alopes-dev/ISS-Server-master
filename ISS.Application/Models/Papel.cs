﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Papel
    {
        public Papel()
        {
            ComissaoPlano = new HashSet<ComissaoPlano>();
            Comissionamento = new HashSet<Comissionamento>();
            CondicaoOperacao = new HashSet<CondicaoOperacao>();
            Menu = new HashSet<Menu>();
            OperacoesCrudpessoa = new HashSet<OperacoesCrudpessoa>();
            OperacoesPagamento = new HashSet<OperacoesPagamento>();
            PapelDesconto = new HashSet<PapelDesconto>();
            PapelPessoa = new HashSet<PapelPessoa>();
            PapelPlano = new HashSet<PapelPlano>();
            PapelProdutor = new HashSet<PapelProdutor>();
            TarefasAgendamento = new HashSet<TarefasAgendamento>();
            Tarifa = new HashSet<Tarifa>();
            TipoConta = new HashSet<TipoConta>();
            TipoOperacao = new HashSet<TipoOperacao>();
        }

        [StringLength(50)]
        public string IdPapel { get; set; }
        [StringLength(200)]
        public string Designacao { get; set; }
        public int NumRegistos { get; set; }
        [StringLength(10)]
        public string CodPapel { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        public bool IsProdutor { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [StringLength(50)]
        public string NaturezaMovimentoId { get; set; }
        [Required]
        public bool? Contabiliza { get; set; }
        [StringLength(50)]
        public string TipoSegmentoId { get; set; }
        [StringLength(50)]
        public string SubContaId { get; set; }
        [StringLength(50)]
        public string CodDesignacao { get; set; }
        [StringLength(50)]
        public string TipoContratacaoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("Papel")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("NaturezaMovimentoId")]
        [InverseProperty("Papel")]
        public virtual NaturezaMovimento NaturezaMovimento { get; set; }
        [ForeignKey("SubContaId")]
        [InverseProperty("Papel")]
        public virtual PlanoContas SubConta { get; set; }
        [ForeignKey("TipoContratacaoId")]
        [InverseProperty("Papel")]
        public virtual TipoContratacao TipoContratacao { get; set; }
        [ForeignKey("TipoSegmentoId")]
        [InverseProperty("Papel")]
        public virtual TipoSegmento TipoSegmento { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<ComissaoPlano> ComissaoPlano { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<Comissionamento> Comissionamento { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<CondicaoOperacao> CondicaoOperacao { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<Menu> Menu { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<OperacoesCrudpessoa> OperacoesCrudpessoa { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<OperacoesPagamento> OperacoesPagamento { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<PapelDesconto> PapelDesconto { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<PapelPessoa> PapelPessoa { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<PapelPlano> PapelPlano { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<PapelProdutor> PapelProdutor { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<TarefasAgendamento> TarefasAgendamento { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<Tarifa> Tarifa { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<TipoConta> TipoConta { get; set; }
        [InverseProperty("Papel")]
        public virtual ICollection<TipoOperacao> TipoOperacao { get; set; }
    }
}