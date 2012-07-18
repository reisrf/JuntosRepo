using System;
using System.Collections.Generic;
using Juntos.Model;

namespace Juntos.IService
{
    public interface IBaseService<TEntidade>
        where TEntidade : Entidade
    {
        void Adicionar(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void Remover(TEntidade entidade);
        TEntidade BuscarPorId(Guid id);
        List<TEntidade> RetornarTodos();
    }
}