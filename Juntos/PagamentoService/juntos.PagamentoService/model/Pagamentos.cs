using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace juntos.PagamentoService.model
{
    public class Pagamentos
    {
        static Dictionary<long, Pagamento> pagamentos = new Dictionary<long, Pagamento>();

        public static void Add(Pagamento pagamento)
        {
            pagamentos.Add(pagamento.Codigo, pagamento);
        }

        public static Pagamento BuscarPagamento(long pagamentoId)
        {
            Pagamento pagamento;
            pagamentos.TryGetValue(pagamentoId, out pagamento);

            return pagamento;
        }

        public static void Remover(long pagamentoId)
        {
            if (pagamentos[pagamentoId] != null)
                pagamentos.Remove(pagamentoId);
        }



        internal static void Add(long p, Pagamento pagto)
        {
            throw new NotImplementedException();
        }
    }
}