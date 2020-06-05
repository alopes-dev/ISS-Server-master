using ISS.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ISS.Application.Services.Email
{
    public class EmailService : IEmailService
    {
        #region Private Members
        /// <summary>
        /// Usado para pegar as configurações de email.
        /// </summary>
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Padrão.
        /// </summary>
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Interface Implementations
        /// <summary>
        /// Enviar email para uma determinada pessoa.
        /// <param name="emailModel">Estrutura contendo dados necessários ao email.</param>
        /// </summary>
        public void Send(EmailViewModel emailModel, Action<object, AsyncCompletedEventArgs> onCompleted = null)
        {
            // Configurar a mensagem a ser enviada.
            var msg = new MailMessage(_configuration["MailSettings:From"], emailModel.Destinatario);
            msg.Subject = emailModel.Assunto;
            msg.Body = emailModel.Conteudo;
            msg.IsBodyHtml = false;

            // Configurar o cliente SMTP
            var smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(_configuration["MailSettings:From"], _configuration["MailSettings:Password"]);
            smtpClient.Host = _configuration["MailSettings:Host"];
            smtpClient.Port = int.Parse(_configuration["MailSettings:Port"]);
            smtpClient.EnableSsl = bool.Parse(_configuration["MailSettings:EnableSsl"]);

            if (!emailModel.SendNow)
                Debug.WriteLine("Enviando ..."); // TODO: Implementar um background service para enviar o email na data programada.

            // TODO: Tratar desse atributo.
            object userToken = null;
            smtpClient.SendAsync(msg, userToken);

            smtpClient.SendCompleted += (ss, ee) =>
            {
                onCompleted?.Invoke(ss, ee);
            };
        }

        /// <summary>
        /// Enviar email para uma determinada pessoa.
        /// <param name="emailModel">Estrutura contendo dados necessários ao email.</param>
        /// </summary>
        public async Task SendAsync(EmailViewModel emailModel, Action<object, AsyncCompletedEventArgs> onCompleted = null)
        {
            // Configurar a mensagem a ser enviada.
            var msg = new MailMessage(_configuration["MailSettings:From"], emailModel.Destinatario);
            msg.Subject = emailModel.Assunto;
            msg.Body = emailModel.Conteudo;
            msg.IsBodyHtml = false;

            // Configurar o cliente SMTP
            var smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(_configuration["MailSettings:From"], _configuration["MailSettings:Password"]);
            smtpClient.Host = _configuration["MailSettings:Host"];
            smtpClient.Port = int.Parse(_configuration["MailSettings:Port"]);
            smtpClient.EnableSsl = bool.Parse(_configuration["MailSettings:EnableSsl"]);

            if (!emailModel.SendNow)
                Debug.WriteLine("Enviando ..."); // TODO: Implementar um background service para enviar o email na data programada.

            // Envio de uma mensagem em smtp de forma assincrona.
            await smtpClient.SendMailAsync(msg);

            smtpClient.SendCompleted += (ss, ee) =>
            {
                onCompleted?.Invoke(ss, ee);
            };
        }
        #endregion
    }
}