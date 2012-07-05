using Juntos.IRepository;
using Juntos.IService;
using Juntos.Model;

namespace Juntos.Service
{
    public class ConsumidorService : PessoaService<Consumidor>, IConsumidorService 
    {
        public ConsumidorService(IConsumidorRepository consumidorRepository) : base(consumidorRepository)
        {
        }
    }
}
