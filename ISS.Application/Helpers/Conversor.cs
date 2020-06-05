using System;

namespace ISS.Application.Helpers
{
    struct Constantes
    {
        public static string M = "Mil";
        public static string Mil = "Milhão";
        public static string Mils = "Milhões";
        public static string Bil = "Bilhão";
        public static string Bils = "Bilhões";
        public static string Tril = "Trilhão";
        public static string Trils = "Trilhões";
    }

    public class Conversor
    {
        public static string Extenso(decimal valor, string moeda, string moedaPlural = null)
        {
            if (moedaPlural == null) moedaPlural = moeda;

            if (valor <= 0 | valor >= 1000000000000000)
                return "Valor não suportado pelo sistema.";
            else
            {
                string strValor = valor.ToString("000000000000000.00");
                string valor_por_extenso = string.Empty;
                for (int i = 0; i <= 15; i += 3)
                {
                    valor_por_extenso += ValorExtenso(Convert.ToDecimal(strValor.Substring(i, 3)));
                    if (i == 0 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                            valor_por_extenso += " " + Constantes.Tril + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " e " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valor_por_extenso += " " + Constantes.Trils + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " e " : string.Empty);
                    }
                    else if (i == 3 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valor_por_extenso += " " + Constantes.Bil + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " e " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valor_por_extenso += " " + Constantes.Bils + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " e " : string.Empty);
                    }
                    else if (i == 6 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valor_por_extenso += " " + Constantes.Mil + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " e " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valor_por_extenso += " " + Constantes.Mils + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " e " : string.Empty);
                    }
                    else if (i == 9 & valor_por_extenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valor_por_extenso += " " + Constantes.M + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " e " : string.Empty);
                    if (i == 12)
                    {
                        if (valor_por_extenso.Length > 8)
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == Constantes.Bil |
                                valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == Constantes.Mil)
                                valor_por_extenso += " De";
                            else if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == Constantes.Bils |
                                valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == Constantes.Mils |
                                valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == Constantes.Trils)
                                valor_por_extenso += " De";
                            else if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == Constantes.Trils)
                                valor_por_extenso += " De";
                        if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                            valor_por_extenso += " " + moeda;
                        else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                            valor_por_extenso += " " + moeda;
                        if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != string.Empty)
                            valor_por_extenso += " e ";
                    }
                    if (i == 15)
                        if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                            valor_por_extenso += " Centavo";
                        else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                            valor_por_extenso += " Centavos";
                }
                return valor_por_extenso;
            }
        }
        static string ValorExtenso(decimal valor)
        {
            if (valor <= 0)
                return string.Empty;
            else
            {
                string montagem = string.Empty;
                if (valor > 0 & valor < 1)
                {
                    valor *= 100;
                }
                string strValor = valor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));
                if (a == 1) montagem += (b + c == 0) ? "Cem" : "Cento";
                else if (a == 2) montagem += "Duzentos";
                else if (a == 3) montagem += "Trezentos";
                else if (a == 4) montagem += "Quatrocentos";
                else if (a == 5) montagem += "Quinhentos";
                else if (a == 6) montagem += "Seiscentos";
                else if (a == 7) montagem += "Setecentos";
                else if (a == 8) montagem += "Oitocentos";
                else if (a == 9) montagem += "Novecentos";
                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " e " : string.Empty) + "Dez";
                    else if (c == 1) montagem += ((a > 0) ? " e " : string.Empty) + "Onze";
                    else if (c == 2) montagem += ((a > 0) ? " e " : string.Empty) + "Doze";
                    else if (c == 3) montagem += ((a > 0) ? " e " : string.Empty) + "Treze";
                    else if (c == 4) montagem += ((a > 0) ? " e " : string.Empty) + "Quatorze";
                    else if (c == 5) montagem += ((a > 0) ? " e " : string.Empty) + "Quinze";
                    else if (c == 6) montagem += ((a > 0) ? " e " : string.Empty) + "Dezesseis";
                    else if (c == 7) montagem += ((a > 0) ? " e " : string.Empty) + "Dezessete";
                    else if (c == 8) montagem += ((a > 0) ? " e " : string.Empty) + "Dezoito";
                    else if (c == 9) montagem += ((a > 0) ? " e " : string.Empty) + "Dezenove";
                }
                else if (b == 2) montagem += ((a > 0) ? " e " : string.Empty) + "Vinte";
                else if (b == 3) montagem += ((a > 0) ? " e " : string.Empty) + "Trinta";
                else if (b == 4) montagem += ((a > 0) ? " e " : string.Empty) + "Quarenta";
                else if (b == 5) montagem += ((a > 0) ? " e " : string.Empty) + "Cinquenta";
                else if (b == 6) montagem += ((a > 0) ? " e " : string.Empty) + "Sessenta";
                else if (b == 7) montagem += ((a > 0) ? " e " : string.Empty) + "Setenta";
                else if (b == 8) montagem += ((a > 0) ? " e " : string.Empty) + "Oitenta";
                else if (b == 9) montagem += ((a > 0) ? " e " : string.Empty) + "Noventa";
                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " e ";
                if (strValor.Substring(1, 1) != "1")
                    if (c == 1) montagem += "Um";
                    else if (c == 2) montagem += "Dois";
                    else if (c == 3) montagem += "Três";
                    else if (c == 4) montagem += "Quatro";
                    else if (c == 5) montagem += "Cinco";
                    else if (c == 6) montagem += "Seis";
                    else if (c == 7) montagem += "Sete";
                    else if (c == 8) montagem += "Oito";
                    else if (c == 9) montagem += "Nove";
                return montagem;
            }
        }
    }
}
