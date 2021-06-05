/*
Desafio

Em um episódio da aclamada série The Big Ban Theor dois pernagens, 
Sheldon e Raj, discutem qual dos dois é o melhor: o filme Saturn 3 
ou a série Deep Space 9. A sugestão de Raj para a resolução 
do impasse é uma disputa de Pedra-Papel-Tesoura. Contudo, 
Sheldon argumenta que, se as partes envolvidas se conhecem, 
entre 75% e 80% das disputas de Pedra-Papel-Tesoura terminam empatadas, 
e então sugere o Pedra-Papel-Tesoura-Lagarto-Spock.

As regras do jogo proposto são:

01 - a tesoura corta o papel;
02 - o papel embrulha a pedra;
03 - a pedra esmaga o lagarto;
04 - o lagarto envenena Spock;
05 - Spock destrói a tesoura;
06 - a tesoura decapita o lagarto;
07 - o lagarto come o papel;
08 - o papel contesta Spock;
09 - Spock vaporiza a pedra;
10 - a pedra quebra a tesoura.

Conhecendo os personagens, sabemos que caso Sheldon vencesse, 
ele gritaria a vitória com um "Bazinga!". 
Se Raj vencesse, Sheldon o acusaria de ter trapaceado. 
Agora, se desse empate, Sheldon não descansaria e insistira para jogarem 
de novo até que seja decidido. Sabendo dessas ações, 
faça um programa que imprima a provável reação de Sheldon.
*/

using System;

namespace jokenpo
{
    class Program
    {
        static void Main(string[] args)
        {
            int qtdTeste = int.Parse(Console.ReadLine());
            string v1, v2;
            for (int i = 1; i <= qtdTeste; i++) //insira a variavel correta
            {
                string[] valores = Console.ReadLine().Split();
                v1 = valores[0].ToUpper();
                v2 = valores[1].ToUpper();

                if ((v1.Equals("TESOURA") && v2.Equals("PAPEL"))
                || (v1.Equals("PAPEL") && v2.Equals("PEDRA"))
                || (v1.Equals("PEDRA") && v2.Equals("LAGARTO"))
                || (v1.Equals("LAGARTO") && v2.Equals("SPOCK"))
                || (v1.Equals("SPOCK") && v2.Equals("TESOURA"))
                || (v1.Equals("TESOURA") && v2.Equals("LAGARTO"))
                || (v1.Equals("LAGARTO") && v2.Equals("PAPEL"))
                || (v1.Equals("PAPEL") && v2.Equals("SPOCK"))
                || (v1.Equals("SPOCK") && v2.Equals("PEDRA"))
                || (v1.Equals("PEDRA") && v2.Equals("TESOURA")))
                {
                    Console.WriteLine("Caso #{0}: Bazinga!", i);
                }
                else if (v1.Equals(v2))
                {   //complete a solucao
                    Console.WriteLine("Caso #{0}: De novo!", i);
                }
                else
                {
                    Console.WriteLine("Caso #{0}: Raj trapaceou!", i);
                }
            }
        }
    }
}