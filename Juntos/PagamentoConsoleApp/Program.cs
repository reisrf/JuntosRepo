using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Juntos.IService;
using Framework;
using Juntos.aplicacao.Services;
using Juntos.Model;
using Juntos.Model.Enums;

namespace PagamentoConsoleApp
{
    class Program
    {
        private static IPagamentoService pagamentoService = typeof(IPagamentoService).Fabricar();
        private static PagamentoAppService app = new PagamentoAppService();

        static void Main(string[] args)
        {
                       
            //Criando DTO de pagamento
            Juntos.aplicacao.Services.wsProxy.Pagamento pagto = new Juntos.aplicacao.Services.wsProxy.Pagamento();

            pagto.Codigo = 1;
            pagto.DataPagamento = new DateTime();
            pagto.FormaPagamento = Juntos.aplicacao.Services.wsProxy.FormaPagamento.Cartao;
            pagto.Status = Juntos.aplicacao.Services.wsProxy.StatusPagamento.Pendente;
            pagto.Valor = 1000;

            //Chamando o método para processamento
            ProcessarPagamento(pagto);

            //Chamando o método para consulta
            AtualizarPagamento(pagto.Codigo);

        }


        private static void ProcessarPagamento(Juntos.aplicacao.Services.wsProxy.Pagamento pagto)
        {
            

            app.SubmeterPagamento(pagto);

            Juntos.Model.Pagamento model = new Juntos.Model.Pagamento();


            model.Codigo = pagto.Codigo;
            model.DataPagamento = pagto.DataPagamento;
            model.Valor = pagto.Valor;

            switch (pagto.Status)
            {
                case Juntos.aplicacao.Services.wsProxy.StatusPagamento.Aprovado: model.Status = EnumStatusPagamento.Aprovado; break;
                case Juntos.aplicacao.Services.wsProxy.StatusPagamento.Cancelado: model.Status = EnumStatusPagamento.Cancelado; break;
                case Juntos.aplicacao.Services.wsProxy.StatusPagamento.Rejeitado: model.Status = EnumStatusPagamento.Rejeitado; break;
                case Juntos.aplicacao.Services.wsProxy.StatusPagamento.Pendente: model.Status = EnumStatusPagamento.Pendente; break;
            }

            switch (pagto.FormaPagamento)
            {
                case Juntos.aplicacao.Services.wsProxy.FormaPagamento.PagSeguro: model.FormaPagamento = EnumFormaPagamento.PagSeguro; break;
                case Juntos.aplicacao.Services.wsProxy.FormaPagamento.PayPal: model.FormaPagamento = EnumFormaPagamento.PayPal; break;

            }

            pagamentoService.Adicionar(model);

        }


        private static void AtualizarPagamento(long id) 
        {
            Juntos.aplicacao.Services.wsProxy.Pagamento result = app.ObterResultadoPagamento(id);

            Pagamento model = pagamentoService.BuscarPorId(id);
            
            
            if (result.Status != Juntos.aplicacao.Services.wsProxy.StatusPagamento.Pendente)
            {
                switch (result.Status)
                {
                    case Juntos.aplicacao.Services.wsProxy.StatusPagamento.Aprovado: model.Status = EnumStatusPagamento.Aprovado; break;
                    case Juntos.aplicacao.Services.wsProxy.StatusPagamento.Cancelado: model.Status = EnumStatusPagamento.Cancelado; break;
                    case Juntos.aplicacao.Services.wsProxy.StatusPagamento.Rejeitado: model.Status = EnumStatusPagamento.Rejeitado; break;
                }
            }

            pagamentoService.Atualizar(model);

        
        }

    
    }

    
}
