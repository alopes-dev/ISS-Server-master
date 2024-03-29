﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ItensExclusao
    {
        [StringLength(50)]
        public string IdItensExclusao { get; set; }
        [StringLength(50)]
        public string ExclusaoId { get; set; }
        [StringLength(50)]
        public string CodItensExclusao { get; set; }
        [StringLength(200)]
        public string Designacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ItensExclusao")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ExclusaoId")]
        [InverseProperty("ItensExclusao")]
        public virtual Exclusoes Exclusao { get; set; }
    }
}