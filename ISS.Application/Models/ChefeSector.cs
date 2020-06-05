﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ChefeSector
    {
        [StringLength(50)]
        public string IdChefeDepartamento { get; set; }
        [Column("SectorID")]
        [StringLength(50)]
        public string SectorId { get; set; }
        [Column("ChefeID")]
        [StringLength(50)]
        public string ChefeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }

        [ForeignKey("ChefeId")]
        [InverseProperty("ChefeSector")]
        public virtual Funcionario Chefe { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("ChefeSector")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("SectorId")]
        [InverseProperty("ChefeSector")]
        public virtual Sector Sector { get; set; }
    }
}