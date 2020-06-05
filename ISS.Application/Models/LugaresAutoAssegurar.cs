﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class LugaresAutoAssegurar
    {
        public LugaresAutoAssegurar()
        {
            Cotacao = new HashSet<Cotacao>();
        }

        [StringLength(50)]
        public string IdLugaresAutoAssegurar { get; set; }
        [StringLength(200)]
        public string Designacao { get; set; }
        public double TaxaAgravamento { get; set; }
        public int? MinLugares { get; set; }
        public int? MaxLugares { get; set; }
        [StringLength(10)]
        public string CodLugaresAutoAssegurar { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Required]
        public bool? IsTaxa { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("ClassificacaoAutomovelID")]
        [StringLength(50)]
        public string ClassificacaoAutomovelId { get; set; }

        [ForeignKey("ClassificacaoAutomovelId")]
        [InverseProperty("LugaresAutoAssegurar")]
        public virtual ClassificacaoAutomovel ClassificacaoAutomovel { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("LugaresAutoAssegurar")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("LugaresAutoAssegurar")]
        public virtual ICollection<Cotacao> Cotacao { get; set; }
    }
}