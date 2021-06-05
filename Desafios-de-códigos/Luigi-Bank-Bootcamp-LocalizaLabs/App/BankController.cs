using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Luigi_Bank_Bootcamp_LocalizaLabs
{
    class BankController
    {
        private List<Conta> Contas = new List<Conta>();
        private Formatador Formatador = new Formatador();

        public BankController()
        {

        }

        public Conta ProcurarConta(string agencia, string conta)
        {
            Conta Conta = new Conta("0", "0");
            Conta.id = -1;

            for (int i = 0; i < this.Contas.Count; i++)
            {
                Conta Temporary = this.Contas[i];

                if (Temporary.agencia == agencia && Temporary.numero == conta)
                {
                    Conta = Temporary;
                }
            }

            return Conta;
        }

        public List<Conta> ListarContas()
        {
            return Contas;
        }

        public void CadastrarConta(Conta Conta)
        {
            this.Contas.Add(Conta);
        }

        public void Depositar(Conta Conta, double valor)
        {
            this.Contas[Conta.id].saldo += valor;
            Formatador.TrocarCor(ConsoleColor.DarkGreen);
            Console.WriteLine("\nOs {0, 2:C}, foram enviados para {1}!", valor, Conta.Favorecido.nome);
            Formatador.TrocarCor(ConsoleColor.Black);
        }

        public bool Sacar(Conta Conta, double valor)
        {
            if (this.Contas[Conta.id].saldo >= valor)
            {
                this.Contas[Conta.id].saldo -= valor;
                return true;
            }
            else
            {
                Formatador.TrocarCor(ConsoleColor.DarkRed);
                Console.WriteLine("\nSeu saldo não é suficiente para realizar esta transação.");
                Formatador.TrocarCor(ConsoleColor.Black);
                return false;
            }
        }
        public void Transferir(Conta Origer, Conta Destino, double valor)
        {
            if (this.Sacar(Origer, valor))
            {
                this.Depositar(Destino, valor);
            }
            else
            {
                Formatador.TrocarCor(ConsoleColor.DarkRed);
                Console.WriteLine("A transação NÃO foi efetuada.");
                Formatador.TrocarCor(ConsoleColor.Black);
            }
        }

        public bool CheckInputConta(string conta)
        {
            bool state = Regex.IsMatch(conta, "[0-9]{4}\\/[0-9]{5}-[0-9]{1}");
            return state;
        }

        internal int GerarId()
        {
            return this.Contas.Count;
        }
    }
}