using System;
using System.Collections.Generic;
using Juntos.Model;

namespace Juntos.IRepository
{
    public interface IBaseRepository<TEntidade> where TEntidade : Entidade
    {
        void Adicionar(TEntidade pessoa);
        void Atualizar(TEntidade pessoa);
        void Remover(TEntidade pessoa);
        List<TEntidade> Consultar(Func<TEntidade, bool> expressaoDeConsulta);
    }
}