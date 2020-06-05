﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Bairro = new HashSet<Bairro>();
            Balcao = new HashSet<Balcao>();
            LocaisDesconto = new HashSet<LocaisDesconto>();
            LocaisEncargo = new HashSet<LocaisEncargo>();
            LocaisFranquia = new HashSet<LocaisFranquia>();
            LocaisImposto = new HashSet<LocaisImposto>();
            LocaisLimiteCompetencia = new HashSet<LocaisLimiteCompetencia>();
            LocaisObjectivosComerciais = new HashSet<LocaisObjectivosComerciais>();
            LocaisOferta = new HashSet<LocaisOferta>();
        }

        [StringLength(50)]
        public string IdDistrito { get; set; }
        [StringLength(100)]
        public string NomeDistrito { get; set; }
        [Column("MunicipioID")]
        [StringLength(50)]
        public string MunicipioId { get; set; }
        [StringLength(10)]
        public string CodDistrito { get; set; }
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

        [ForeignKey("EstadoId")]
        [InverseProperty("Distrito")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("MunicipioId")]
        [InverseProperty("Distrito")]
        public virtual Municipio Municipio { get; set; }
        [InverseProperty("Distrito")]
        public virtual ICollection<Bairro> Bairro { get; set; }
        [InverseProperty("Distrito")]
        public virtual ICollection<Balcao> Balcao { get; set; }
        [InverseProperty("Distrito")]
        public virtual ICollection<LocaisDesconto> LocaisDesconto { get; set; }
        [InverseProperty("Distrito")]
        public virtual ICollection<LocaisEncargo> LocaisEncargo { get; set; }
        [InverseProperty("Distrito")]
        public virtual ICollection<LocaisFranquia> LocaisFranquia { get; set; }
        [InverseProperty("Distrito")]
        public virtual ICollection<LocaisImposto> LocaisImposto { get; set; }
        [InverseProperty("Distrito")]
        public virtual ICollection<LocaisLimiteCompetencia> LocaisLimiteCompetencia { get; set; }
        [InverseProperty("Distrito")]
        public virtual ICollection<LocaisObjectivosComerciais> LocaisObjectivosComerciais { get; set; }
        [InverseProperty("Distrito")]
        public virtual ICollection<LocaisOferta> LocaisOferta { get; set; }
    }
}