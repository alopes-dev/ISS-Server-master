﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class RecorrenciaMesAno
    {
        [StringLength(50)]
        public string IdRecorrenciaMesAno { get; set; }
        [StringLength(50)]
        public string PadraoRecorrenciaId { get; set; }
        public int? NumeroInMesOuAno { get; set; }
        [StringLength(50)]
        public string DiaSemanaRecorrencia { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        public int? RegenerarNovaTarefaNum { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("RecorrenciaMesAno")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PadraoRecorrenciaId")]
        [InverseProperty("RecorrenciaMesAno")]
        public virtual PadraoRecorrencia PadraoRecorrencia { get; set; }
    }
}