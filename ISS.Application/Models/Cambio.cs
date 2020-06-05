﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Cambio
    {
        public Cambio()
        {
            PrecosAtosMedicos = new HashSet<PrecosAtosMedicos>();
        }

        [StringLength(50)]
        public string IdCambio { get; set; }
        [Column("MoedaID")]
        [StringLength(50)]
        public string MoedaId { get; set; }
        public double? DivisaCompra { get; set; }
        public double? DivisaVenda { get; set; }
        public double? NotasCompra { get; set; }
        public double? NotasVenda { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        public double? Spreed { get; set; }
        [Column("MoedaBaseID")]
        [StringLength(50)]
        public string MoedaBaseId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("Cambio")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("MoedaId")]
        [InverseProperty("CambioMoeda")]
        public virtual Moeda Moeda { get; set; }
        [ForeignKey("MoedaBaseId")]
        [InverseProperty("CambioMoedaBase")]
        public virtual Moeda MoedaBase { get; set; }
        [InverseProperty("IdCambioNavigation")]
        public virtual ICollection<PrecosAtosMedicos> PrecosAtosMedicos { get; set; }
    }
}