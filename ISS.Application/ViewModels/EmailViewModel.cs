using System;

namespace ISS.Application.ViewModels
{
    public class EmailViewModel
    {
        /// <summary>
        /// A quem o email deve ser enviado.
        /// </summary>
        public string Destinatario { get; set; }

        /// <summary>
        /// O assunto da mensagem.
        /// </summary>
        public string Assunto { get; set; }

        /// <summary> 
        /// Conteúdo a ter em conta no email.
        /// </summary>
        public string Conteudo { get; set; }

        /// <summary>
        /// Ficheiro a ser anexado ao envio, no formato de base64.
        /// </summary>
        public string Anexo { get; set; }

        /// <summary>
        /// A data de envio do email.
        /// </summary>
        public DateTimeOffset DataEnvio { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// Validar se o email deve ser enviando no exacto momento
        /// Ou numa outra altura ( Segundo a data programanda ).
        /// </summary>
        public bool SendNow => DataEnvio <= DateTimeOffset.UtcNow;
    }
}