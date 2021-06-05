using System;
using System.Text.RegularExpressions;

namespace Luigi_Bank_Bootcamp_LocalizaLabs
{
    class Program
    {
        private static BankController Controlador = new BankController();
        private static Formatador Formatador = new Formatador();

        public static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            string opcao = "";

            do
            {
                Formatador.TrocarCor(ConsoleColor.Black);
                Console.WriteLine("\nLuigi Bank! Vem pro digital! \n");

                Console.WriteLine("1 - Listar Contas");
                Console.WriteLine("2 - Abrir Nova Conta");
                Console.WriteLine("3 - Depositar");
                Console.WriteLine("4 - Sacar");
                Console.WriteLine("5 - Fazer Transferência \n");

                Console.Write("\nEscolha uma opção no menu: ");
                opcao = Console.ReadLine().ToUpper();

                switch (opcao)
                {
                    case "1":
                        ListarConta();
                        break;
                    case "2":
                        CadastrarConta();
                        break;
                    case "3":
                        Depositar();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Transferir();
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Escolha uma opção válida... \n");
                        Menu();
                        break;
                }
            } while (opcao != "X");
        }

        private static void Transferir()
        {
            bool state = false;
            string input_origem = "";
            string input_destino = "";

            do
            {
                Console.Write("Qual a Conta de Origem (No formato: 0000/00000-0)? ");
                input_origem = Console.ReadLine();
                state = Controlador.CheckInputConta(input_origem);
            } while (!state);

            do
            {
                Console.Write("Qual a Conta de Destino (No formato: 0000/00000-0)? ");
                input_destino = Console.ReadLine();
                state = Controlador.CheckInputConta(input_destino);
            } while (!state);

            Console.Write("Qual o valor da transferência (No formato: 0,00)? ");
            double input_valor = Convert.ToDouble(Console.ReadLine());

            if (state)
            {
                string[] _origem = input_origem.Split("/");
                Conta Origem = Controlador.ProcurarConta(_origem[0], _origem[1]);

                string[] _destino = input_destino.Split("/");
                Conta Destino = Controlador.ProcurarConta(_destino[0], _destino[1]);

                if (Origem.id >= 0 && Destino.id >= 0)
                {
                    Controlador.Transferir(Origem, Destino, input_valor);
                }
                else
                {
                    Formatador.TrocarCor(ConsoleColor.DarkRed);
                    Console.WriteLine("\nA conta de Origem ou de Destino não existe. Revise as informaç~ies e tente novamente.");
                    Formatador.TrocarCor(ConsoleColor.Black);
                }
            }
            else
            {
                Formatador.TrocarCor(ConsoleColor.DarkRed);
                Console.WriteLine("O formata de contas está incorreto.");
                Formatador.TrocarCor(ConsoleColor.Black);
            }
        }

        private static void Sacar()
        {
            bool state = false;
            string input_origem = "";

            do
            {
                Console.Write("Qual a Conta para Sacar (No formato: 0000/00000-0)? ");
                input_origem = Console.ReadLine();
                state = Controlador.CheckInputConta(input_origem);
            } while (!state);

            Console.Write("Qual o valor da transferência (No formato: 0,00)? ");
            double input_valor = Convert.ToDouble(Console.ReadLine());

            string[] _origem = input_origem.Split("/");
            Conta Origem = Controlador.ProcurarConta(_origem[0], _origem[1]);

            if (Origem.id >= 0)
            {
                Controlador.Sacar(Origem, input_valor);
            }
            else
            {
                Formatador.TrocarCor(ConsoleColor.DarkRed);
                Console.WriteLine("\nA conta de Saque não existe. Revise as informaç~ies e tente novamente.");
                Formatador.TrocarCor(ConsoleColor.Black);
            }
        }

        private static void Depositar()
        {
            bool state = false;
            string input_destino = "";

            do
            {
                Console.Write("Qual a Conta para Sacar (No formato: 0000/00000-0)? ");
                input_destino = Console.ReadLine();
                state = Controlador.CheckInputConta(input_destino);
            } while (!state);

            Console.Write("Qual o valor da transferência (No formato: 0,00)? ");
            double input_valor = Convert.ToDouble(Console.ReadLine());

            string[] _destino = input_destino.Split("/");
            Conta Destino = Controlador.ProcurarConta(_destino[0], _destino[1]);

            if (Destino.id >= 0)
            {
                Controlador.Depositar(Destino, input_valor);
            }
            else
            {
                Formatador.TrocarCor(ConsoleColor.DarkRed);
                Console.WriteLine("\nA conta de Deposito não existe. Revise as informaç~ies e tente novamente.");
                Formatador.TrocarCor(ConsoleColor.Black);
            }
        }

        private static void ListarConta()
        {
            Console.Clear();
            foreach (Conta Conta in Controlador.ListarContas())
            {
                Conta.ToString();
            }
        }

        private static void CadastrarConta()
        {
            Conta NovaConta = new Conta();

            NovaConta.id = Controlador.GerarId();
            Console.WriteLine("\nCadastro de Clientes :: Novo Cliente\n");
            Console.Write("Nome do titular: ");
            NovaConta.Favorecido.nome = Console.ReadLine();
            Console.Write("Agencia de origem: ");
            NovaConta.agencia = Console.ReadLine();
            Console.Write("Numero da conta: ");
            NovaConta.numero = Console.ReadLine();
            Console.Write("Saldo inicial: ");
            NovaConta.saldo = Convert.ToDouble(Console.ReadLine());

            Controlador.CadastrarConta(NovaConta);
        }
    }
}