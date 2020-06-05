﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Automovel = new HashSet<Automovel>();
            Contacto = new HashSet<Contacto>();
            ExportacoesProdutosInstalacoes = new HashSet<ExportacoesProdutosInstalacoes>();
            Gpsautomovel = new HashSet<Gpsautomovel>();
            Idiomas = new HashSet<Idiomas>();
            LocaisCobertura = new HashSet<LocaisCobertura>();
            LocaisDesconto = new HashSet<LocaisDesconto>();
            LocaisEncargo = new HashSet<LocaisEncargo>();
            LocaisFranquia = new HashSet<LocaisFranquia>();
            LocaisImposto = new HashSet<LocaisImposto>();
            LocaisLimiteCompetencia = new HashSet<LocaisLimiteCompetencia>();
            LocaisObjectivosComerciais = new HashSet<LocaisObjectivosComerciais>();
            LocaisOferta = new HashSet<LocaisOferta>();
            NacionalidadePessoa = new HashSet<NacionalidadePessoa>();
            PaisesPlanoProduto = new HashSet<PaisesPlanoProduto>();
            ProdutosInstalacoes = new HashSet<ProdutosInstalacoes>();
            Provincia = new HashSet<Provincia>();
            ViagemPaisDestino = new HashSet<Viagem>();
            ViagemPaisOrigem = new HashSet<Viagem>();
        }

        [StringLength(50)]
        public string IdPais { get; set; }
        [StringLength(100)]
        public string CodPais { get; set; }
        [StringLength(100)]
        public string NomePais { get; set; }
        [Column("RegiaoID")]
        [StringLength(50)]
        public string RegiaoId { get; set; }
        [Column("ContinenteID")]
        [StringLength(50)]
        public string ContinenteId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("DDI")]
        [StringLength(10)]
        public string Ddi { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [Column("CodeISO")]
        [StringLength(500)]
        public string CodeIso { get; set; }
        [StringLength(100)]
        public string CaminhoImagem { get; set; }

        [ForeignKey("ContinenteId")]
        [InverseProperty("Pais")]
        public virtual Continente Continente { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Pais")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("RegiaoId")]
        [InverseProperty("Pais")]
        public virtual Regiao Regiao { get; set; }
        [InverseProperty("PaisMatricula")]
        public virtual ICollection<Automovel> Automovel { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<Contacto> Contacto { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<ExportacoesProdutosInstalacoes> ExportacoesProdutosInstalacoes { get; set; }
        [InverseProperty("PaisOrigem")]
        public virtual ICollection<Gpsautomovel> Gpsautomovel { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<Idiomas> Idiomas { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<LocaisCobertura> LocaisCobertura { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<LocaisDesconto> LocaisDesconto { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<LocaisEncargo> LocaisEncargo { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<LocaisFranquia> LocaisFranquia { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<LocaisImposto> LocaisImposto { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<LocaisLimiteCompetencia> LocaisLimiteCompetencia { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<LocaisObjectivosComerciais> LocaisObjectivosComerciais { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<LocaisOferta> LocaisOferta { get; set; }
        [InverseProperty("Nacionalidade")]
        public virtual ICollection<NacionalidadePessoa> NacionalidadePessoa { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<PaisesPlanoProduto> PaisesPlanoProduto { get; set; }
        [InverseProperty("PaisFornecedor")]
        public virtual ICollection<ProdutosInstalacoes> ProdutosInstalacoes { get; set; }
        [InverseProperty("Pais")]
        public virtual ICollection<Provincia> Provincia { get; set; }
        [InverseProperty("PaisDestino")]
        public virtual ICollection<Viagem> ViagemPaisDestino { get; set; }
        [InverseProperty("PaisOrigem")]
        public virtual ICollection<Viagem> ViagemPaisOrigem { get; set; }
    }
}