﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoAprovacao
    {
        public TipoAprovacao()
        {
            ClassificacaoAprovacao = new HashSet<ClassificacaoAprovacao>();
        }

        [StringLength(50)]
        public string IdTipoAprovacao { get; set; }
        [StringLength(200)]
        public string Descricao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CodTipoAprovacao { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoAprovacao")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoAprovacao")]
        public virtual ICollection<ClassificacaoAprovacao> ClassificacaoAprovacao { get; set; }
    }
}