﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Bairro
    {
        public Bairro()
        {
            Comuna = new HashSet<Comuna>();
            Endereco = new HashSet<Endereco>();
            Rua = new HashSet<Rua>();
        }

        [StringLength(50)]
        public string IdBairro { get; set; }
        [StringLength(100)]
        public string NomeBairro { get; set; }
        [Column("DistritoID")]
        [StringLength(50)]
        public string DistritoId { get; set; }
        [StringLength(10)]
        public string CodBairro { get; set; }
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

        [ForeignKey("DistritoId")]
        [InverseProperty("Bairro")]
        public virtual Distrito Distrito { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Bairro")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("Bairro")]
        public virtual ICollection<Comuna> Comuna { get; set; }
        [InverseProperty("Bairro")]
        public virtual ICollection<Endereco> Endereco { get; set; }
        [InverseProperty("Bairro")]
        public virtual ICollection<Rua> Rua { get; set; }
    }
}