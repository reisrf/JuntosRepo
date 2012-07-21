using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class CompraDAO : ICompraDAO
    {
        public void Adicionar(Compra compra)
        {
            JuntosContext.Instance.Compras.Add(compra);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Compra compra)
        {
            var compraPersistida = this.BuscarPorId(compra.Id);
            if (compraPersistida != null)
            {
                this.Remover(compraPersistida);
            }
            this.Adicionar(compra);
        }

        public void Remover(Compra compra)
        {
            JuntosContext.Instance.Compras.Remove(compra);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Compra> Consultar(Func<Compra, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Compras.Where(expressaoDeConsulta);
        }
        public List<Compra> RetornarTodos()
        {
            return JuntosContext.Instance.Compras.ToList();
        }

        public Compra BuscarPorId(long id)
        {
            return JuntosContext.Instance.Compras.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
