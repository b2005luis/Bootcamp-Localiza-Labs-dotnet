using System;

namespace Luigi_Bank_Bootcamp_LocalizaLabs
{
    public class Formatador
    {
        public void TrocarFundo(ConsoleColor consoleColor) {
            Console.BackgroundColor = consoleColor;
        }
        public void TrocarCor(ConsoleColor consoleColor) {
            Console.ForegroundColor = consoleColor;
        }

    }
}