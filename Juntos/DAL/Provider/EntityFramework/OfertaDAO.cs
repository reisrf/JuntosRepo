using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class OfertaDAO : IOfertaDAO
    {
        public void Adicionar(Oferta modelo)
        {
            JuntosContext.Instance.Ofertas.Add(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Oferta modelo)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Oferta modelo)
        {
            JuntosContext.Instance.Ofertas.Remove(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Oferta> Consultar(Func<Oferta, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Ofertas.Where(expressaoDeConsulta);
        }

        public List<Oferta> RetornarTodos()
        {
            return JuntosContext.Instance.Ofertas.ToList();
        }
    }
}
