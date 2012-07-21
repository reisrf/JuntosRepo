using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class AnuncianteDAO : IAnuncianteDAO
    {
        public void Adicionar(Anunciante anunciante)
        {
            JuntosContext.Instance.Anunciantes.Add(anunciante);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Anunciante anunciante)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Anunciante anunciante)
        {
            JuntosContext.Instance.Anunciantes.Remove(anunciante);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Anunciante> Consultar(Func<Anunciante, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Anunciantes.Where(expressaoDeConsulta);
        }

        public List<Anunciante> RetornarTodos()
        {
            return JuntosContext.Instance.Anunciantes.ToList();
        }

        public Anunciante BuscarPorId(long id)
        {
            return JuntosContext.Instance.Anunciantes.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
