﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoRendimento
    {
        public TipoRendimento()
        {
            RendimentoPessoa = new HashSet<RendimentoPessoa>();
        }

        [StringLength(50)]
        public string IdTipoRendimento { get; set; }
        [StringLength(50)]
        public string CodTipoRendimento { get; set; }
        [StringLength(100)]
        public string Designacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoRendimento")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoRendimento")]
        public virtual ICollection<RendimentoPessoa> RendimentoPessoa { get; set; }
    }
}