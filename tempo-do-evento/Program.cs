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

            DateTime dataInicio = new DateTime(
                DateTime.Now.Year, DateTime.Now.Month, diaInicio,
                horaMomentoInicio, minutoMomentoInicio, segundoMomentoInicio);

            string[] dadosTermino = Console.ReadLine().Split();
            diaTermino = Convert.ToInt32(dadosTermino[1]);

            string[] dadosMomentoTermino = Console.ReadLine().Split(":");
            horaMomentoTermino = Convert.ToInt32(dadosMomentoTermino[0]);
            minutoMomentoTermino = Convert.ToInt32(dadosMomentoTermino[1]);
            segundoMomentoTerminio = Convert.ToInt32(dadosMomentoTermino[2]);

            DateTime dataFim = new DateTime(
                DateTime.Now.Year, DateTime.Now.Month, diaTermino,
                horaMomentoTermino, minutoMomentoTermino, segundoMomentoTerminio);

            int W = (int)(dataFim - dataInicio).TotalDays; // Dias
            dataFim = dataFim.AddDays(-W);
            int X = (int)(dataFim - dataInicio).TotalHours; // Horas
            dataFim = dataFim.AddHours(-X);
            int Y = (int)(dataFim - dataInicio).TotalMinutes; // Minutos
            dataFim = dataFim.AddMinutes(-Y);
            int Z = (int)(dataFim - dataInicio).TotalSeconds; // Segundos

            Console.WriteLine("{0} dia(s)", W);
            Console.WriteLine("{0} hora(s)", X);
            Console.WriteLine("{0} minuto(s)", Y);
            Console.WriteLine("{0} segundo(s)", Z);
        }
    }
}