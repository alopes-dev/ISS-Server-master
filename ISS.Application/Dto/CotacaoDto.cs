using ISS.Application.Dto.Pessoa;
using ISS.Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISS.Application.Dto
{
    public class CotacaoDtoBase
    {
        public virtual string IdCotacao { get; set; }
        public string NumOrdem { get; set; }
        public string Obs { get; set; }
        public string ProdutorId { get; set; }
        public string MoedaId { get; set; }
        public string ActividadeContratadaId { get; set; }
        public string CaminhoFicheiro { get; set; }
        public string BalcaoId { get; set; }
        public string FraccionamentoId { get; set; }
        public string FormasCobrancaId { get; set; }
        public string PessoaContactoId { get; set; }
        // ==================== Usados em Automóvel
        public string PessoasAbrangidasId { get; set; }
        public string LugaresAutoAssegurarId { get; set; }
        // ====================

        public string FormaLiquidacaoPremioId { get; set; }
        public double PercentagemMinimaPremio { get; set; }
        public double? ValorMinimoPremio { get; set; }
        public int? PrazoAceitacao { get; set; }
        public string FormaContratacaoId { get; set; }
        public string PrazoCurtoId { get; set; }
        public string DuracaoTipoContratoId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public string QualidadeEmQueSeguraId { get; set; }
        public string TipoSeguroGrupoId { get; set; }
        public DateTime? DataEntrada { get; set; }
        public bool? OutraSeguradora { get; set; }
        public string CobradorId { get; set; }
        [Required]
        public string TomadorId { get; set; }
        public string LocalCobrancaId { get; set; }
        public string LocalRiscoEmpresaId { get; set; }

        public double? CapitalSeguro { get; set; }
        public string FranquiaId { get; set; }

        /// <summary>
        /// Incluir os dados sobre os objectos seguros caso o produto seja do ramo não vida.
        /// </summary>
       // public virtual IEnumerable<ObjectoSeguradoDtoBase> ObjectosSegurados { get; set; }
        /// <summary>
        /// Incluir os dados sobre os membros assegurados caso o produto seja do ramo vida. 
        /// </summary>
        public virtual IEnumerable<MembroAssegurado> MembrosAssegurados { get; set; }
        /// <summary>
        /// Incluir os beneficiários de uma apólice.
        /// </summary>
        public virtual IEnumerable<Beneficiario> Beneficiarios { get; set; }
        /// <summary>
        /// Coberturas a serem usadas para uma determinada Cotação/Proposta de Seguro.
        /// </summary>
        public virtual IEnumerable<CoberturaSelecionada> CoberturasSelecionadas { get; set; }
        /// <summary>
        /// Informar os dados da viagem, caso o seguro seja de viagem.
        /// </summary>
        public virtual ViagemDtoBase DadosViagem { get; set; }
        /// <summary>
        /// Questionário geral que será respondido.
        /// </summary>
        public virtual IEnumerable<QuestionarioDto> Questionario { get; set; }
        public virtual IEnumerable<FraccionamentoModel> PremioFracionados { get; set; }
        public virtual IEnumerable<Automovel> Automoveis { get; set; }
    }

    public class CotacaoDto : CotacaoDtoBase
    {
        public DateTime? DataEmissao { get; private set; }
        public double? PremioTotal { get; private set; }
        public double? PremioBase { get; set; }
        public double? PremioSimples { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string SeguradoraId { get; set; }
        public DateTime? DataAceitacao { get; set; }
        public string ResponsavelAceitacaoId { get; set; }
        public ClienteDtoBase Tomador { get; set; }
        public PessoaDtoBase Produtor { get; set; }
        public PessoaDtoBase PessoaContacto { get; set; }
    }

    public class ApoliceDto : CotacaoDto
    {
        [JsonIgnore]
        public override string IdCotacao { get => base.IdCotacao; set => base.IdCotacao = value; }

        public string IdApolice { get; set; }
        public string NumeroRef { get; set; }
        public DateTime? DataRenovacao { get; set; }
        public bool? AssinaturaProponente { get; set; }
        public bool? ApoliceCoAssegurada { get; set; }
        public bool? AssinadaLocalPagamento { get; set; }
        public bool? ApoliceTransferida { get; set; }
        public string RefApolice { get; set; }
        public string UltModificacaoPorId { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public DateTime? DataEstorno { get; set; }
        public DateTime? DataAnulacao { get; set; }
        public string CodApolice { get; set; }
        public string CentroCustoId { get; set; }
        public string ClienteId { get; set; }
        public string Ambito { get; set; }
    }
}
