﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoCartaConducao
    {
        public TipoCartaConducao()
        {
            CartaConducao = new HashSet<CartaConducao>();
        }

        [StringLength(50)]
        public string IdTipo { get; set; }
        [StringLength(2048)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodTipoCartaConducao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(500)]
        public string CaminhoIcone { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoCartaConducao")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoCartaConducao")]
        public virtual ICollection<CartaConducao> CartaConducao { get; set; }
    }
}