﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class PessoaTarefa
    {
        [StringLength(50)]
        public string IdPessoaTarefa { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataInicio { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataFim { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataUltAtualizacao { get; set; }
        public double? Metrica { get; set; }
        [Column("TarefaID")]
        [StringLength(50)]
        public string TarefaId { get; set; }
        [Column("ResponsavelID")]
        [StringLength(50)]
        public string ResponsavelId { get; set; }
        [Column("DepartamentoID")]
        [StringLength(50)]
        public string DepartamentoId { get; set; }
        [Column("SeccaoID")]
        [StringLength(50)]
        public string SeccaoId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("ProdutoID")]
        [StringLength(50)]
        public string ProdutoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("LinhaProdutoID")]
        [StringLength(50)]
        public string LinhaProdutoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [StringLength(50)]
        public string CodPessoaTarefa { get; set; }

        [ForeignKey("DepartamentoId")]
        [InverseProperty("PessoaTarefa")]
        public virtual Departamento Departamento { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("PessoaTarefa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("LinhaProdutoId")]
        [InverseProperty("PessoaTarefa")]
        public virtual LinhaProduto LinhaProduto { get; set; }
        [ForeignKey("ProdutoId")]
        [InverseProperty("PessoaTarefa")]
        public virtual Produto Produto { get; set; }
        [ForeignKey("ResponsavelId")]
        [InverseProperty("PessoaTarefa")]
        public virtual Pessoa Responsavel { get; set; }
        [ForeignKey("SeccaoId")]
        [InverseProperty("PessoaTarefa")]
        public virtual Seccao Seccao { get; set; }
        [ForeignKey("TarefaId")]
        [InverseProperty("PessoaTarefa")]
        public virtual Tarefa Tarefa { get; set; }
    }
}