using Juntos.IDAL;
using Juntos.IRepository;
using Juntos.Model;

namespace Juntos.Repository
{
    public class OfertaRepository : BaseRepository<Oferta>, IOfertaRepository
    {
        public OfertaRepository(IOfertaDAO ofertaDAO) : base(ofertaDAO)
        {
        } 
    }
}
