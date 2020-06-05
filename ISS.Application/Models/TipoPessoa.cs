﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class TipoPessoa
    {
        public TipoPessoa()
        {
            FormaContratacao = new HashSet<FormaContratacao>();
            PessoaNavigation = new HashSet<Pessoa>();
            PessoasPos = new HashSet<PessoasPos>();
            TipoContratacao = new HashSet<TipoContratacao>();
            TipoGrupo = new HashSet<TipoGrupo>();
            TipoPessoaPlano = new HashSet<TipoPessoaPlano>();
            TipoRegime = new HashSet<TipoRegime>();
            TipoSegmento = new HashSet<TipoSegmento>();
        }

        [StringLength(50)]
        public string IdTipoPessoa { get; set; }
        [StringLength(50)]
        public string Pessoa { get; set; }
        [StringLength(50)]
        public string CodTipoPessoa { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("TipoPessoa")]
        public virtual Estado Estado { get; set; }
        [InverseProperty("TipoPessoa")]
        public virtual ICollection<FormaContratacao> FormaContratacao { get; set; }
        [InverseProperty("TipoPessoa")]
        public virtual ICollection<Pessoa> PessoaNavigation { get; set; }
        [InverseProperty("TipoPessoa")]
        public virtual ICollection<PessoasPos> PessoasPos { get; set; }
        [InverseProperty("TipoPessoa")]
        public virtual ICollection<TipoContratacao> TipoContratacao { get; set; }
        [InverseProperty("TipoPessoa")]
        public virtual ICollection<TipoGrupo> TipoGrupo { get; set; }
        [InverseProperty("TipoPessoa")]
        public virtual ICollection<TipoPessoaPlano> TipoPessoaPlano { get; set; }
        [InverseProperty("TipoPessoa")]
        public virtual ICollection<TipoRegime> TipoRegime { get; set; }
        [InverseProperty("TipoPessoa")]
        public virtual ICollection<TipoSegmento> TipoSegmento { get; set; }
    }
}