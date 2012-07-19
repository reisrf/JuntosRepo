using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace juntos.PagamentoService.model
{
    public class Pagamentos
    {
        static Dictionary<string, Pagamento> pagamentos = new Dictionary<string, Pagamento>();

        public static void Add(Pagamento pagamento)
        {
            pagamentos.Add(pagamento.Codigo, pagamento);
        }

        public static Pagamento BuscarPagamento(string pagamentoId)
        {
            Pagamento pagamento;
            pagamentos.TryGetValue(pagamentoId, out pagamento);

            return pagamento;
        }

        public static void Remover(string pagamentoId)
        {
            if (pagamentos[pagamentoId] != null)
                pagamentos.Remove(pagamentoId);
        }



        internal static void Add(string p, Pagamento pagto)
        {
            throw new NotImplementedException();
        }
    }
}