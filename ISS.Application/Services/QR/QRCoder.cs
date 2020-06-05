using QRCoder;

namespace ISS.Application.Services
{
    public class QRCoder : IQRCoder
    {
        // TODO: Ver melhor formas de implementar os Tipos de Saida.
        public enum QRCoderOutputType
        {
            NONE = 0,
        };

        /// <summary>
        /// Transformar a plain text em QR Code.
        /// <param name="textToEncode">Texto que será codifidado para QR.</param>
        /// </summary>
        public string GenerateQRCode(string textToEncode)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textToEncode, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }
    }
}