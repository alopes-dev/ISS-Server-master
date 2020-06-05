﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoTarifasResponsabilidade
    {
        public TipoTarifasResponsabilidade()
        {
            TarifasResponsabilidadeCivil = new HashSet<TarifasResponsabilidadeCivil>();
        }

        [StringLength(50)]
        public string IdTipoTarifasResponsabilidade { get; set; }
        [StringLength(200)]
        public string Designacao { get; set; }
        [StringLength(10)]
        public string CodTipoTarifasResponsabilidade { get; set; }
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
        [InverseProperty("TipoTarifasResponsabilidade")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoTarifasResponsabilidade")]
        public virtual ICollection<TarifasResponsabilidadeCivil> TarifasResponsabilidadeCivil { get; set; }
    }
}