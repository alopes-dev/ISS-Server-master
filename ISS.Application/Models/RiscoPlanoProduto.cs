﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class RiscoPlanoProduto
    {
        [StringLength(50)]
        public string IdRiscoPlanoProduto { get; set; }
        [Column("NivelRiscoID")]
        [StringLength(50)]
        public string NivelRiscoId { get; set; }
        [Column("PlanoProdutoID")]
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("RiscoPlanoProduto")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("NivelRiscoId")]
        [InverseProperty("RiscoPlanoProduto")]
        public virtual NivelRisco NivelRisco { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("RiscoPlanoProduto")]
        public virtual PlanoProduto PlanoProduto { get; set; }
    }
}