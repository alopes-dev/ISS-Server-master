﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class OrigemFabricoEmbalagem
    {
        public OrigemFabricoEmbalagem()
        {
            Instalacoes = new HashSet<Instalacoes>();
        }

        [StringLength(50)]
        public string IdOrigemFabricoEmbalagem { get; set; }
        [StringLength(300)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodOrigemFabricoEmbalagem { get; set; }
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
        [InverseProperty("OrigemFabricoEmbalagem")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("OrigemFabricoEmbalagem")]
        public virtual ICollection<Instalacoes> Instalacoes { get; set; }
    }
}