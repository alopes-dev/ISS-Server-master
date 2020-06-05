﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Caixa
    {
        public Caixa()
        {
            Comissionamento = new HashSet<Comissionamento>();
            Movimento = new HashSet<Movimento>();
        }

        [StringLength(50)]
        public string IdCaixa { get; set; }
        [Required]
        [StringLength(50)]
        public string CodCaixa { get; set; }
        [Column("ClassificacaoCaixaID")]
        [StringLength(50)]
        public string ClassificacaoCaixaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string TipoRecebimentoId { get; set; }
        [Required]
        [StringLength(50)]
        public string FuncionarioId { get; set; }
        [StringLength(50)]
        public string EnderecoId { get; set; }
        [StringLength(50)]
        public string FormaPagamentoId { get; set; }

        [ForeignKey("ClassificacaoCaixaId")]
        [InverseProperty("Caixa")]
        public virtual ClassificacaoCaixa ClassificacaoCaixa { get; set; }
        [ForeignKey("EnderecoId")]
        [InverseProperty("Caixa")]
        public virtual Endereco Endereco { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Caixa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("FormaPagamentoId")]
        [InverseProperty("Caixa")]
        public virtual FormaPagamento FormaPagamento { get; set; }
        [ForeignKey("FuncionarioId")]
        [InverseProperty("Caixa")]
        public virtual Funcionario Funcionario { get; set; }
        [ForeignKey("TipoRecebimentoId")]
        [InverseProperty("Caixa")]
        public virtual TipoRecebimento TipoRecebimento { get; set; }
        [InverseProperty("Caixa")]
        public virtual ICollection<Comissionamento> Comissionamento { get; set; }
        public virtual ICollection<Movimento> Movimento { get; set; }
    }
}