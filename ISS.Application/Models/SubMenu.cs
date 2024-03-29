﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class SubMenu
    {
        public SubMenu()
        {
            CanalMenu = new HashSet<CanalMenu>();
        }

        [StringLength(50)]
        public string IdSubMenu { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string CodSubMenu { get; set; }
        [StringLength(50)]
        public string Path { get; set; }
        [StringLength(50)]
        public string Legenda { get; set; }
        [StringLength(50)]
        public string MenuId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }

        [ForeignKey("MenuId")]
        [InverseProperty("SubMenu")]
        public virtual Menu Menu { get; set; }
        [InverseProperty("SubMenu")]
        public virtual ICollection<CanalMenu> CanalMenu { get; set; }
    }
}