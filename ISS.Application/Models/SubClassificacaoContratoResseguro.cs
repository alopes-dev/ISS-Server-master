﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class SubClassificacaoContratoResseguro
    {
        [StringLength(50)]
        public string IdSubClassificacaoContratoResseguro { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string CodSubClassificacaoContratoResseguro { get; set; }
        [StringLength(50)]
        public string ClassificacaoContratoResseguroId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }

        [ForeignKey("ClassificacaoContratoResseguroId")]
        [InverseProperty("SubClassificacaoContratoResseguro")]
        public virtual ClassificacaoContratoResseguro ClassificacaoContratoResseguro { get; set; }
    }
}