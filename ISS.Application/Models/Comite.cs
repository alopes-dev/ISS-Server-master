﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Comite
    {
        [StringLength(50)]
        public string IdComite { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string SubContaId { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        [InverseProperty("Comite")]
        public virtual Empresa Empresa { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Comite")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("SubContaId")]
        [InverseProperty("Comite")]
        public virtual PlanoContas SubConta { get; set; }
    }
}