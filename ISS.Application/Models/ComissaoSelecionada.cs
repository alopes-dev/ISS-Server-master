﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ComissaoSelecionada
    {
        [StringLength(50)]
        public string IdComissaoSelecionada { get; set; }
        public double? ValorComissao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        public bool? Contabiliza { get; set; }
        [Column("ComissaoID")]
        [StringLength(50)]
        public string ComissaoId { get; set; }
        [StringLength(50)]
        public string ApoliceId { get; set; }
        [StringLength(50)]
        public string CodComissionamento { get; set; }
        [StringLength(50)]
        public string ProdutorId { get; set; }

        [ForeignKey("ApoliceId")]
        [InverseProperty("ComissaoSelecionada")]
        public virtual Apolice Apolice { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("ComissaoSelecionada")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ProdutorId")]
        [InverseProperty("ComissaoSelecionada")]
        public virtual Pessoa Produtor { get; set; }
    }
}