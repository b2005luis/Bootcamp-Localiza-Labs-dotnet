using System;

namespace cadastrando_series
{
    class Program
    {
        private static SerieRepository Repositorio = new SerieRepository();

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            string opcao = "";

            do
            {
                ColorirConsole(ConsoleColor.DarkBlue);
                Console.WriteLine("\nLuigiflix - As suas séries favoritas em um só lugar!\n");

                ColorirConsole(ConsoleColor.Black);
                Console.WriteLine("1 - Lista de Séries");
                Console.WriteLine("2 - Cadastrar Série");
                Console.WriteLine("3 - Alterar Série");
                Console.WriteLine("4 - Remover Série");
                Console.WriteLine("5 - Ver Destalhes");
                Console.WriteLine("0 - Limpar Tela");
                Console.WriteLine("X - Sair");

                Console.Write("\nEscolha uma das opção do menu: ");
                opcao = Console.ReadLine().ToUpper();
                Redirecionar(opcao);
            } while (opcao != "X");
        }

        private static void Redirecionar(string opecao)
        {
            switch (opecao)
            {
                case "1":
                    ListarTudo();
                    break;
                case "2":
                    cadastrarSerie();
                    break;
                case "3":
                    AlterarSerie();
                    break;
                case "4":
                    RemoverSerie();
                    break;
                case "0":
                    Console.Clear();
                    break;
                case "X":
                    // Encerrar o programa
                    break;
                default:
                    Menu();
                    break;
            }
        }

        private static void RemoverSerie()
        {
            Serie Serie = new Serie();
            Console.WriteLine("\nALTERAR DE SÉRIE");
            Console.Write("Id da Série para alterar: ");
            int Id = Convert.ToInt16(Console.ReadLine());

            Serie = Repositorio.BuscaPorId(Id);
            if (!Serie.Excluido)
            {
                Repositorio.Remover(Id, Serie);
            }
            else
            {
                ColorirConsole(ConsoleColor.DarkRed);
                Console.WriteLine("\nA Seérie com Id {0} não foi encontrada.\n", Id);
                ColorirConsole(ConsoleColor.Black);
            }
        }

        private static void AlterarSerie()
        {
            Serie Serie = new Serie();
            Console.WriteLine("\nALTERAR DE SÉRIE");
            Console.Write("Id da Série para alterar: ");
            int Id = Convert.ToInt16(Console.ReadLine());

            Serie = Repositorio.BuscaPorId(Id);

            if (!Serie.Excluido)
            {
                Console.Write("Titulo da Série: De {0} Para: ", Serie.Titulo);
                Serie.Titulo = Console.ReadLine();
                Console.Write("Descrição da Série: De {0} Para: ", Serie.Descricao);
                Serie.Descricao = Console.ReadLine();
                Console.WriteLine("\nLista de Generos: ");
                int contador = 0;
                foreach (string Item in Enum.GetNames<Genero>())
                {
                    Console.WriteLine("{0} - {1}", ++contador, Item);
                }
                Console.Write("\nQual é o Genero? De {0} Para: ", Enum.GetName(Serie.Genero));
                Serie.Genero = Enum.Parse<Genero>(Console.ReadLine());
                Console.Write("Ano de Lançamento: De {0} Para: ", Serie.Ano);
                Serie.Ano = Convert.ToInt16(Console.ReadLine());

                Repositorio.Alterar(Id, Serie);
            }
            else
            {
                ColorirConsole(ConsoleColor.DarkRed);
                Console.WriteLine("\nA Seérie com Id {0} não foi encontrada.\n", Id);
                ColorirConsole(ConsoleColor.Black);
            }
        }

        private static void cadastrarSerie()
        {
            Serie Serie = new Serie();

            Console.WriteLine("CADASTRANDO NOVA SÉRIE");

            Console.Write("Titulo da Série: ");
            Serie.Titulo = Console.ReadLine();
            Console.Write("Descrição da Série: ");
            Serie.Descricao = Console.ReadLine();

            Console.WriteLine("\nLista de Generos: ");
            int contador = 0;
            foreach (string Item in Enum.GetNames<Genero>())
            {
                Console.WriteLine("{0} - {1}", ++contador, Item);
            }
            Console.Write("\nQual é o Genero? ");
            Serie.Genero = Enum.Parse<Genero>(Console.ReadLine());

            Console.Write("Ano de Lançamento: ");
            Serie.Ano = Convert.ToInt16(Console.ReadLine());

            Repositorio.Cadastrar(Serie);
        }

        private static void ListarTudo()
        {
            foreach (Serie Serie in Repositorio.ListarTudo())
            {
                Serie.ToString();
            }
        }

        public static void ColorirConsole(ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
        }
    }
}
