﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Automovel
    {
        public Automovel()
        {
            AnexosAutomovel = new HashSet<AnexosAutomovel>();
            CaracteristicaAtutomovel = new HashSet<CaracteristicaAtutomovel>();
            DocumentosAutomovel = new HashSet<DocumentosAutomovel>();
            Gpsautomovel = new HashSet<Gpsautomovel>();
            Modificacao = new HashSet<Modificacao>();
            Motorista = new HashSet<Motorista>();
            MotoristaAutomovel = new HashSet<MotoristaAutomovel>();
            ObjectoEnvolvido = new HashSet<ObjectoEnvolvido>();
            ObjectoSegurado = new HashSet<ObjectoSegurado>();
            Pneu = new HashSet<Pneu>();
            RespostaPergunta = new HashSet<RespostaPergunta>();
        }

        [StringLength(50)]
        public string IdAutomovel { get; set; }
        [Column("TipoCaixaID")]
        [StringLength(50)]
        public string TipoCaixaId { get; set; }
        [Column("ProprietarioID")]
        [StringLength(50)]
        public string ProprietarioId { get; set; }
        [Column("LadoVolanteID")]
        [StringLength(50)]
        public string LadoVolanteId { get; set; }
        [StringLength(50)]
        public string VelocidadeId { get; set; }
        [Column("CotacaoID")]
        [StringLength(50)]
        public string CotacaoId { get; set; }
        [StringLength(100)]
        public string Detalhe { get; set; }
        [Column("NivelDesempenhoID")]
        [StringLength(50)]
        public string NivelDesempenhoId { get; set; }
        [Column("PaisMatriculaID")]
        [StringLength(50)]
        public string PaisMatriculaId { get; set; }
        [Column("MoedaID")]
        [StringLength(50)]
        public string MoedaId { get; set; }
        [StringLength(100)]
        public string Matricula { get; set; }
        [StringLength(17)]
        public string NumeroChassi { get; set; }
        [Column("ExemplarModeloID")]
        [StringLength(50)]
        public string ExemplarModeloId { get; set; }
        [StringLength(50)]
        public string CilindragemAutomovelId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("ApoliceID")]
        [StringLength(50)]
        public string ApoliceId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CodAutomovel { get; set; }
        [StringLength(50)]
        public string CorId { get; set; }
        [StringLength(50)]
        public string InformacaoAdicionalId { get; set; }
        [StringLength(50)]
        public string TipoMotorId { get; set; }
        [StringLength(50)]
        public string TipoCorpoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPrimeiraMatricula { get; set; }
        public double? ValorEmNovo { get; set; }
        public double? ValorActual { get; set; }
        [StringLength(50)]
        public string ClassificacaoAutomovelId { get; set; }
        [StringLength(50)]
        public string NumMotor { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataUltimoSinistroParticipado { get; set; }
        [StringLength(50)]
        public string TipoUsoId { get; set; }
        public int? AnoConstrucao { get; set; }
        public double? Potencia { get; set; }
        public int? NumLugares { get; set; }
        [StringLength(100)]
        public string CaminhoFicheiro { get; set; }
        [StringLength(50)]
        public string MoedaValorActualId { get; set; }
        [Column("TipoMatriculaID")]
        [StringLength(50)]
        public string TipoMatriculaId { get; set; }
        public double? PesoBruto { get; set; }
        public double? PesoReboque { get; set; }
        public double? Tara { get; set; }

        [ForeignKey("ApoliceId")]
        [InverseProperty("Automovel")]
        public virtual Apolice Apolice { get; set; }
        [ForeignKey("CilindragemAutomovelId")]
        [InverseProperty("Automovel")]
        public virtual CilindragemAutomovel CilindragemAutomovel { get; set; }
        [ForeignKey("ClassificacaoAutomovelId")]
        [InverseProperty("Automovel")]
        public virtual ClassificacaoAutomovel ClassificacaoAutomovel { get; set; }
        [ForeignKey("CorId")]
        [InverseProperty("Automovel")]
        public virtual Cor Cor { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Automovel")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ExemplarModeloId")]
        [InverseProperty("Automovel")]
        public virtual ExemplarModeloAutomovel ExemplarModelo { get; set; }
        [ForeignKey("InformacaoAdicionalId")]
        [InverseProperty("Automovel")]
        public virtual InformacaoAdicional InformacaoAdicional { get; set; }
        [ForeignKey("LadoVolanteId")]
        [InverseProperty("Automovel")]
        public virtual LadoVolante LadoVolante { get; set; }
        [ForeignKey("MoedaId")]
        [InverseProperty("AutomovelMoeda")]
        public virtual Moeda Moeda { get; set; }
        [ForeignKey("MoedaValorActualId")]
        [InverseProperty("AutomovelMoedaValorActual")]
        public virtual Moeda MoedaValorActual { get; set; }
        [ForeignKey("NivelDesempenhoId")]
        [InverseProperty("Automovel")]
        public virtual NivelDesempenho NivelDesempenho { get; set; }
        [ForeignKey("PaisMatriculaId")]
        [InverseProperty("Automovel")]
        public virtual Pais PaisMatricula { get; set; }
        [ForeignKey("ProprietarioId")]
        [InverseProperty("Automovel")]
        public virtual Pessoa Proprietario { get; set; }
        [ForeignKey("TipoCaixaId")]
        [InverseProperty("Automovel")]
        public virtual TipoCaixa TipoCaixa { get; set; }
        [ForeignKey("TipoCorpoId")]
        [InverseProperty("Automovel")]
        public virtual TipoCorpo TipoCorpo { get; set; }
        [ForeignKey("TipoMatriculaId")]
        [InverseProperty("Automovel")]
        public virtual TipoMatricula TipoMatricula { get; set; }
        [ForeignKey("TipoMotorId")]
        [InverseProperty("Automovel")]
        public virtual TipoMotor TipoMotor { get; set; }
        [ForeignKey("TipoUsoId")]
        [InverseProperty("Automovel")]
        public virtual TipoUso TipoUso { get; set; }
        [ForeignKey("VelocidadeId")]
        [InverseProperty("Automovel")]
        public virtual Velocidade Velocidade { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<AnexosAutomovel> AnexosAutomovel { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<CaracteristicaAtutomovel> CaracteristicaAtutomovel { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<DocumentosAutomovel> DocumentosAutomovel { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<Gpsautomovel> Gpsautomovel { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<Modificacao> Modificacao { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<Motorista> Motorista { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<MotoristaAutomovel> MotoristaAutomovel { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<ObjectoEnvolvido> ObjectoEnvolvido { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<ObjectoSegurado> ObjectoSegurado { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<Pneu> Pneu { get; set; }
        [InverseProperty("Automovel")]
        public virtual ICollection<RespostaPergunta> RespostaPergunta { get; set; }
    }
}