using System.Collections.Generic;
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



 public class AdvertiserService : PersonService<Advertiser>, IAdvertiserService 
    {
        public AdvertiserService(IAdvertiserRepository repository) : base(repository)
        {
        }
    }
    
    