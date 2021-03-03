using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConvertSN
{
    
    public static class ConvertNS
    {
        private static Exception OutOfBounce = new Exception("OutOFBounce");
        private static Exception ofrangeException = new Exception("OfRange");
            // private static Exception 
        private static string str;
        private static string temps;

        private static int CharToInt(char a)
        {
            if (a >= 'A') return a - 55;
            if (a > 0) return a - 48;
            return a + 74;
        }
        private static string Whole_number(int at,  int bt)
        {
            string ex="";
            int tempi=0;

            for (var i = 0; i < str.Length && str[i] != '.'; ++i) temps += str[i];    //До точки

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
        private static string D_number(int at,  int bt)
        {
            string ex;
            double tempd=0;
            ex = temps;
            temps = "";
            for (var i = ex.Length + 1; i < str.Length ; ++i) temps += str[i];  //После
            if (temps.Length > 0)
            {
                ex = "";
                for (var i = temps.Length - 1; i >= 0; --i) tempd = (CharToInt(temps[i]) + tempd) / at;
               // while (Math.Round(tempd, MidpointRounding.AwayFromZero) > 0) tempd *= 0.1;
                while (tempd > 0)
                {
                    tempd *= bt;
                    ex += Convert.ToString(Math.Round(tempd, MidpointRounding.AwayFromZero));
                    tempd -= Math.Round(tempd, MidpointRounding.AwayFromZero);
                }
            }
            return ex;

        }
        public static string Toany(int at, int bt, string s)
        {
            str = s;
            int a=0;
            for (var i = 0; i < str.Length; ++i)
            {
                if (str[i] == '.')
                {
                    a = 1;
                }
            }
            if (a == 1)
            {
                return Whole_number(at,  bt) + "." + D_number(at,  bt);
            }
            else return Whole_number(at, bt);
        }
    }
}
