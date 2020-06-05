﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class FormaTermino
    {
        public FormaTermino()
        {
            IntervaloRecorrencia = new HashSet<IntervaloRecorrencia>();
        }

        [StringLength(50)]
        public string IdFormaTermino { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataTermino { get; set; }
        public int? NumOcorrencia { get; set; }
        [StringLength(50)]
        public string TipoTerminoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("FormaTermino")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("TipoTerminoId")]
        [InverseProperty("FormaTermino")]
        public virtual TipoTermino TipoTermino { get; set; }
        [InverseProperty("FormaTermino")]
        public virtual ICollection<IntervaloRecorrencia> IntervaloRecorrencia { get; set; }
    }
}