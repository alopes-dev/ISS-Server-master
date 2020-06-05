﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Motorista
    {
        [StringLength(50)]
        public string IdMotorista { get; set; }
        [StringLength(50)]
        public string PessoaId { get; set; }
        [StringLength(50)]
        public string CodMotorista { get; set; }
        [StringLength(50)]
        public string SinistroId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [StringLength(50)]
        public string AutomovelId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("AutomovelId")]
        [InverseProperty("Motorista")]
        public virtual Automovel Automovel { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Motorista")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PessoaId")]
        [InverseProperty("Motorista")]
        public virtual Pessoa Pessoa { get; set; }
        [ForeignKey("SinistroId")]
        [InverseProperty("Motorista")]
        public virtual Sinistro Sinistro { get; set; }
    }
}