namespace CRUDMaker
{
    public static class StringExt
    {
        /// <summary>
        /// An Helper to replace all the ocurrencies of a char
        /// </summary>
        /// <param name="_string">The default string</param>
        /// <param name="_cur">The Current char</param>
        /// <param name="_new">The New char</param>
        /// <returns>The new string</returns>
        public static string ReplaceAllChars(this string _string, char _cur, char _new)
        {
            // Replacing the danger characters
            var set = "";
            foreach (var c in _string)
            {
                var aux = c;

                if (aux == _cur)
                    aux = _new;

                set += aux;
            }
            _string = set;
            // End Replacing the danger characters

            return _string;
        }

        /// <summary>
        /// An helper to add hifen bettwen Camel Case or Pascal Case
        /// </summary>
        /// <param name="str">The entry string</param>
        /// <returns>The string with the hifen(s)</returns>
        public static string NameSeparator(this string str)
        {
            if (str.ToUpper() == str) // Verificando se toda frase está em maiúscula
                return str;

            int i = 0;
            foreach (var s in str) // Percorrendo cada caracter
            {
                string c = s.ToString(); // Pegando o caracter corrente
                string a = i != 0 ? str[i - 1].ToString() : "-"; // Pegando o anterior se ele existir

                // Se a atual é maiúscula e a anterior é minuscula entao executa a inserção
                if (c.ToUpper() == c && a.ToLower() == a && a != "-")
                {
                    str = str.Insert(i, "-");
                    i++; // Incrementando para coenscidir com o tamanho pra palavra
                }
                i++; // Incrementanto
            }

            return str;
        }

        public static string ToLowerFirstChar(this string str)
        {
            var result = str[0].ToString().ToLower();
            for (int i = 1; i < str.Length; i++)
            {
                var c = str[i];
                result += c;
            }
            return result;
        }

    }

}
