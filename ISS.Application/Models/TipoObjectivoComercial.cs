﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoObjectivoComercial
    {
        public TipoObjectivoComercial()
        {
            ObjectivoComercial = new HashSet<ObjectivoComercial>();
        }

        [StringLength(50)]
        public string IdTipoObjectivoComercial { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string CodTipoObjectivoComercial { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoObjectivoComercial")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoObjectivoComercial")]
        public virtual ICollection<ObjectivoComercial> ObjectivoComercial { get; set; }
    }
}