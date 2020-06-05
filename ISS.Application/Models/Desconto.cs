﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Desconto
    {
        public Desconto()
        {
            CanalDesconto = new HashSet<CanalDesconto>();
            DescontoApoliceGrupo = new HashSet<DescontoApoliceGrupo>();
            DescontoLinha = new HashSet<DescontoLinha>();
            DescontoPessoa = new HashSet<DescontoPessoa>();
            DescontoPlano = new HashSet<DescontoPlano>();
            DescontoSeleccionado = new HashSet<DescontoSeleccionado>();
            DescontoTipoConta = new HashSet<DescontoTipoConta>();
            FormaContratacao = new HashSet<FormaContratacao>();
            LocaisDesconto = new HashSet<LocaisDesconto>();
            MembroAssegurado = new HashSet<MembroAssegurado>();
            PapelDesconto = new HashSet<PapelDesconto>();
        }

        [StringLength(50)]
        public string IdDesconto { get; set; }
        public double? Taxa { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataInicio { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataFim { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("TipoDescontoID")]
        [StringLength(50)]
        public string TipoDescontoId { get; set; }
        [StringLength(10)]
        public string CodDesconto { get; set; }
        public double? ValorMinPremioSimples { get; set; }
        public double? ValorMaxPremioSimples { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        public double? ValorMinDesconto { get; set; }
        public double? ValorMaxDesconto { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [Column("MoedaID")]
        [StringLength(50)]
        public string MoedaId { get; set; }
        [StringLength(50)]
        public string TipoTarifaId { get; set; }
        [StringLength(50)]
        public string CentroCustoId { get; set; }
        [StringLength(50)]
        public string TipoPagamentoId { get; set; }
        [StringLength(50)]
        public string LocalAplicacaoId { get; set; }
        public bool? IsTaxa { get; set; }
        [StringLength(50)]
        public string Nota { get; set; }
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [StringLength(50)]
        public string ProdutorId { get; set; }
        [StringLength(50)]
        public string TipoOperacaoId { get; set; }

        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("Desconto")]
        public virtual PlanoProduto PlanoProduto { get; set; }
        [ForeignKey("ProdutorId")]
        [InverseProperty("Desconto")]
        public virtual Pessoa Produtor { get; set; }
        [ForeignKey("TipoOperacaoId")]
        [InverseProperty("Desconto")]
        public virtual TipoOperacao TipoOperacao { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<CanalDesconto> CanalDesconto { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<DescontoApoliceGrupo> DescontoApoliceGrupo { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<DescontoLinha> DescontoLinha { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<DescontoPessoa> DescontoPessoa { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<DescontoPlano> DescontoPlano { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<DescontoSeleccionado> DescontoSeleccionado { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<DescontoTipoConta> DescontoTipoConta { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<FormaContratacao> FormaContratacao { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<LocaisDesconto> LocaisDesconto { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<MembroAssegurado> MembroAssegurado { get; set; }
        [InverseProperty("Desconto")]
        public virtual ICollection<PapelDesconto> PapelDesconto { get; set; }
    }
}