﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Sector
    {
        public Sector()
        {
            CentroCusto = new HashSet<CentroCusto>();
            CentroResponsabilidade = new HashSet<CentroResponsabilidade>();
            ChefeSector = new HashSet<ChefeSector>();
            Funcionario = new HashSet<Funcionario>();
            OperacoesCrudpessoa = new HashSet<OperacoesCrudpessoa>();
            Seccao = new HashSet<Seccao>();
        }

        [StringLength(50)]
        public string IdSector { get; set; }
        [StringLength(100)]
        public string NomeSector { get; set; }
        [Column("ContactoID")]
        [StringLength(50)]
        public string ContactoId { get; set; }
        [StringLength(10)]
        public string CodSector { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
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
        [StringLength(50)]
        public string DepartamentoId { get; set; }

        [ForeignKey("ContactoId")]
        [InverseProperty("Sector")]
        public virtual Contacto Contacto { get; set; }
        [ForeignKey("DepartamentoId")]
        [InverseProperty("Sector")]
        public virtual Departamento Departamento { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Sector")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("SubContaId")]
        [InverseProperty("Sector")]
        public virtual PlanoContas SubConta { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<CentroCusto> CentroCusto { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<CentroResponsabilidade> CentroResponsabilidade { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<ChefeSector> ChefeSector { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<Funcionario> Funcionario { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<OperacoesCrudpessoa> OperacoesCrudpessoa { get; set; }
        [InverseProperty("Sector")]
        public virtual ICollection<Seccao> Seccao { get; set; }
    }
}