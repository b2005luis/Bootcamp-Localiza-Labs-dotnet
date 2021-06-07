using System.Collections.Generic;

namespace cadastrando_series
{
    class SerieRepository : IRepository<Serie>
    {
        private List<Serie> Series = new List<Serie>();

        public bool Alterar(int Id, Serie Objeto)
        {
            if (Id <= this.Series.Count && this.Series[Id] != null)
            {
                this.Series[Id] = Objeto;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Serie BuscaPorId(int Id)
        {
            Serie Serie = new Serie();
            Serie.Excluido = true;

            if (Id <= this.Series.Count && this.Series[Id] != null)
            {
                Serie = this.Series[Id];
            }

            return Serie;
        }

        public void Cadastrar(Serie Objeto)
        {
            Objeto.Id = this.ProximoId();
            this.Series.Add(Objeto);
        }

        public List<Serie> ListarTudo()
        {
            return this.Series;
        }

        public int ProximoId()
        {
            return this.Series.Count;
        }

        public bool Remover(int Id, Serie Objeto)
        {
            if (Id <= this.Series.Count && this.Series[Id] != null)
            {
                this.Series[Id].Excluido = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}