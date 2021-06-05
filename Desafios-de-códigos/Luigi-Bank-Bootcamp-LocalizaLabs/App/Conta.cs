using System;

namespace Luigi_Bank_Bootcamp_LocalizaLabs
{
    class Conta
    {
        public int id { get; set; }
        public TipoConta tipo { get; set; }
        public string agencia { get; set; }
        public string numero { get; set; }
        public double saldo { get; set; }
        public Pessoa Favorecido { get; set; }

        public Conta()
        {
            this.Favorecido = new Pessoa("");
            this.saldo = 0.00;
        }

        public Conta(string agencia, string numero)
        {
            this.Favorecido = new Pessoa("");
            this.agencia = agencia;
            this.numero = numero;
            this.saldo = 0.00;
        }

        public override string ToString()
        {
            Console.WriteLine("\nDETALHE DA CONTA");
            Console.WriteLine("Identificador: {0}", this.id);
            Console.WriteLine("Favorecido: {0}", this.Favorecido.nome);
            Console.WriteLine("Agencia: {0}", this.agencia);
            Console.WriteLine("Conta: {0}", this.numero);
            Console.WriteLine("Saldo: {0, 2:C}", this.saldo);
            return "";
        }
    }
}