﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Reparacao
    {
        public Reparacao()
        {
            Custo = new HashSet<Custo>();
            TarefaReparacao = new HashSet<TarefaReparacao>();
        }

        [StringLength(50)]
        public string IdReparacao { get; set; }
        [StringLength(1000)]
        public string Designacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataHora { get; set; }
        public bool? FacturaDisponivel { get; set; }
        [StringLength(50)]
        public string PerdaId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("AutorizacaoID")]
        [StringLength(50)]
        public string AutorizacaoId { get; set; }
        [Column("ObjectoEnvolvidoID")]
        [StringLength(50)]
        public string ObjectoEnvolvidoId { get; set; }
        [Column("FornecedorID")]
        [StringLength(50)]
        public string FornecedorId { get; set; }
        public double? Imposto { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [StringLength(50)]
        public string CodReparacao { get; set; }

        [ForeignKey("AutorizacaoId")]
        [InverseProperty("Reparacao")]
        public virtual Autorizacao Autorizacao { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Reparacao")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("FornecedorId")]
        [InverseProperty("Reparacao")]
        public virtual Pessoa Fornecedor { get; set; }
        [ForeignKey("ObjectoEnvolvidoId")]
        [InverseProperty("Reparacao")]
        public virtual ObjectoEnvolvido ObjectoEnvolvido { get; set; }
        [ForeignKey("PerdaId")]
        [InverseProperty("Reparacao")]
        public virtual Perda Perda { get; set; }
        [InverseProperty("Reparacao")]
        public virtual ICollection<Custo> Custo { get; set; }
        [InverseProperty("Reparacao")]
        public virtual ICollection<TarefaReparacao> TarefaReparacao { get; set; }
    }
}