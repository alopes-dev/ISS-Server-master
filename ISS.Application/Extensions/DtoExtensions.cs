using System.Text;

namespace ISS.Application.Extensions
{
    public static class DtoExtensions
    {
        /// <summary>
        /// Converter um determinada String que está em base64 para um array de bytes.
        /// </summary>
        /// <param name="str64">A string a ser convertida.</param>
        /// <returns></returns>
        public static byte[] FromBase64ToByteArray(this string str64)
        {
            if (string.IsNullOrWhiteSpace(str64))
                return null;

            var byteArray = Encoding.UTF8.GetBytes(str64);
            return byteArray;
        }

        /// <summary>
        /// Converter um determinado array de bytes para String64
        /// </summary>
        /// <param name="binaryData">O array de bytes a ser convertido.</param>
        /// <returns></returns>
        public static string ToBase64(this byte[] binaryData)
        {
            if (binaryData?.Length <= 0)
                return string.Empty;
            var fileData = Encoding.UTF8.GetString(binaryData);
            return fileData;
        }
    }
}
