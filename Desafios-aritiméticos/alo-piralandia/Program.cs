using System;
using System.Text.RegularExpressions;

namespace alo_piralandia
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] verso = Console.ReadLine().ToCharArray();
            Array.Reverse(verso);
            string Reverse = String.Join("", verso);
            Console.WriteLine(Reverse);
        }
    }
}
