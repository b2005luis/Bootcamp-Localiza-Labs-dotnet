using System;

namespace cadastrando_series
{
    class Serie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public Genero Genero { get; set; }
        public bool Excluido { get; set; }

        public string EstaDisponivel() {
            return (this.Excluido) ? "Não" : "Sim";
        }

        public override string ToString()
        {
            Console.WriteLine("\nDETALHES DA SÉRIE");
            Console.WriteLine("Id: {0}", this.Id);
            Console.WriteLine("Titulo: {0}", this.Titulo);
            Console.WriteLine("Descrição: {0}", this.Descricao);
            Console.WriteLine("Ano: {0}", this.Ano);
            Console.WriteLine("Genero: {0}", Enum.GetName(this.Genero));
            Console.WriteLine("Está disponível: {0}", this.EstaDisponivel());
            return "Serie.ToString()";
        }
    }
}