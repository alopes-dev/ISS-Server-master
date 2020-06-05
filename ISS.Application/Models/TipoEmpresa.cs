﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoEmpresa
    {
        public TipoEmpresa()
        {
            DimensaoEmpresa = new HashSet<DimensaoEmpresa>();
        }

        [StringLength(50)]
        public string IdTipoEmpresa { get; set; }
        [StringLength(10)]
        public string CodTipoEmpresa { get; set; }
        [StringLength(300)]
        public string Designacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(500)]
        public string CaminhoIcone { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoEmpresa")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoEmpresa")]
        public virtual ICollection<DimensaoEmpresa> DimensaoEmpresa { get; set; }
    }
}