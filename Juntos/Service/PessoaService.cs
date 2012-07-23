using System.Collections.Generic;
using System.Linq;
using Juntos.IRepository;
using Juntos.IService;
using Juntos.Model;

namespace Juntos.Service
{
    public abstract class PessoaService<TPessoa> : BaseService<TPessoa>, IPessoaService<TPessoa>
        where TPessoa : Pessoa
    {
        protected PessoaService(IBaseRepository<TPessoa> repository) : base(repository)
        {
        }

        public List<TPessoa> ConsultarPeloNome(string nome)
        {
            return this.Repository.Consultar(e => e.Nome.Contains(nome));
        }

        public TPessoa ConsultarPeloCpfOuCnpj(long cpfCnpj)
        {
            return this.Repository.Consultar(e => e.CpfCnpj.Equals(cpfCnpj)).FirstOrDefault();
        }

        public TPessoa ConsultarPeloEmail(string email)
        {
            return this.Repository.Consultar(e => e.Email.Equals(email)).FirstOrDefault();
        }
    }
}
