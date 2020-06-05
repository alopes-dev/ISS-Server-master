﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Endereco = new HashSet<Endereco>();
        }

        [StringLength(50)]
        public string IdCidade { get; set; }
        [StringLength(100)]
        public string CodCidade { get; set; }
        [StringLength(100)]
        public string NomeCidade { get; set; }
        [Column("ProvinciaID")]
        [StringLength(50)]
        public string ProvinciaId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("Cidade")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ProvinciaId")]
        [InverseProperty("Cidade")]
        public virtual Provincia Provincia { get; set; }
        [InverseProperty("Cidade")]
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}