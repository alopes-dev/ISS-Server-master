﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            EstadoCivilPlano = new HashSet<EstadoCivilPlano>();
            Pessoa = new HashSet<Pessoa>();
        }

        [StringLength(50)]
        public string IdEstadoCivil { get; set; }
        [StringLength(2048)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodEstadoCivil { get; set; }
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
        [InverseProperty("EstadoCivil")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("EstadoCivil")]
        public virtual ICollection<EstadoCivilPlano> EstadoCivilPlano { get; set; }
        [InverseProperty("EstadoCivil")]
        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}