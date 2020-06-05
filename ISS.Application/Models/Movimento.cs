﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Movimento
    {
        public Movimento()
        {
            MovimentoPlano = new HashSet<MovimentoPlano>();
            TipoRecebimentoMovimento = new HashSet<TipoRecebimentoMovimento>();
        }

        [StringLength(50)]
        public string IdMovimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataHoraMovimento { get; set; }
        [StringLength(800)]
        public string DescricaoMovimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataValor { get; set; }
        public double Valor { get; set; }
        [StringLength(50)]
        public string CodEstado { get; set; }
        [StringLength(50)]
        public string CodContaFinanceira { get; set; }
        [StringLength(200)]
        public string NumeroDocumentoInterno { get; set; }
        [StringLength(50)]
        public string CodCaixa { get; set; }
        [StringLength(50)]
        public string CodEndereco { get; set; }
        public bool? IsPago { get; set; }
        public bool? Contabliza { get; set; }
        [StringLength(50)]
        public string CodFavorecido { get; set; }
        [StringLength(50)]
        public string CodOutraMoeda { get; set; }
        [StringLength(50)]
        public string CodCentroResponsabilidade { get; set; }
        [StringLength(50)]
        public string CodCentroCusto { get; set; }
        [StringLength(50)]
        public string Referencia { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataVencimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataProgramada { get; set; }
        public int? DocumentoParcelado { get; set; }
        [StringLength(50)]
        public string Identificador { get; set; }
        [StringLength(200)]
        public string NumeroDocumentoExterno { get; set; }
        [StringLength(50)]
        public string CodEmpresa { get; set; }
        [StringLength(50)]
        public string CodTipoPagamento { get; set; }
        public double ValorOutraMoeda { get; set; }
        [StringLength(50)]
        public string CodFraccionamento { get; set; }
        [StringLength(50)]
        public string CodOperacoesPagamento { get; set; }
        [StringLength(50)]
        public string CodMoeda { get; set; }
        [StringLength(50)]
        public string CodNaturezaMovimento { get; set; }
        [StringLength(50)]
        public string CodConta { get; set; }
        [StringLength(50)]
        public string CodOperacao { get; set; }
        [StringLength(50)]
        public string CodFuncionario { get; set; }
        [StringLength(50)]
        public string CodExercicio { get; set; }
        [StringLength(10)]
        public string CodTipoDocumentos { get; set; }
        public int? NumeroLote { get; set; }
        [StringLength(50)]
        public string CodFormaPagamento { get; set; }
        [Column("CodCAE")]
        [StringLength(50)]
        public string CodCae { get; set; }
        //public int NumOrdem { get; set; }

        public virtual Cae CodCaeNavigation { get; set; }
        public virtual Caixa CodCaixaNavigation { get; set; }
        public virtual CentroCusto CodCentroCustoNavigation { get; set; }
        public virtual CentroResponsabilidade CodCentroResponsabilidadeNavigation { get; set; }
        public virtual ContaFinanceira CodContaFinanceiraNavigation { get; set; }
        public virtual PlanoContas CodContaNavigation { get; set; }
        public virtual Empresa CodEmpresaNavigation { get; set; }
        public virtual Endereco CodEnderecoNavigation { get; set; }
        public virtual Exercicio CodExercicioNavigation { get; set; }
        public virtual Pessoa CodFavorecidoNavigation { get; set; }
        public virtual FormaPagamento CodFormaPagamentoNavigation { get; set; }
        public virtual Fraccionamento CodFraccionamentoNavigation { get; set; }
        public virtual Funcionario CodFuncionarioNavigation { get; set; }
        public virtual Moeda CodMoedaNavigation { get; set; }
        public virtual NaturezaMovimento CodNaturezaMovimentoNavigation { get; set; }
        public virtual Operacao CodOperacaoNavigation { get; set; }
        public virtual Moeda CodOutraMoedaNavigation { get; set; }
        public virtual TipoDocumentos CodTipoDocumentosNavigation { get; set; }
        [InverseProperty("Movimento")]
        public virtual ICollection<MovimentoPlano> MovimentoPlano { get; set; }
        [InverseProperty("Movimento")]
        public virtual ICollection<TipoRecebimentoMovimento> TipoRecebimentoMovimento { get; set; }
    }
}