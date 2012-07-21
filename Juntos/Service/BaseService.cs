using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IRepository;
using Juntos.IService;
using Juntos.Model;
using Framework;

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
            var persistido = this.BuscarPorId(entidade.Id);
            this._repository.Atualizar(persistido.Hidratar(entidade));
        }

        public void Remover(TEntidade entidade)
        {
            this._repository.Remover(entidade);
        }

        public void Salvar(TEntidade entidade)
        {
            if (entidade.Id == 0)
            {
                this.Adicionar(entidade);
            }
            else
            {
                this.Atualizar(entidade);
            }
        }

        public TEntidade BuscarPorId(long id)
        {
            return this._repository.Consultar(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public List<TEntidade> RetornarTodos()
        {
            return this._repository.RetornarTodos().ToList();
        }


        protected IBaseRepository<TEntidade> Repository { get { return this._repository; }}
    }
}
