using System;
using System.Linq;

namespace ConvertSN
{
    public static class ConvertNS
    {
        private static string str;
        private static string temps;

        private static int CharToInt(char a)
        {
            if (a >= 'A') return a - 55;
            if (a > 0) return a - 48;
            return a + 74;
        }

        /// <summary>
        /// Convert integer part of a number
        /// </summary>
        /// <param name="at">from which number system to convert</param>
        /// <param name="bt">in which number system to convert</param>
        /// <returns>whole part</returns>
        private static string Whole_number(int at, int bt)
        {
            string ex = "";
            int tempi = 0;

            for (int i = 0; i < str.Length && str[i] != '.'; ++i) temps += str[i]; //До точки

            tempi = temps.Aggregate(tempi, (current, t) => current * at + CharToInt(t));

            if (tempi == 0) Console.WriteLine("0");
            else
                while (tempi != 0)
                {
                    ex = Convert.ToString(tempi % bt) + ex;
                    tempi /= bt;
                }

            return ex;
        }
        /// <summary>
        /// Convert fractional part of number
        /// </summary>
        /// <param name="at">from which number system to convert</param>
        /// <param name="bt">in which number system to convert</param>
        /// <returns>fractional part</returns>
        private static string D_number(int at, int bt)
        {
            string ex;
            double tempd = 0;
            ex = temps;
            temps = "";
            for (int i = ex.Length + 1; i < str.Length; ++i) temps += str[i]; //После
            if (temps.Length > 0)
            {
                ex = "";
                for (int i = temps.Length - 1; i >= 0; --i) tempd = (CharToInt(temps[i]) + tempd) / at;
                //while (Math.Round(tempd, MidpointRounding.AwayFromZero) > 0) tempd *= 0.1;
                while (tempd > 0)
                {
                    tempd *= bt;
                    ex += Convert.ToString(Math.Round(tempd, MidpointRounding.AwayFromZero));
                    tempd -= Math.Round(tempd, MidpointRounding.AwayFromZero);
                }
            }

            return ex;
        }
        /// <summary>
        /// Convert from any number system to any
        /// </summary>
        /// <param name ="from_ns">from which number system to convert</param>
        /// <param name="to_ns">in which number system to convert</param>
        /// <param name="numberS">translated number</param>
        /// <returns>Converted number</returns>
        public static string Toany(int from_ns, int to_ns, string numberS)
        {
            if (numberS == "") return "EmptyString";
            str = numberS;
            int a = 0;


            if (from_ns < 2 || from_ns > 26) return "OutOfNumberSystem";
            if (to_ns < 2 || to_ns > 26) return "OutOfNumberSystem";
            foreach (char t in str)
                if (t == '.')
                    a = 1;
            if (a == 1)
                return Whole_number(from_ns, to_ns) + "." + D_number(from_ns, to_ns);
            return Whole_number(from_ns, to_ns);
        }
    }
}