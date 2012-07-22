using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using juntos.aplicacao.wsPagamentoClient.wsProxy;

namespace juntos.aplicacao.wsPagamentoClient
{
    class Program
    {
        static void Main(string[] args)
        {

            ControladorPagamentoServiceClient client = new ControladorPagamentoServiceClient();
            Console.WriteLine("criando pagamento");
            Pagamento p = new Pagamento();
            p.Codigo = 1;
            p.DataPagamento = DateTime.Now;
            p.FormaPagamento = FormaPagamento.Cartao;
            p.Status = StatusPagamento.Pendente;
            p.Valor = 1000;
            Console.WriteLine("submetendo pagamento");
            client.PaymentRequest(p);

            Console.WriteLine("recuperando estado de pagamento");
            Pagamento p1 = client.GetPaymentResult(1);

            Console.WriteLine("O resultado do Pagamento e : " + p1.Status);


            client.Close();


        }
    }
}
