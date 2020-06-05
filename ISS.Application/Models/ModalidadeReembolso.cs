﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ModalidadeReembolso
    {
        public ModalidadeReembolso()
        {
            PlanoProduto = new HashSet<PlanoProduto>();
        }

        [StringLength(50)]
        public string IdModalidadeReembolso { get; set; }
        [StringLength(800)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodModalidadeReembolso { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string IdFormaPagamento { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ModalidadeReembolso")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("IdFormaPagamento")]
        [InverseProperty("ModalidadeReembolso")]
        public virtual FormaPagamento IdFormaPagamentoNavigation { get; set; }
        [InverseProperty("ModalidadeReembolso")]
        public virtual ICollection<PlanoProduto> PlanoProduto { get; set; }
    }
}