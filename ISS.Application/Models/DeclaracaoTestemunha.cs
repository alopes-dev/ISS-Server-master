﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class DeclaracaoTestemunha
    {
        public DeclaracaoTestemunha()
        {
            Testemunha = new HashSet<Testemunha>();
        }

        [StringLength(50)]
        public string IdDeclaracaoTestemunha { get; set; }
        [StringLength(50)]
        public string PessoaId { get; set; }
        [StringLength(50)]
        public string CodDeclaracaoTestemunha { get; set; }
        [StringLength(300)]
        public string Declaracoes { get; set; }
        [StringLength(50)]
        public string SinistroId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }

        [ForeignKey("PessoaId")]
        [InverseProperty("DeclaracaoTestemunha")]
        public virtual Pessoa Pessoa { get; set; }
        [ForeignKey("SinistroId")]
        [InverseProperty("DeclaracaoTestemunha")]
        public virtual Sinistro Sinistro { get; set; }
        [InverseProperty("DeclaracaoTestemunha")]
        public virtual ICollection<Testemunha> Testemunha { get; set; }
    }
}