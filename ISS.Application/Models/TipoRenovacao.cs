﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoRenovacao
    {
        public TipoRenovacao()
        {
            RenovacaoApolice = new HashSet<RenovacaoApolice>();
        }

        [StringLength(50)]
        public string IdTipoRenovacao { get; set; }
        [StringLength(2048)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodTipoRenovacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(500)]
        public string CaminhoIcone { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoRenovacao")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoRenovacao")]
        public virtual ICollection<RenovacaoApolice> RenovacaoApolice { get; set; }
    }
}