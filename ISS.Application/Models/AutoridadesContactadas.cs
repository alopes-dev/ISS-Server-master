﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class AutoridadesContactadas
    {
        [StringLength(50)]
        public string IdAutoridadeContactada { get; set; }
        [Column("NomeEntidadeID")]
        [StringLength(50)]
        public string NomeEntidadeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataContacto { get; set; }
        [Column("CorrespondenciaID")]
        [StringLength(50)]
        public string CorrespondenciaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HoraContacto { get; set; }
        [StringLength(10)]
        public string CodAutoridadesContactadasQuestionario { get; set; }
        [Column("SinistroID")]
        [StringLength(50)]
        public string SinistroId { get; set; }
        [StringLength(10)]
        public string CodAutoridadesContactadas { get; set; }
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

        [ForeignKey("CorrespondenciaId")]
        [InverseProperty("AutoridadesContactadasCorrespondencia")]
        public virtual Estado Correspondencia { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("AutoridadesContactadasEstado")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("NomeEntidadeId")]
        [InverseProperty("AutoridadesContactadas")]
        public virtual TipoAutoridade NomeEntidade { get; set; }
        [ForeignKey("SinistroId")]
        [InverseProperty("AutoridadesContactadas")]
        public virtual Sinistro Sinistro { get; set; }
    }
}