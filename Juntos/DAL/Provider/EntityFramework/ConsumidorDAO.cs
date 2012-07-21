using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class ConsumidorDAO : IConsumidorDAO
    {
        public void Adicionar(Consumidor consumidor)
        {
            JuntosContext.Instance.Consumidores.Add(consumidor);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Consumidor consumidor)
        {
            var consumidorPersistida = this.BuscarPorId(consumidor.Id);
            if (consumidorPersistida != null)
            {
                this.Remover(consumidorPersistida);
            }
            this.Adicionar(consumidor);
        }

        public void Remover(Consumidor consumidor)
        {
            JuntosContext.Instance.Consumidores.Remove(consumidor);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Consumidor> Consultar(Func<Consumidor, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Consumidores.Where(expressaoDeConsulta);
        }

        public List<Consumidor> RetornarTodos()
        {
            return JuntosContext.Instance.Consumidores.ToList();
        }

        public Consumidor BuscarPorId(long id)
        {
            return JuntosContext.Instance.Consumidores.Where(a => a.Id == id).FirstOrDefault();
        }

    }
}
