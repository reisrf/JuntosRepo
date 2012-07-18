using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class CupomDAO : ICupomDAO
    {
        public void Adicionar(Cupom modelo)
        {
            JuntosContext.Instance.Cupons.Add(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Cupom modelo)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Cupom modelo)
        {
            JuntosContext.Instance.Cupons.Remove(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Cupom> Consultar(Func<Cupom, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Cupons.Where(expressaoDeConsulta);
        }

        public List<Cupom> RetornarTodos()
        {
            return JuntosContext.Instance.Cupons.ToList();
        }
    }
}