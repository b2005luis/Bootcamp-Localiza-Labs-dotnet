using System;

namespace tempo_do_evento
{
    class Program
    {
        static void Main(string[] args)
        {
            int diaInicio, diaTermino, horaMomentoInicio, minutoMomentoInicio, segundoMomentoInicio;
            int horaMomentoTermino, minutoMomentoTermino, segundoMomentoTerminio;

            string[] dadosInicio = Console.ReadLine().Split();
            diaInicio = Convert.ToInt32(dadosInicio[1]);

            string[] dadosMomentoInicio = Console.ReadLine().Split(":");
            horaMomentoInicio = Convert.ToInt32(dadosMomentoInicio[0]);
            minutoMomentoInicio = Convert.ToInt32(dadosMomentoInicio[1]);
            segundoMomentoInicio = Convert.ToInt32(dadosMomentoInicio[2]);

            string[] dadosTermino = Console.ReadLine().Split();
            diaTermino = Convert.ToInt32(dadosTermino[1]);

            string[] dadosMomentoTermino = Console.ReadLine().Split(":");
            horaMomentoTermino = Convert.ToInt32(dadosMomentoTermino[0]);
            minutoMomentoTermino = Convert.ToInt32(dadosMomentoTermino[1]);
            segundoMomentoTerminio = Convert.ToInt32(dadosMomentoTermino[2]);

            int dsDia = (diaTermino - diaInicio) * 60 * 60;
            int dsMinuto = (minutoMomentoTermino - minutoMomentoInicio) * 60 * 60;
            int dsSegyndo = segundoMomentoTerminio - segundoMomentoInicio;

            int transformaSegundosInicio = ((60 * 60 * horaMomentoInicio) + (60 * minutoMomentoInicio) + segundoMomentoInicio);
            int transformaSegundosTermino = ((60 * 60 * horaMomentoTermino) + (60 * minutoMomentoTermino) + segundoMomentoTerminio);

            int somaTotalSegundos = (transformaSegundosInicio + transformaSegundosTermino);

            int W = diaTermino - diaInicio; // Dias
            int X = somaTotalSegundos / ((60 * 60) * 24); // Horas
            int Y = somaTotalSegundos / (60 * 60); // Minutos
            int Z = somaTotalSegundos / 60; // Sefundos

            Console.WriteLine("{0} dia(s)", W);
            Console.WriteLine("{0} hora(s)", X);
            Console.WriteLine("{0} minuto(s)", Y);
            Console.WriteLine("{0} segundo(s)", Z);
        }
    }
}