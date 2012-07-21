using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class CupomDAO : ICupomDAO
    {
        public void Adicionar(Cupom cupom)
        {
            JuntosContext.Instance.Cupons.Add(cupom);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Cupom cupom)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Cupom cupom)
        {
            JuntosContext.Instance.Cupons.Remove(cupom);
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

        public Cupom BuscarPorId(long id)
        {
            return JuntosContext.Instance.Cupons.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}