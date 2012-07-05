using Juntos.IDAL;
using Juntos.IRepository;
using Juntos.Model;

namespace Juntos.Repository
{
    public class ConsumidorRepository : BaseRepository<Consumidor>, IConsumidorRepository
    {
        public ConsumidorRepository(IConsumidorDAO consumidorDAO) : base(consumidorDAO)
        {
        }
    }
}
