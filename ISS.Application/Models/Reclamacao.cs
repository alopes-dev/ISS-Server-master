﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Reclamacao
    {
        public Reclamacao()
        {
            ContratoPrestadorEmpresa = new HashSet<ContratoPrestadorEmpresa>();
        }

        [StringLength(50)]
        public string IdReclamacao { get; set; }
        [StringLength(2048)]
        public string Designacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPreenchimentoFormulario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataHoraEfectividadeEstado { get; set; }
        public bool? CompletamenteResolvido { get; set; }
        [Column("CodigoResponsabilidadeID")]
        [StringLength(50)]
        public string CodigoResponsabilidadeId { get; set; }
        [StringLength(2048)]
        public string RazaoPeloRecuso { get; set; }
        [Column("CausadorDoIncidenteID")]
        [StringLength(50)]
        public string CausadorDoIncidenteId { get; set; }
        [StringLength(2048)]
        public string DescricaoCulpadoIncidente { get; set; }
        public bool? ApoliceCancelada { get; set; }
        public bool? ReclamadorAlugouCarro { get; set; }
        public bool? SeguradorAceitaCustoAluguel { get; set; }
        public bool? ApoliceEstadoRenovacao { get; set; }
        [Column("ResponsavelPelaReclamacaoID")]
        [StringLength(50)]
        public string ResponsavelPelaReclamacaoId { get; set; }
        [Column("ReclamadorID")]
        [StringLength(50)]
        public string ReclamadorId { get; set; }
        [Column("PessoaRelacionadaID")]
        [StringLength(50)]
        public string PessoaRelacionadaId { get; set; }
        [Column("ApoliceID")]
        [StringLength(50)]
        public string ApoliceId { get; set; }
        [Column("ClassificacaoReclamacaoID")]
        [StringLength(50)]
        public string ClassificacaoReclamacaoId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("PerdaID")]
        [StringLength(50)]
        public string PerdaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [StringLength(50)]
        public string CodReclamacao { get; set; }

        [ForeignKey("ApoliceId")]
        [InverseProperty("Reclamacao")]
        public virtual Apolice Apolice { get; set; }
        [ForeignKey("CausadorDoIncidenteId")]
        [InverseProperty("ReclamacaoCausadorDoIncidente")]
        public virtual Pessoa CausadorDoIncidente { get; set; }
        [ForeignKey("ClassificacaoReclamacaoId")]
        [InverseProperty("Reclamacao")]
        public virtual ClassificacaoReclamacao ClassificacaoReclamacao { get; set; }
        [ForeignKey("CodigoResponsabilidadeId")]
        [InverseProperty("Reclamacao")]
        public virtual CodigoResponsabilidade CodigoResponsabilidade { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Reclamacao")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("PerdaId")]
        [InverseProperty("Reclamacao")]
        public virtual Perda Perda { get; set; }
        [ForeignKey("PessoaRelacionadaId")]
        [InverseProperty("ReclamacaoPessoaRelacionada")]
        public virtual Pessoa PessoaRelacionada { get; set; }
        [ForeignKey("ReclamadorId")]
        [InverseProperty("ReclamacaoReclamador")]
        public virtual Pessoa Reclamador { get; set; }
        [ForeignKey("ResponsavelPelaReclamacaoId")]
        [InverseProperty("ReclamacaoResponsavelPelaReclamacao")]
        public virtual Pessoa ResponsavelPelaReclamacao { get; set; }
        [InverseProperty("Reclamacao")]
        public virtual ICollection<ContratoPrestadorEmpresa> ContratoPrestadorEmpresa { get; set; }
    }
}