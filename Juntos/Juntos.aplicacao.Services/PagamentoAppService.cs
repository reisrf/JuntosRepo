using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Juntos.aplicacao.Services.wsProxy;

namespace Juntos.aplicacao.Services
{
    public class PagamentoAppService
    {
        private ControladorPagamentoServiceClient client = new ControladorPagamentoServiceClient();
        
        public void SubmeterPagamento(Pagamento pagamento)
        {
          
            if (pagamento.Status == StatusPagamento.Pendente) {
                client.PaymentRequest(pagamento);
            }
           

        }


        public Pagamento ObterResultadoPagamento(Guid pagamentoID)
        {

            Pagamento result = client.GetPaymentResult(pagamentoID);

            return result;

        }

    }
}
