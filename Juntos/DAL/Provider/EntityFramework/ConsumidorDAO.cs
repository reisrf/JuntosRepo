using System;
using System.Collections.Generic;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class ConsumidorDAO : IConsumidorDAO
    {
        public void Adicionar(Consumidor entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Consumidor entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(Consumidor entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Consumidor> Consultar(Func<Consumidor, bool> expressaoDeConsulta)
        {
            throw new NotImplementedException();
        }
    }
}
