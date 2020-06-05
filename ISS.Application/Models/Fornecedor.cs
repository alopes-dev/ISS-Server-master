﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Fornecedor
    {
        [StringLength(50)]
        public string IdFornecedor { get; set; }
        [StringLength(50)]
        public string PessoaId { get; set; }
        [StringLength(50)]
        public string CodFornecedor { get; set; }
        [StringLength(50)]
        public string SinistroId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string ApoliceId { get; set; }

        [ForeignKey("ApoliceId")]
        [InverseProperty("Fornecedor")]
        public virtual Apolice Apolice { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Fornecedor")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PessoaId")]
        [InverseProperty("Fornecedor")]
        public virtual Pessoa Pessoa { get; set; }
        [ForeignKey("SinistroId")]
        [InverseProperty("Fornecedor")]
        public virtual Sinistro Sinistro { get; set; }
    }
}