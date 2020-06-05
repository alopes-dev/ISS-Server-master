﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class SubTarefa
    {
        public SubTarefa()
        {
            TarefasActividade = new HashSet<TarefasActividade>();
        }

        [StringLength(50)]
        public string IdSubTarefa { get; set; }
        [Column("PCFid")]
        [StringLength(20)]
        public string Pcfid { get; set; }
        [Column("HierarquiaID")]
        [StringLength(20)]
        public string HierarquiaId { get; set; }
        [StringLength(300)]
        public string Nome { get; set; }
        [StringLength(2)]
        public string MetricaDisponivel { get; set; }
        public int? IndiceDiferenca { get; set; }
        [StringLength(4000)]
        public string DetalhesMudanca { get; set; }
        [Column("TarefaID")]
        [StringLength(50)]
        public string TarefaId { get; set; }
        [StringLength(10)]
        public string CodSubTarefa { get; set; }
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

        [ForeignKey("EstadoId")]
        [InverseProperty("SubTarefa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("TarefaId")]
        [InverseProperty("SubTarefa")]
        public virtual Tarefa Tarefa { get; set; }
        [InverseProperty("SubTarefa")]
        public virtual ICollection<TarefasActividade> TarefasActividade { get; set; }
    }
}