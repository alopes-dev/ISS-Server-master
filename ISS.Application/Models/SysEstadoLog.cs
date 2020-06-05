﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    [Table("Sys_EstadoLog")]
    public partial class SysEstadoLog
    {
        public SysEstadoLog()
        {
            SysLog = new HashSet<SysLog>();
        }

        public long IdEstado { get; set; }
        [Required]
        [StringLength(50)]
        public string Designacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("SysEstadoLog")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("LogEstadoNavigation")]
        public virtual ICollection<SysLog> SysLog { get; set; }
    }
}