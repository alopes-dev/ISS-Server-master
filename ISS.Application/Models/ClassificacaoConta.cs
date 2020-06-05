﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ClassificacaoConta
    {
        public ClassificacaoConta()
        {
            PlanoContas = new HashSet<PlanoContas>();
        }

        [StringLength(50)]
        public string IdClassificacaoConta { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodClassificacaoConta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ClassificacaoConta")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("ClassificacaoConta")]
        public virtual ICollection<PlanoContas> PlanoContas { get; set; }
    }
}