﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CondicoesApolice
    {
        [StringLength(50)]
        public string IdCondicao { get; set; }
        [Column("ApoliceID")]
        [StringLength(50)]
        public string ApoliceId { get; set; }
        [Column("CondicoesID")]
        [StringLength(50)]
        public string CondicoesId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("ApoliceId")]
        [InverseProperty("CondicoesApolice")]
        public virtual Apolice Apolice { get; set; }
        [ForeignKey("CondicoesId")]
        [InverseProperty("CondicoesApolice")]
        public virtual Condicoes Condicoes { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("CondicoesApolice")]
        public virtual Estado Estado { get; set; }
    }
}