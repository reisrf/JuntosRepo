using System.Collections.Generic;
using Juntos.Model;

namespace Juntos.IService
{
    public interface IPessoaService<TPessoa> : IBaseService<TPessoa>
        where TPessoa : Pessoa
    {
        List<TPessoa> ConsultarPeloNome(string nome);
        TPessoa ConsultarPeloCpfOuCnpj(long cpfCnpj);
        TPessoa ConsultarPeloEmail(string email);
    }
}