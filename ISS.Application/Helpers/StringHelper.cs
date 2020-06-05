using System;

namespace ISS.Application.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Funncao para configurar um codigo aleatorio a uma var
        /// </summary>
        /// <param name="prefix">As inicias do codigo</param>
        /// <returns></returns>
        public static string SetCode(string prefix = "")
        {
            var root = "AEIOU0123456789aeiou";
            var str = prefix;
            var r = new Random();
            for (int i = 0; i < 9; i++)
            {
                str += root[r.Next(0, root.Length - 1)];
            }
            return str;
        }
    }
}
