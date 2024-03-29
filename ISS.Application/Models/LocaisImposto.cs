﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class LocaisImposto
    {
        [StringLength(50)]
        public string IdLocaisImposto { get; set; }
        [Column("RegiaoID")]
        [StringLength(50)]
        public string RegiaoId { get; set; }
        [Column("PaisID")]
        [StringLength(50)]
        public string PaisId { get; set; }
        [Column("ProvinciaID")]
        [StringLength(50)]
        public string ProvinciaId { get; set; }
        [Column("MunicipioID")]
        [StringLength(50)]
        public string MunicipioId { get; set; }
        [Column("DistritoID")]
        [StringLength(50)]
        public string DistritoId { get; set; }
        [Column("NivelAbrangenciaID")]
        [StringLength(50)]
        public string NivelAbrangenciaId { get; set; }
        [Column("ImpostoID")]
        [StringLength(50)]
        public string ImpostoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("DistritoId")]
        [InverseProperty("LocaisImposto")]
        public virtual Distrito Distrito { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("LocaisImposto")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ImpostoId")]
        [InverseProperty("LocaisImposto")]
        public virtual Imposto Imposto { get; set; }
        [ForeignKey("MunicipioId")]
        [InverseProperty("LocaisImposto")]
        public virtual Municipio Municipio { get; set; }
        [ForeignKey("NivelAbrangenciaId")]
        [InverseProperty("LocaisImposto")]
        public virtual NivelAbrangencia NivelAbrangencia { get; set; }
        [ForeignKey("PaisId")]
        [InverseProperty("LocaisImposto")]
        public virtual Pais Pais { get; set; }
        [ForeignKey("ProvinciaId")]
        [InverseProperty("LocaisImposto")]
        public virtual Provincia Provincia { get; set; }
        [ForeignKey("RegiaoId")]
        [InverseProperty("LocaisImposto")]
        public virtual Regiao Regiao { get; set; }
    }
}