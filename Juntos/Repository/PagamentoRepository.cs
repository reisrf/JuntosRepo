using Juntos.IDAL;
using Juntos.IRepository;
using Juntos.Model;

namespace Juntos.Repository
{
    public class PagamentoRepository : BaseRepository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(IBaseDAO<Pagamento> entidadeDAO) : base(entidadeDAO)
        {
        }
    }
}
