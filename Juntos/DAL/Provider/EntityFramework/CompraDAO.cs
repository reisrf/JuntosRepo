using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class CompraDAO : ICompraDAO
    {
        public void Adicionar(Compra modelo)
        {
            JuntosContext.Instance.Compras.Add(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Compra modelo)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Compra modelo)
        {
            JuntosContext.Instance.Compras.Remove(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Compra> Consultar(Func<Compra, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Compras.Where(expressaoDeConsulta);
        }
    }
}
