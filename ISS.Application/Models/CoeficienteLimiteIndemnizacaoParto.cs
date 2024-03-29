﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CoeficienteLimiteIndemnizacaoParto
    {
        [StringLength(50)]
        public string IdCoeficienteLimiteIndemnizacaoParto { get; set; }
        public double? Valor { get; set; }
        public double? AgravamentoOuDesconto { get; set; }
        [StringLength(50)]
        public string CodCoeficienteLimiteIndemnizacaoParto { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string TipoPartoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("CoeficienteLimiteIndemnizacaoParto")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("TipoPartoId")]
        [InverseProperty("CoeficienteLimiteIndemnizacaoParto")]
        public virtual TipoParto TipoParto { get; set; }
    }
}