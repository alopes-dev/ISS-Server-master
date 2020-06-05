using System;
namespace ISS.Application.Dto
{
    public class CoberturaDto
    {
        public string IdCobertura { get; set; }
        public string DescricaoCobertura { get; set; }
        public DateTime? DataEfectividadeCobertura { get; set; }
        public DateTime? DataTerminoCobertura { get; set; }
        public double? ValorMin { get; set; }
        public double? ValorMax { get; set; }
        public double? CooPagamentoMin { get; set; }
        public double? CooPagamentoMax { get; set; }
        public double TaxaCooPagamento { get; set; }
        public bool? CoberturaAdicional { get; set; }
        public bool? CoberturaRenovavel { get; set; }
        public bool? CustoCoberturaQualificado { get; set; }
        public int? NumReivindicacoesPermitidas { get; set; }
        public bool? CoberturaSujeitaCoSeguro { get; set; }
        public bool? CoberturaDeveEstarRenovacao { get; set; }
        public bool? CoberturaSolicitada { get; set; }
        public bool? ForneceValorResgateEmDinheiro { get; set; }
        public bool? SubContratentesCobertos { get; set; }
        public string EstadoId { get; set; }
        public string TipoCoberturaId { get; set; }
        public double? PercentagemDentroRede { get; set; }
        public double? PercentagemForaRede { get; set; }
        public string MoedaId { get; set; }
        public string CodCoberturaProduto { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Obs { get; set; }
        public double? LimiteIndemnizacao { get; set; }
        public bool? IsTaxa { get; set; }
        public string SubContaId { get; set; }
        public string NaturezaMovimentoId { get; set; }
        public bool? Contabiliza { get; set; }
        public bool? IsPadrao { get; set; }
        public string CodDesconto { get; set; }
    }
}
