﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TituloDesvalorizacaoInvalidezPermanente
    {
        public TituloDesvalorizacaoInvalidezPermanente()
        {
            SubTituloDesvalorizacaoInvalidezPermanente = new HashSet<SubTituloDesvalorizacaoInvalidezPermanente>();
        }

        [StringLength(50)]
        public string IdTituloDesvalorizacao { get; set; }
        [StringLength(2048)]
        public string Designacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TituloDesvalorizacaoInvalidezPermanente")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TituloDesvalorizacao")]
        public virtual ICollection<SubTituloDesvalorizacaoInvalidezPermanente> SubTituloDesvalorizacaoInvalidezPermanente { get; set; }
    }
}