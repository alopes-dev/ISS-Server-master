﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class CoberturaSelecionada
    {
        public CoberturaSelecionada()
        {
            ConsumoPlafond = new HashSet<ConsumoPlafond>();
        }

        [StringLength(50)]
        public string IdCoberturaSelecionada { get; set; }
        [Column("CotacaoID")]
        [StringLength(50)]
        public string CotacaoId { get; set; }
        public double? PorAnuidade { get; set; }
        public double? PorCadaSinistro { get; set; }
        public double? PorCadaPessoaSinistrada { get; set; }
        public double? PorDanosCoisasAnimais { get; set; }
        public bool? Personalizado { get; set; }
        public double? ValorPersonalizado { get; set; }
        public double? CoPagamento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CoberturaPlanoId { get; set; }
        [StringLength(100)]
        public string NaturezaRisco { get; set; }
        [StringLength(50)]
        public string ObjectoSeguradoId { get; set; }
        [StringLength(50)]
        public string PessoaId { get; set; }

        [ForeignKey("CoberturaPlanoId")]
        [InverseProperty("CoberturaSelecionada")]
        public virtual CoberturaPlano CoberturaPlano { get; set; }
        [ForeignKey("CotacaoId")]
        [InverseProperty("CoberturaSelecionada")]
        public virtual Cotacao Cotacao { get; set; }
        [ForeignKey("ObjectoSeguradoId")]
        [InverseProperty("CoberturaSelecionada")]
        public virtual ObjectoSegurado ObjectoSegurado { get; set; }
        [ForeignKey("PessoaId")]
        [InverseProperty("CoberturaSelecionada")]
        public virtual Pessoa Pessoa { get; set; }
        [InverseProperty("CoberturaSeleccionada")]
        public virtual ICollection<ConsumoPlafond> ConsumoPlafond { get; set; }
    }
}