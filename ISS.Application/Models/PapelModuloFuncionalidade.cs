﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class PapelModuloFuncionalidade
    {
        public PapelModuloFuncionalidade()
        {
            ProcessoFuncionalidade = new HashSet<ProcessoFuncionalidade>();
        }

        [StringLength(50)]
        public string IdPapelModuloFuncionalidade { get; set; }
        [StringLength(50)]
        public string Designacao { get; set; }
        [StringLength(50)]
        public string FuncionalidadeId { get; set; }
        [StringLength(50)]
        public string PapelModuloPessoaId { get; set; }
        [StringLength(50)]
        public string CodPapelModuloFuncionalidade { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("PapelModuloFuncionalidade")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("FuncionalidadeId")]
        [InverseProperty("PapelModuloFuncionalidade")]
        public virtual Funcionalidade Funcionalidade { get; set; }
        [ForeignKey("PapelModuloPessoaId")]
        [InverseProperty("PapelModuloFuncionalidade")]
        public virtual PapelModuloPessoa PapelModuloPessoa { get; set; }
        [InverseProperty("PapelModuloFuncionalidade")]
        public virtual ICollection<ProcessoFuncionalidade> ProcessoFuncionalidade { get; set; }
    }
}