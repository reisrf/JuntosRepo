using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.IRepository;
using Juntos.Model;

namespace Juntos.Repository
{
    public abstract class BaseRepository<TEntidade> : IBaseRepository<TEntidade> where TEntidade : Entidade
    {
        private readonly IBaseDAO<TEntidade> _entidadeDAO;

        protected BaseRepository(IBaseDAO<TEntidade> entidadeDAO)
        {
            this._entidadeDAO = entidadeDAO;
        }

        public void Adicionar(TEntidade entidade)
        {
            this._entidadeDAO.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            this._entidadeDAO.Atualizar(entidade);
        }

        public void Remover(TEntidade entidade)
        {
            this._entidadeDAO.Remover(entidade);
        }

        public List<TEntidade> Consultar(Func<TEntidade, bool> expressaoDeConsulta)
        {
            return this._entidadeDAO.Consultar(expressaoDeConsulta).ToList();
        }

        public List<TEntidade> RetornarTodos()
        {
            return this._entidadeDAO.RetornarTodos().ToList();
        }

        public TEntidade BuscarPorId(long id)
        {
            return this._entidadeDAO.BuscarPorId(id);
        }
    }
}
