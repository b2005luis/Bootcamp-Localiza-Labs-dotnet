using System;

namespace crescimento_populacional
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantos casos de teste? "); // Ocultar para executar os testes automatizados
            int t = Convert.ToInt32(Console.ReadLine());
            double[] arrayList = new double[4];
            int pa, pb;
            double cpa, cpb;
            int anos;

            for (int i = 0; i < t; i++)
            {
                anos = 0;
                Console.Write("InForme as populações e depois as taxas de crescimentos (1000 2000 2,10 1,5): "); // Ocultar para executar os testes automatizados
                string[] valores = Console.ReadLine().Split();
                pa = int.Parse(valores[0]);
                pb = int.Parse(valores[1]);
                cpa = double.Parse(valores[2]);
                cpb = double.Parse(valores[3]);

                while (pa <= pb && anos < 101)
                {
                    pa += (int)((pa * cpa) / 100);
                    pb += (int)((pb * cpb) / 100);
                    anos++;

                    if (anos > 100)
                    {
                        Console.WriteLine("Mais de 1 seculo.");
                    }
                }

                if (anos <= 100)
                {
                    Console.WriteLine("{0} anos.", anos);
                }
            }
        }
    }
}