﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Pneu
    {
        [StringLength(50)]
        public string IdPneu { get; set; }
        [Column("TipoConstrucaoPneusID")]
        [StringLength(50)]
        public string TipoConstrucaoPneusId { get; set; }
        [Column("IndiceVelocidadePneuID")]
        [StringLength(50)]
        public string IndiceVelocidadePneuId { get; set; }
        [Column("IndiceCargaPneuID")]
        [StringLength(50)]
        public string IndiceCargaPneuId { get; set; }
        [Column("LocalizacaoPneuID")]
        [StringLength(50)]
        public string LocalizacaoPneuId { get; set; }
        [StringLength(50)]
        public string AutomovelId { get; set; }
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

        [ForeignKey("AutomovelId")]
        [InverseProperty("Pneu")]
        public virtual Automovel Automovel { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Pneu")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("IndiceCargaPneuId")]
        [InverseProperty("Pneu")]
        public virtual IndiceCargaPneu IndiceCargaPneu { get; set; }
        [ForeignKey("IndiceVelocidadePneuId")]
        [InverseProperty("Pneu")]
        public virtual IndiceVelocidadePneu IndiceVelocidadePneu { get; set; }
        [ForeignKey("LocalizacaoPneuId")]
        [InverseProperty("Pneu")]
        public virtual LocalizacaoPneu LocalizacaoPneu { get; set; }
        [ForeignKey("TipoConstrucaoPneusId")]
        [InverseProperty("Pneu")]
        public virtual TipoConstrucaoPneus TipoConstrucaoPneus { get; set; }
    }
}