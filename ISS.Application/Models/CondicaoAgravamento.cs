﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CondicaoAgravamento
    {
        public CondicaoAgravamento()
        {
            CondicaoAplicacaoAgravamento = new HashSet<CondicaoAplicacaoAgravamento>();
        }

        [StringLength(50)]
        public string IdCondicaoAgravamento { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string CodCondicaoAgravamento { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        public double? Franquia { get; set; }
        public double? CapitalSeguro { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("CondicaoAgravamento")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("CondicaoAgravamento")]
        public virtual ICollection<CondicaoAplicacaoAgravamento> CondicaoAplicacaoAgravamento { get; set; }
    }
}