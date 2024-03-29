﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class HistoricoContadoresRegistos
    {
        [Column("HistoricoContadoresRegistos")]
        [StringLength(50)]
        public string HistoricoContadoresRegistos1 { get; set; }
        [StringLength(50)]
        public string CodContadoresRegistos { get; set; }
        [StringLength(80)]
        public string Designacao { get; set; }
        public int? NumRegisto { get; set; }
        [StringLength(4)]
        public string Ano { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string IdContadoresRegistos { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("HistoricoContadoresRegistos")]
        public virtual Estado Estado { get; set; }
    }
}