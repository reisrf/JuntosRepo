using System;
using System.Collections.Generic;

namespace Juntos.IDAL
{
    public interface IBaseDAO<TEntidade>
    {
        void Adicionar(TEntidade entidade);

        void Atualizar(TEntidade entidade);

        void Remover(TEntidade entidade);

        IEnumerable<TEntidade> Consultar(Func<TEntidade, bool> expressaoDeConsulta);
    }
}
