using System;

namespace ISS.Application.Dto
{
    public class MovimentoBaseModel
    {
        public string CodTransacao { get; set; }
        public DateTime DataHoraMovimento { get; set; }
        public DateTime DataValor { get; set; }
        public string DescricaoMovimento { get; set; }
        public string MoedaId { get; set; }
        public double Valor { get; set; }
        public string Referencia { get; set; }
        public string EstadoId { get; set; }
        public string FuncionarioId { get; set; }
        public string TipoPagamentoId { get; set; }
        public string TipoRecebimentoId { get; set; }
        public string CaixaId { get; set; }
        public string EnderecoId { get; set; }
        public string TipoConta { get; set; }
        public string TipoOperacaoId { get; set; }
        public string NaturezaMovimentoId { get; set; }
        public string NumeroDocumentoInterno { get; set; }
        public bool? IsPago { get; set; } = false;
        public string FavorecidoId { get; set; }
        public string OutraMoedaId { get; set; }
        public string CentroResponsabilidadeId { get; set; }
        public string CentroCustoId { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataProgramada { get; set; }
        public int? DocumentoParcelado { get; set; }
        public string TipoDesembolsoId { get; set; }
        public string Identificador { get; set; }
        public string Nif { get; set; }
        public string NumeroDocumentoExterno { get; set; }
        public string EmpresaId { get; set; }
        public string PeriodoContabilId { get; set; }

    }

    public class MovimentoModel : MovimentoBaseModel
    {
        public string ContaDebitarId { get; set; }
        public string ContaCreditarId { get; set; }
        public string CodigoOperacaoCredito { get; set; }

        public string CodigoOperacaoDebito { get; set; }
        public string ContaFinanceiraDebitarId { get; set; }
        public string ContaFinanceiraCreditarId { get; set; }
    }

    public class MovimentoMultiModel : MovimentoBaseModel
    {
        public string ContaId { get; set; }
        public string CodigoOperacao { get; set; }
        public string ContaFinanceiraId { get; set; }
    }
}
