using Juntos.IDAL;
using Juntos.IRepository;
using Juntos.Model;

namespace Juntos.Repository
{
    public class AnuncianteRepository : BaseRepository<Anunciante>, IAnuncianteRepository
    {
        public AnuncianteRepository(IAnuncianteDAO anuncianteDAO) : base(anuncianteDAO)
        {
        }
    }
}
