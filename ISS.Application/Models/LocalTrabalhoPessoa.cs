﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class LocalTrabalhoPessoa
    {
        [StringLength(50)]
        public string IdLocalTrabalhoPessoa { get; set; }
        [Column("LocalTrabalhoID")]
        [StringLength(50)]
        public string LocalTrabalhoId { get; set; }
        [Column("PessoaProfissaoID")]
        [StringLength(50)]
        public string PessoaProfissaoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("LocalTrabalhoPessoa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("LocalTrabalhoId")]
        [InverseProperty("LocalTrabalhoPessoa")]
        public virtual LocalTrabalho LocalTrabalho { get; set; }
        [ForeignKey("PessoaProfissaoId")]
        [InverseProperty("LocalTrabalhoPessoa")]
        public virtual PessoaProfissao PessoaProfissao { get; set; }
    }
}