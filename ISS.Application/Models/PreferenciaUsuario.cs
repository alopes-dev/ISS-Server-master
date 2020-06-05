﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class PreferenciaUsuario
    {
        public PreferenciaUsuario()
        {
            InverseTipoPreferenciaUsuarioNavigation = new HashSet<PreferenciaUsuario>();
        }

        [StringLength(50)]
        public string IdPreferenciaUsuario { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string CodPreferenciaUsuario { get; set; }
        [StringLength(50)]
        public string PessoaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string TipoPreferenciaUsuario { get; set; }

        [ForeignKey("PessoaId")]
        [InverseProperty("PreferenciaUsuario")]
        public virtual Pessoa Pessoa { get; set; }
        [ForeignKey("TipoPreferenciaUsuario")]
        [InverseProperty("InverseTipoPreferenciaUsuarioNavigation")]
        public virtual PreferenciaUsuario TipoPreferenciaUsuarioNavigation { get; set; }
        [InverseProperty("TipoPreferenciaUsuarioNavigation")]
        public virtual ICollection<PreferenciaUsuario> InverseTipoPreferenciaUsuarioNavigation { get; set; }
    }
}