using System;
using ConvertSN;
namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
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
            
            Console.WriteLine(ConvertNS.Toany(at, bt, s));

            

        }
    }
}
