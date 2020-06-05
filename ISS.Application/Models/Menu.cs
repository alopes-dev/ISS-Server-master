﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Menu
    {
        public Menu()
        {
            CanalMenu = new HashSet<CanalMenu>();
            InverseNivelPai = new HashSet<Menu>();
            SubMenu = new HashSet<SubMenu>();
        }

        [StringLength(50)]
        public string IdMenu { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Path { get; set; }
        [StringLength(50)]
        public string PapelId { get; set; }
        [StringLength(100)]
        public string DesignacaoModulo { get; set; }
        [StringLength(100)]
        public string Icon { get; set; }
        [StringLength(200)]
        public string Legenda { get; set; }
        [StringLength(50)]
        public string LicencaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string NivelPaiId { get; set; }
        public int? NumOrdem { get; set; }
        public bool? Collapse { get; set; }
        [StringLength(100)]
        public string State { get; set; }
        [StringLength(100)]
        public string Layout { get; set; }
        [StringLength(100)]
        public string Component { get; set; }
        [StringLength(50)]
        public string CodMenu { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("Menu")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("LicencaId")]
        [InverseProperty("Menu")]
        public virtual Licenca Licenca { get; set; }
        [ForeignKey("NivelPaiId")]
        [InverseProperty("InverseNivelPai")]
        public virtual Menu NivelPai { get; set; }
        [ForeignKey("PapelId")]
        [InverseProperty("Menu")]
        public virtual Papel Papel { get; set; }
        [InverseProperty("Menu")]
        public virtual ICollection<CanalMenu> CanalMenu { get; set; }
        [InverseProperty("NivelPai")]
        public virtual ICollection<Menu> InverseNivelPai { get; set; }
        [InverseProperty("Menu")]
        public virtual ICollection<SubMenu> SubMenu { get; set; }
    }
}