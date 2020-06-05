﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoPerda
    {
        public TipoPerda()
        {
            Perda = new HashSet<Perda>();
        }

        [StringLength(50)]
        public string IdTipoPerda { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodTipoPerda { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(500)]
        public string CaminhoIcone { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoPerda")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoPerda")]
        public virtual ICollection<Perda> Perda { get; set; }
    }
}