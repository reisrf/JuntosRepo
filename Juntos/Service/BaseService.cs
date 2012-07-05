using System;
using System.Linq;
using Juntos.IRepository;
using Juntos.IService;
using Juntos.Model;

namespace Juntos.Service
{
    public abstract class BaseService<TEntidade> : IBaseService<TEntidade> 
        where TEntidade : Entidade
    {
        private readonly IBaseRepository<TEntidade> _repository;

        protected BaseService(IBaseRepository<TEntidade> repository)
        {
            this._repository = repository;
        }

        public void Adicionar(TEntidade entidade)
        {
            this._repository.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            this._repository.Atualizar(entidade);
        }

        public void Remover(TEntidade entidade)
        {
            this._repository.Remover(entidade);
        }

        public TEntidade ConsultarPeloId(Guid id)
        {
            return this._repository.Consultar(c => c.Id.Equals(id)).FirstOrDefault();
        }

        protected IBaseRepository<TEntidade> Repository { get { return this._repository; }}
    }
}
