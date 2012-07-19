using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using juntos.PagamentoService.model;

namespace juntos.PagamentoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class PagamentoService : IPagamentoService
    {
        public void PaymentRequest(Pagamento pagto)
        {

            Console.WriteLine(@"Processando pagamento : " + pagto.Codigo + " no valor de " + pagto.Valor);


            Random random = new Random();
            int status = random.Next(0, 10);


            if (status <= 2)
            {

                pagto.Status = StatusPagamento.Rejeitado;
            }
            else
            {
                pagto.Status = StatusPagamento.Aprovado;
            }
            
            Pagamentos.Add(pagto.Codigo, pagto);         

        }

        public Pagamento GetPaymentResult(string pagtoid)
        {
            Console.WriteLine(@"Verificando o status do pagamento : " + pagtoid);

            Pagamento pagto = Pagamentos.BuscarPagamento(pagtoid);

            Console.WriteLine(@"status is " +pagto.Status);

            return pagto;
        }


     }
}
