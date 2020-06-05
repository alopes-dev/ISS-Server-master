namespace ISS.Application.Dto
{
    /// <summary>
    /// Estrutura para albergar os dados necessários para o efeito de pagamentos.
    /// </summary>
    public class PagamentoDto
    {
        /// <summary>
        /// Informação da forma de pagamento a ser utilizada.
        /// </summary>
        /// <value></value>
        public string FormaPagamentoId { get; set; }
        /// <summary>
        /// Informação do cartão de pagamento caso, a forma de pagamento seja por cartão.
        /// </summary>
        /// <value></value>
        public string CartaoPagamentoId { get; set; }
        /// <summary>
        /// Moeda usada para o pagamento.
        /// </summary>
        /// <value></value>
        public string MoedaId { get; set; }
        /// <summary>
        /// Número de referência de apólice.
        /// </summary>
        /// <value></value>
        public string PropostaRef { get; set; }
        /// <summary>
        /// Valor a ser pago.
        /// </summary>
        /// <value></value>
        public double ValorAPagar { get; set; }
    }
}