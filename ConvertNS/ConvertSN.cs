using System;
using System.Globalization;
using System.Linq;

namespace ConvertSN
{

    public static class ConvertNS
    {
        private static Exception OutOfBounce = new Exception("OutOFBounce");
        private static int at;
        private static int tempi;
        private static int bt;
        private static double tempd;
        private static string s;
        private static string temps;
        private static string ex;
        private static int a;


        private static int CharToInt(char a)
        {
            if (a > 0) return a - 48;
            return a + 74;
        }
        private static string Whole_number(int at, string ex, int bt, string temps, int tempi, string s)
        {
            for (var i = 0; i < s.Length && s[i] != '.'; ++i) temps += s[i];    //До точки

            tempi = temps.Aggregate(tempi, (current, t) => current * at + CharToInt(t));

            if (tempi == 0) Console.WriteLine("0");
            else
            {
                while (tempi != 0)
                {
                    ex = Convert.ToString(tempi % bt) + ex;
                    tempi /= bt;
                }
            }
            return ex;
        }
        private static string D_number(int at, string ex, int bt, string temps, int tempi, string s, double tempd)
        {
            ex = temps;
            temps = "";
            for (var i = ex.Length + 1; i < s.Length - 1; ++i) temps = temps + s[i];  //После
            if (temps.Length > 0)
            {
                ex = "";
                for (var i = temps.Length - 1; i >= 0; --i) tempd = (CharToInt(temps[i]) + tempd) / at;
                while (Math.Round(tempd) > 0) tempd = tempd * 0.1;
                while (tempd > 0)
                {
                    tempd *= bt;
                    ex += Convert.ToString(Math.Round(tempd), CultureInfo.InvariantCulture);
                    tempd -= Math.Round(tempd);
                }
            }
            return ex;

        }
        public static string Toany(int at, int bt, string s)
        {
            for (var i = 0; s[i] != '.' && i < s.Length - 1; ++i)
            {
                if (s[i] == '.')
                {
                    a = 1;
                }
            }
            if (a == 1)
            {
                return Whole_number(at, ex, bt, temps, tempi, s) + "." + D_number(at, ex, bt, temps, tempi, s, tempd);
            }
            else return Whole_number(at, ex, bt, temps, tempi, s);
        }
    }
}
