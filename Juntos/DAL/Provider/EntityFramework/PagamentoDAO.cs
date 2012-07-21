using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class PagamentoDAO : IPagamentoDAO
    {
        public void Adicionar(Pagamento pagamento)
        {
            JuntosContext.Instance.Pagamentos.Add(pagamento);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Pagamento pagamento)
        {
            var pagamentoPersistido = this.BuscarPorId(pagamento.Id);
            if (pagamentoPersistido != null)
            {
                this.Remover(pagamentoPersistido);
            }
            this.Adicionar(pagamento);
        }

        public void Remover(Pagamento pagamento)
        {
            JuntosContext.Instance.Pagamentos.Remove(pagamento);
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

        public Pagamento BuscarPorId(long id)
        {
            return JuntosContext.Instance.Pagamentos.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
