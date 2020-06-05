using ISS.Application.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ISS.Application.Services.Email
{
    public interface IEmailService
    {
        /// <summary>
        /// Enviar email para uma determinada pessoa.
        /// <param name="emailModel">Estrutura contendo dados necessários ao email.</param>
        /// <param name="onComplete">Qualquer ação a ser executada logo que se receber a confirma
        ///  de envio sucedido.</param>
        /// </summary>
        void Send(EmailViewModel emailModel, Action<object, AsyncCompletedEventArgs> onCompleted = null);

        /// <summary>
        /// Enviar email para uma determinada pessoa.
        /// <param name="emailModel">Estrutura contendo dados necessários ao email.</param>
        /// <param name="onComplete">Qualquer ação a ser executada logo que se receber a confirma
        ///  de envio sucedido.</param>
        /// </summary>
        Task SendAsync(EmailViewModel emailModel, Action<object, AsyncCompletedEventArgs> onCompleted = null);
    }
}