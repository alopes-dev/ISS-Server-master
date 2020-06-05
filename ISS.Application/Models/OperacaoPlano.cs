﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class OperacaoPlano
    {
        public OperacaoPlano()
        {
            LocaisOferta = new HashSet<LocaisOferta>();
            SegmentoOferta = new HashSet<SegmentoOferta>();
        }

        [StringLength(50)]
        public string IdOperacaoPlano { get; set; }
        [Column("PlanoProdutoID")]
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [StringLength(50)]
        public string OperacaoId { get; set; }

        [ForeignKey("OperacaoId")]
        [InverseProperty("OperacaoPlano")]
        public virtual Operacao Operacao { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("OperacaoPlano")]
        public virtual PlanoProduto PlanoProduto { get; set; }
        [InverseProperty("Oferta")]
        public virtual ICollection<LocaisOferta> LocaisOferta { get; set; }
        [InverseProperty("Oferta")]
        public virtual ICollection<SegmentoOferta> SegmentoOferta { get; set; }
    }
}