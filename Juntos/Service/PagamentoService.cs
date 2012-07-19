using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Juntos.IService;
using Juntos.Model;
using Juntos.Service.proxy;
using Juntos.IRepository;
using Juntos.Model.Enums;

namespace Juntos.Service
{
    public class PagamentoService : BaseService<Juntos.Model.Pagamento>, IPagamentoService
    {
        IPagamentoRepository repository;
        
        public PagamentoService(IPagamentoRepository pagamentoRepository): base(pagamentoRepository)
        {
            repository = pagamentoRepository;
        }
        
       public void ProcessarPagamento(Juntos.Model.Pagamento pagamento)
        {

            if (pagamento.Status == EnumStatusPagamento.Pendente)
            {

                Juntos.Service.proxy.Pagamento pagto = new Juntos.Service.proxy.Pagamento();
                pagto.Codigo = pagamento.Id;
                pagto.DataPagamento = pagamento.DataPagamento;
                pagto.Valor = pagamento.Valor;
                pagto.Status = StatusPagamento.Pendente;

                switch (pagamento.FormaPagamento)
                {
                    case EnumFormaPagamento.Cartao: pagto.FormaPagamento = FormaPagamento.Cartao; break;
                    case EnumFormaPagamento.PagSeguro: pagto.FormaPagamento = FormaPagamento.PagSeguro; break;
                    case EnumFormaPagamento.PayPal: pagto.FormaPagamento = FormaPagamento.PayPal; break;
                }

                ControladorPagamentoServiceClient service = new ControladorPagamentoServiceClient();

                service.PaymentRequest(pagto);

            }    


        }
       public void AtualizarPagameto(Juntos.Model.Pagamento pagamento)
        {
            if (pagamento.Status == EnumStatusPagamento.Pendente)
            {

                ControladorPagamentoServiceClient service = new ControladorPagamentoServiceClient();

                Juntos.Service.proxy.Pagamento pagto = service.GetPaymentResult(pagamento.Id);
                              
                if (pagto.Status!=StatusPagamento.Pendente) {            

                    switch (pagto.Status)
                    {
                        case StatusPagamento.Aprovado: pagamento.Status = EnumStatusPagamento.Aprovado; break;
                        case StatusPagamento.Cancelado: pagamento.Status = EnumStatusPagamento.Cancelado; break;
                        case StatusPagamento.Rejeitado: pagamento.Status = EnumStatusPagamento.Rejeitado; break;

                    }

                    repository.AtualizarPagamento(pagamento);

                }

            }    


        }

    }
}
