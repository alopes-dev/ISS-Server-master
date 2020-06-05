﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Area
    {
        public Area()
        {
            CentroCusto = new HashSet<CentroCusto>();
            CentroResponsabilidade = new HashSet<CentroResponsabilidade>();
            CompetenciaArea = new HashSet<CompetenciaArea>();
            Funcionario = new HashSet<Funcionario>();
            ObjectivosArea = new HashSet<ObjectivosArea>();
            OperacoesCrudpessoa = new HashSet<OperacoesCrudpessoa>();
        }

        [StringLength(50)]
        public string IdArea { get; set; }
        [StringLength(10)]
        public string CodArea { get; set; }
        [StringLength(1000)]
        public string Ambito { get; set; }
        [StringLength(100)]
        public string NomeArea { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [Column("SubContaID")]
        [StringLength(50)]
        public string SubContaId { get; set; }
        [Required]
        public bool? Contabiliza { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("Area")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("SubContaId")]
        [InverseProperty("Area")]
        public virtual PlanoContas SubConta { get; set; }
        [InverseProperty("Area")]
        public virtual ICollection<CentroCusto> CentroCusto { get; set; }
        [InverseProperty("Area")]
        public virtual ICollection<CentroResponsabilidade> CentroResponsabilidade { get; set; }
        [InverseProperty("Area")]
        public virtual ICollection<CompetenciaArea> CompetenciaArea { get; set; }
        [InverseProperty("Area")]
        public virtual ICollection<Funcionario> Funcionario { get; set; }
        [InverseProperty("Area")]
        public virtual ICollection<ObjectivosArea> ObjectivosArea { get; set; }
        [InverseProperty("Area")]
        public virtual ICollection<OperacoesCrudpessoa> OperacoesCrudpessoa { get; set; }
    }
}