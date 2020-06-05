namespace ISS.Application.Services
{
    public interface IQRCoder
    {
        /// <summary>
        /// Transformar a plain text em QR Code.
        /// <param name="textToEncode">Texto que será codifidado para QR.</param>
        /// </summary>
        string GenerateQRCode(string textToEncode);
    }
}