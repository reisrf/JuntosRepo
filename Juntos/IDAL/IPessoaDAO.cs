using Juntos.Model;

namespace Juntos.IDAL
{
    public interface IPessoaDAO<TPessoa> : IBaseDAO<TPessoa>
        where TPessoa : Pessoa
    {
        
    }
}