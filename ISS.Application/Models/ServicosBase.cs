﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ServicosBase
    {
        [StringLength(50)]
        public string IdServicosBase { get; set; }
        [Column("OBS")]
        [StringLength(2048)]
        public string Obs { get; set; }
        [Column("PlanoProdutoID")]
        [StringLength(50)]
        public string PlanoProdutoId { get; set; }
        [StringLength(10)]
        public string CodServicosBase { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("ServicoID")]
        [StringLength(50)]
        public string ServicoId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [Column("CoberturaProdutoID")]
        [StringLength(50)]
        public string CoberturaProdutoId { get; set; }
        public double? Preco { get; set; }
        [StringLength(50)]
        public string MoedaId { get; set; }

        [ForeignKey("CoberturaProdutoId")]
        [InverseProperty("ServicosBase")]
        public virtual Cobertura CoberturaProduto { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("ServicosBase")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("MoedaId")]
        [InverseProperty("ServicosBase")]
        public virtual Moeda Moeda { get; set; }
        [ForeignKey("PlanoProdutoId")]
        [InverseProperty("ServicosBase")]
        public virtual PlanoProduto PlanoProduto { get; set; }
        [ForeignKey("ServicoId")]
        [InverseProperty("ServicosBase")]
        public virtual Servico Servico { get; set; }
    }
}