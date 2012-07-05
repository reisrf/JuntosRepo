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

        public void Adicionar(TEntidade pessoa)
        {
            this._entidadeDAO.Adicionar(pessoa);
        }

        public void Atualizar(TEntidade pessoa)
        {
            this._entidadeDAO.Atualizar(pessoa);
        }

        public void Remover(TEntidade pessoa)
        {
            this._entidadeDAO.Remover(pessoa);
        }

        public List<TEntidade> Consultar(Func<TEntidade, bool> expressaoDeConsulta)
        {
            return this._entidadeDAO.Consultar(expressaoDeConsulta).ToList();
        }
    }
}
