using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class OfertaDAO : IOfertaDAO
    {
        public void Adicionar(Oferta oferta)
        {
            JuntosContext.Instance.Ofertas.Add(oferta);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Oferta oferta)
        {
            var ofertaPersistida = this.BuscarPorId(oferta.Id);
            if (ofertaPersistida != null)
            {
                this.Remover(ofertaPersistida);
            }
            this.Adicionar(oferta);
        }

        public void Remover(Oferta oferta)
        {
            JuntosContext.Instance.Ofertas.Remove(oferta);
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
        public Oferta BuscarPorId(long id)
        {
            return JuntosContext.Instance.Ofertas.Where(a => a.Id == id).FirstOrDefault();
        }
    }

}
