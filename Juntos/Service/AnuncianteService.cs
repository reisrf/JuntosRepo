using Juntos.IRepository;
using Juntos.IService;
using Juntos.Model;

namespace Juntos.Service
{
    public class AnuncianteService : PessoaService<Anunciante>, IAnuncianteService
    {
        public AnuncianteService(IAnuncianteRepository anuncianteRepository) : base(anuncianteRepository)
        {
        }
    }
}
