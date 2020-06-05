﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ModeloMapa
    {
        public ModeloMapa()
        {
            Mapa = new HashSet<Mapa>();
        }

        [StringLength(50)]
        public string IdModeloMapa { get; set; }
        [StringLength(10)]
        public string CodModeloMapa { get; set; }
        [StringLength(200)]
        public string NomeMapa { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string OrgaoRegularizadorId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ModeloMapa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("OrgaoRegularizadorId")]
        [InverseProperty("ModeloMapa")]
        public virtual OrgaoRegularizador OrgaoRegularizador { get; set; }
        [InverseProperty("ModeloMapa")]
        public virtual ICollection<Mapa> Mapa { get; set; }
    }
}