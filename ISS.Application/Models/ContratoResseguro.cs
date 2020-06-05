﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ContratoResseguro
    {
        public ContratoResseguro()
        {
            AssinantesResseguro = new HashSet<AssinantesResseguro>();
        }

        [StringLength(50)]
        public string IdContratoResseguro { get; set; }
        [StringLength(50)]
        public string ContratoId { get; set; }
        [StringLength(50)]
        public string ResseguroId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        public double? Retencao { get; set; }

        [ForeignKey("ContratoId")]
        [InverseProperty("ContratoResseguro")]
        public virtual Contrato Contrato { get; set; }
        [ForeignKey("ResseguroId")]
        [InverseProperty("ContratoResseguro")]
        public virtual Resseguro Resseguro { get; set; }
        [InverseProperty("ContratoResseguro")]
        public virtual ICollection<AssinantesResseguro> AssinantesResseguro { get; set; }
    }
}