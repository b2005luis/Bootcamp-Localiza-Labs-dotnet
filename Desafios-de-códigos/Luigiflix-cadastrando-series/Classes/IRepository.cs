using System.Collections.Generic;

namespace cadastrando_series
{
    public interface IRepository<T>
    {
        List<T> ListarTudo();
        T BuscaPorId(int ix);
        void Cadastrar(T Objeto);
        bool Alterar(int ix, T Objeto);
        bool Remover(int ix, T Objeto);
        int ProximoId();
    }
}