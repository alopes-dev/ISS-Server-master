﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class VantagemPlano
    {
        [StringLength(50)]
        public string IdVantagemPlano { get; set; }
        [StringLength(300)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column("DataATualizacao", TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CodVantagemPlano { get; set; }
        [StringLength(300)]
        public string Descricao { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("VantagemPlano")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("VantagemPlano")]
        public virtual PlanoProduto PlanoProduto { get; set; }
    }
}