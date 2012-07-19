using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace juntos.PagamentoService.model
{
    public class Pagamentos
    {
        static Dictionary<Guid, Pagamento> pagamentos = new Dictionary<Guid, Pagamento>();

        public static void Add(Pagamento pagamento)
        {
            pagamentos.Add(pagamento.Codigo, pagamento);
        }

        public static Pagamento BuscarPagamento(Guid pagamentoId)
        {
            Pagamento pagamento;
            pagamentos.TryGetValue(pagamentoId, out pagamento);

            return pagamento;
        }

        public static void Remover(Guid pagamentoId)
        {
            if (pagamentos[pagamentoId] != null)
                pagamentos.Remove(pagamentoId);
        }



        internal static void Add(Guid p, Pagamento pagto)
        {
            throw new NotImplementedException();
        }
    }
}