using System;
using Juntos.Model;

namespace Juntos.IService
{
    public interface IBaseService<TEntidade>
        where TEntidade : Entidade
    {
        void Adicionar(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void Remover(TEntidade entidade);
        TEntidade ConsultarPeloId(Guid id);
    }
}