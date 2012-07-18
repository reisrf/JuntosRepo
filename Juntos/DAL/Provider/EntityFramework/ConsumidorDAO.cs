﻿using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class ConsumidorDAO : IConsumidorDAO
    {
        public void Adicionar(Consumidor entidade)
        {
            JuntosContext.Instance.Consumidores.Add(entidade);
        }

        public void Atualizar(Consumidor entidade)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Consumidor entidade)
        {
            JuntosContext.Instance.Consumidores.Remove(entidade);
        }

        public IEnumerable<Consumidor> Consultar(Func<Consumidor, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Consumidores.Where(expressaoDeConsulta);
        }

        public List<Consumidor> RetornarTodos()
        {
            return JuntosContext.Instance.Consumidores.ToList();
        }

    }
}
