﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ClasseConta
    {
        public ClasseConta()
        {
            PlanoContas = new HashSet<PlanoContas>();
        }

        [StringLength(50)]
        public string IdClasse { get; set; }
        [StringLength(50)]
        public string NumClasse { get; set; }
        [StringLength(2048)]
        public string Designacao { get; set; }
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
        [InverseProperty("ClasseConta")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("Classe")]
        public virtual ICollection<PlanoContas> PlanoContas { get; set; }
    }
}