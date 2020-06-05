﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class InformacaoBancariaContrato
    {
        [StringLength(50)]
        public string IdInformacaoBancariaContrato { get; set; }
        [StringLength(50)]
        public string InformacaoBancariaId { get; set; }
        [StringLength(50)]
        public string ContratoId { get; set; }
        [StringLength(50)]
        public string CodInformacaoBancariaContrato { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }

        [ForeignKey("ContratoId")]
        [InverseProperty("InformacaoBancariaContrato")]
        public virtual Contrato Contrato { get; set; }
        [ForeignKey("InformacaoBancariaId")]
        [InverseProperty("InformacaoBancariaContrato")]
        public virtual InformacaoBancaria InformacaoBancaria { get; set; }
    }
}