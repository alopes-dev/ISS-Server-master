﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Rua
    {
        public Rua()
        {
            Endereco = new HashSet<Endereco>();
        }

        [StringLength(50)]
        public string IdRua { get; set; }
        [StringLength(100)]
        public string NomeRua { get; set; }
        [StringLength(10)]
        public string CodRua { get; set; }
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
        [StringLength(50)]
        public string BairroId { get; set; }

        [ForeignKey("BairroId")]
        [InverseProperty("Rua")]
        public virtual Bairro Bairro { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Rua")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("Rua")]
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}