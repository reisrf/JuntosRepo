using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class PagamentoDAO : IPagamentoDAO
    {
        public void Adicionar(Pagamento modelo)
        {
            JuntosContext.Instance.Pagamentos.Add(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Pagamento modelo)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Pagamento modelo)
        {
            JuntosContext.Instance.Pagamentos.Remove(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Pagamento> Consultar(Func<Pagamento, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Pagamentos.Where(expressaoDeConsulta);
        }

        public List<Pagamento> RetornarTodos()
        {
            return JuntosContext.Instance.Pagamentos.ToList();
        }

        public Pagamento BuscarPorId(Guid id)
        {
            return JuntosContext.Instance.Pagamentos.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
