using System;
using ConvertSN;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int at, bt;
            string s;
            Console.WriteLine ( "Введите число: ");
            s=Console.ReadLine(); 
            Console.WriteLine ( "Введите начальную систему: ");
            at =Convert.ToInt32 (Console.ReadLine());
            Console.WriteLine ( "Введите конечную систему: ");
            bt=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ответ ");
            if (at < 2 || at > 16 || bt < 2 || bt > 16) Console.WriteLine( "Введенные данные не удовлетворяют условию!");
            else
            { 
                Console.WriteLine(ConvertNS.Toany(at, bt, s));

            }

        }
    }
}
