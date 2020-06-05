﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ComponenteSalarialPessoa
    {
        [StringLength(50)]
        public string IdComponenteSalarialPessoa { get; set; }
        public double? ValorSubsidio { get; set; }
        [Column("TipoSubsidioSalarialID")]
        [StringLength(50)]
        public string TipoSubsidioSalarialId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string IdSalarioPessoa { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ComponenteSalarialPessoa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("IdSalarioPessoa")]
        [InverseProperty("ComponenteSalarialPessoa")]
        public virtual RendimentoPessoa IdSalarioPessoaNavigation { get; set; }
        [ForeignKey("TipoSubsidioSalarialId")]
        [InverseProperty("ComponenteSalarialPessoa")]
        public virtual TipoSubsidioSalarial TipoSubsidioSalarial { get; set; }
    }
}