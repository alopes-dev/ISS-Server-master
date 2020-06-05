﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ClassificacaoOperacao
    {
        public ClassificacaoOperacao()
        {
            Operacao = new HashSet<Operacao>();
        }

        [StringLength(50)]
        public string IdClassificacaoOperacao { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string TipoOperacaoId { get; set; }
        [StringLength(50)]
        public string CodClassificacaoOperacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ClassificacaoOperacao")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("TipoOperacaoId")]
        [InverseProperty("ClassificacaoOperacao")]
        public virtual OperacoesPagamento TipoOperacao { get; set; }
        [InverseProperty("ClassificacaoOperacao")]
        public virtual ICollection<Operacao> Operacao { get; set; }
    }
}