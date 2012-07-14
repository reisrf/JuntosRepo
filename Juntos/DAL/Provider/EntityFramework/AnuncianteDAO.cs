using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class AnuncianteDAO : IAnuncianteDAO
    {
        public void Adicionar(Anunciante entidade)
        {
            JuntosContext.Instance.Anunciantes.Add(entidade);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Anunciante entidade)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Anunciante entidade)
        {
            JuntosContext.Instance.Anunciantes.Remove(entidade);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Anunciante> Consultar(Func<Anunciante, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Anunciantes.Where(expressaoDeConsulta);
        }
    }
}
