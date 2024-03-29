﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class DirectorDireccao
    {
        [StringLength(50)]
        public string IdDirectorDireccao { get; set; }
        [Column("DireccaoID")]
        [StringLength(50)]
        public string DireccaoId { get; set; }
        [Column("DirectorID")]
        [StringLength(50)]
        public string DirectorId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("DireccaoId")]
        [InverseProperty("DirectorDireccao")]
        public virtual Direccao Direccao { get; set; }
        [ForeignKey("DirectorId")]
        [InverseProperty("DirectorDireccao")]
        public virtual Funcionario Director { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("DirectorDireccao")]
        public virtual Estado Estado { get; set; }
    }
}