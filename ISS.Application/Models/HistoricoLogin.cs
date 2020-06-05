﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class HistoricoLogin
    {
        [StringLength(50)]
        public string IdHistoricoLogin { get; set; }
        [StringLength(40)]
        public string IpMaquina { get; set; }
        [StringLength(100)]
        public string NomePais { get; set; }
        [StringLength(100)]
        public string Navegador { get; set; }
        [StringLength(100)]
        public string SistemaOperativo { get; set; }
        [StringLength(100)]
        public string Aplicativo { get; set; }
        [StringLength(100)]
        public string VersaoCliente { get; set; }
        [Column("TipoAPI")]
        [StringLength(100)]
        public string TipoApi { get; set; }
        [Column("VersaoAPI")]
        [StringLength(100)]
        public string VersaoApi { get; set; }
        [Column("URLLogin")]
        [StringLength(500)]
        public string Urllogin { get; set; }
        [StringLength(300)]
        public string TipoLogin { get; set; }
        [Column("HTTPMetodo")]
        [StringLength(300)]
        public string Httpmetodo { get; set; }
        [Required]
        public bool? Estado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataHoraLogin { get; set; }
        public string UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        [InverseProperty("HistoricoLogin")]
        public virtual Usuario Usuario { get; set; }
    }
}