﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ObjectoTrabalhoPessoa
    {
        [StringLength(50)]
        public string IdObjectoTrabalhoPessoa { get; set; }
        [Column("ObjectoTrabalhoID")]
        [StringLength(50)]
        public string ObjectoTrabalhoId { get; set; }
        [StringLength(50)]
        public string PessoaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CodObjectoTrabalhoPessoa { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ObjectoTrabalhoPessoa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ObjectoTrabalhoId")]
        [InverseProperty("ObjectoTrabalhoPessoa")]
        public virtual ObjectoTrabalho ObjectoTrabalho { get; set; }
        [ForeignKey("PessoaId")]
        [InverseProperty("ObjectoTrabalhoPessoa")]
        public virtual Pessoa Pessoa { get; set; }
    }
}