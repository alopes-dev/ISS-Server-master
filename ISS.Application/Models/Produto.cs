﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Produto
    {
        public Produto()
        {
            AgravamentoPessoa = new HashSet<AgravamentoPessoa>();
            CategoriaSujeitoDano = new HashSet<CategoriaSujeitoDano>();
            ClasseModalidadeSeguro = new HashSet<ClasseModalidadeSeguro>();
            CondicoesProduto = new HashSet<CondicoesProduto>();
            CrossSellingProdutoCrossed = new HashSet<CrossSelling>();
            CrossSellingProdutoPrincipal = new HashSet<CrossSelling>();
            DocumentosObrigatorioProduto = new HashSet<DocumentosObrigatorioProduto>();
            Exclusoes = new HashSet<Exclusoes>();
            Glossario = new HashSet<Glossario>();
            ImagemProduto = new HashSet<ImagemProduto>();
            IncapacidadeTemporaria = new HashSet<IncapacidadeTemporaria>();
            InformacaoSuporte = new HashSet<InformacaoSuporte>();
            InformacoesAdicionaisProduto = new HashSet<InformacoesAdicionaisProduto>();
            LinhaProduto = new HashSet<LinhaProduto>();
            Mapa = new HashSet<Mapa>();
            MetricasProduto = new HashSet<MetricasProduto>();
            ObjectivoProduto = new HashSet<ObjectivoProduto>();
            ObjectivosComerciais = new HashSet<ObjectivosComerciais>();
            ObrigacoesProduto = new HashSet<ObrigacoesProduto>();
            PerguntasFrequentesProduto = new HashSet<PerguntasFrequentesProduto>();
            Perspicacia = new HashSet<Perspicacia>();
            PessoaTarefa = new HashSet<PessoaTarefa>();
            PremiosMinimos = new HashSet<PremiosMinimos>();
            QuadroDanos = new HashSet<QuadroDanos>();
            RelatorioProduto = new HashSet<RelatorioProduto>();
            Risco = new HashSet<Risco>();
            Tarifa = new HashSet<Tarifa>();
            TarifasAutomovel = new HashSet<TarifasAutomovel>();
            TarifasPremioAutoAcidentesTrabalho = new HashSet<TarifasPremioAutoAcidentesTrabalho>();
            TarifasPremioAutoAt2 = new HashSet<TarifasPremioAutoAt2>();
            TipoCobertura = new HashSet<TipoCobertura>();
            VantagemProduto = new HashSet<VantagemProduto>();
        }

        [StringLength(50)]
        public string IdProduto { get; set; }
        [StringLength(200)]
        public string Nome { get; set; }
        [StringLength(3000)]
        public string AmbitoProduto { get; set; }
        [StringLength(3000)]
        public string FinalidadeProduto { get; set; }
        [Column("SubContaID")]
        [StringLength(50)]
        public string SubContaId { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [Column("PortfolioProdutoID")]
        [StringLength(50)]
        public string PortfolioProdutoId { get; set; }
        [Column("MoedaID")]
        [StringLength(50)]
        public string MoedaId { get; set; }
        [Column("CaminhoURL")]
        [StringLength(2000)]
        public string CaminhoUrl { get; set; }
        public bool? ResseguroObrigatorio { get; set; }
        [StringLength(10)]
        public string CodProduto { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        public bool? SeguroObrigatorio { get; set; }
        public bool? IsentoImposto { get; set; }
        public bool? Comissionado { get; set; }
        [StringLength(1000)]
        public string CaminhoWeb { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [StringLength(50)]
        public string NaturezaMovimentoId { get; set; }
        [Required]
        public bool? Contabiliza { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCancelamento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAnulacao { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("Produto")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("MoedaId")]
        [InverseProperty("Produto")]
        public virtual Moeda Moeda { get; set; }
        [ForeignKey("NaturezaMovimentoId")]
        [InverseProperty("Produto")]
        public virtual NaturezaMovimento NaturezaMovimento { get; set; }
        [ForeignKey("PortfolioProdutoId")]
        [InverseProperty("Produto")]
        public virtual PortfolioProduto PortfolioProduto { get; set; }
        [ForeignKey("SubContaId")]
        [InverseProperty("Produto")]
        public virtual PlanoContas SubConta { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<AgravamentoPessoa> AgravamentoPessoa { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<CategoriaSujeitoDano> CategoriaSujeitoDano { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<ClasseModalidadeSeguro> ClasseModalidadeSeguro { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<CondicoesProduto> CondicoesProduto { get; set; }
        [InverseProperty("ProdutoCrossed")]
        public virtual ICollection<CrossSelling> CrossSellingProdutoCrossed { get; set; }
        [InverseProperty("ProdutoPrincipal")]
        public virtual ICollection<CrossSelling> CrossSellingProdutoPrincipal { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<DocumentosObrigatorioProduto> DocumentosObrigatorioProduto { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<Exclusoes> Exclusoes { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<Glossario> Glossario { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<ImagemProduto> ImagemProduto { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<IncapacidadeTemporaria> IncapacidadeTemporaria { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<InformacaoSuporte> InformacaoSuporte { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<InformacoesAdicionaisProduto> InformacoesAdicionaisProduto { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<LinhaProduto> LinhaProduto { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<Mapa> Mapa { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<MetricasProduto> MetricasProduto { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<ObjectivoProduto> ObjectivoProduto { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<ObjectivosComerciais> ObjectivosComerciais { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<ObrigacoesProduto> ObrigacoesProduto { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<PerguntasFrequentesProduto> PerguntasFrequentesProduto { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<Perspicacia> Perspicacia { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<PessoaTarefa> PessoaTarefa { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<PremiosMinimos> PremiosMinimos { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<QuadroDanos> QuadroDanos { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<RelatorioProduto> RelatorioProduto { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<Risco> Risco { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<Tarifa> Tarifa { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<TarifasAutomovel> TarifasAutomovel { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<TarifasPremioAutoAcidentesTrabalho> TarifasPremioAutoAcidentesTrabalho { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<TarifasPremioAutoAt2> TarifasPremioAutoAt2 { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<TipoCobertura> TipoCobertura { get; set; }
        [InverseProperty("Produto")]
        public virtual ICollection<VantagemProduto> VantagemProduto { get; set; }
    }
}