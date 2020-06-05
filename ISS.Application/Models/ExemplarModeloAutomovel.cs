﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ExemplarModeloAutomovel
    {
        public ExemplarModeloAutomovel()
        {
            Automovel = new HashSet<Automovel>();
        }

        [StringLength(50)]
        public string IdExemplar { get; set; }
        [StringLength(300)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Referencia { get; set; }
        public int? AnoFabrico { get; set; }
        [Column("ModeloAutomovelID")]
        [StringLength(50)]
        public string ModeloAutomovelId { get; set; }
        [Column("CombustivelID")]
        [StringLength(50)]
        public string CombustivelId { get; set; }
        [StringLength(10)]
        public string CodExemplarModeloAutomovel { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("CombustivelId")]
        [InverseProperty("ExemplarModeloAutomovel")]
        public virtual Combustivel Combustivel { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("ExemplarModeloAutomovel")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ModeloAutomovelId")]
        [InverseProperty("ExemplarModeloAutomovel")]
        public virtual ModeloAutomovel ModeloAutomovel { get; set; }
        [InverseProperty("ExemplarModelo")]
        public virtual ICollection<Automovel> Automovel { get; set; }
    }
}