﻿using Juntos.WcfServiceApp.PagamentoServices;

namespace Juntos.WcfServiceApp
{
    using System;
    using System.Collections.Generic;
    using Framework;

    using IService;
    using Model;
    using Model.Enums;
    using Juntos.WcfServiceApp.wsProxy;

    public class JuntosService : IJuntosService
    {
        public List<Consumidor> RetornarTodosConsumidores()
        {
            IConsumidorService consumidorService = typeof (IConsumidorService).Fabricar();
            return consumidorService.RetornarTodos();
        }

        public Consumidor ConsultarConsumidorPeloId(long id)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            return consumidorService.BuscarPorId(id);
        }

        public void SalvarConsumidor(Consumidor consumidor)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            consumidorService.Salvar(consumidor);
        }

        public List<Anunciante> RetornarTodosAnunciantes()
        {
            IAnuncianteService anuncianteService = typeof (IAnuncianteService).Fabricar();
            return anuncianteService.RetornarTodos();
        }

        public Anunciante ConsultarAnunciantePeloId(long id)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            return anuncianteService.BuscarPorId(id);
        }

        public Anunciante ConsultarAnunciantePeloEmail(string email)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            return anuncianteService.ConsultarPeloEmail(email);
        }

        public void SalvarAnunciante(Anunciante anunciante)
        {
            IAnuncianteService anuncianteService = typeof (IAnuncianteService).Fabricar();
            anuncianteService.Salvar(anunciante);
        }

        public List<Oferta> RetornarTodasOfertas(long anuncianteid)
        {
            //IOfertaService ofertaService = typeof (IOfertaService).Fabricar();
            //return ofertaService.RetornarTodos();

            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(anuncianteid);

            List<Oferta> result = anunciante.Ofertas;

            return result;
        }

        public Oferta ConsultarOfertaPeloId(long id)
        {
            IOfertaService ofertaService = typeof (IOfertaService).Fabricar();
            return ofertaService.BuscarPorId(id);
        }

        public void SalvarOferta(Oferta oferta, long idAnunciante)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(idAnunciante);

            oferta.Anunciante = null;

            if (anunciante.Ofertas == null)
            {
                anunciante.Ofertas = new List<Oferta>();
            }
            anunciante.Ofertas.Add(oferta);
            anuncianteService.Salvar(anunciante);
        }

        public List<Compra> RetornarTodasCompras(long consumidorid)
        {
            //ICompraService compraService = typeof (ICompraService).Fabricar();
            //return compraService.RetornarTodos();

            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            Consumidor consumidor = consumidorService.BuscarPorId(consumidorid);
            return consumidor.Compras;
        }

        public Compra ConsultarCompraPeloId(long id)
        {
            ICompraService compraService = typeof(ICompraService).Fabricar();
            return compraService.BuscarPorId(id);
        }

        public void SalvarCompra(Compra compra)
        {
            ICompraService compraService = typeof(ICompraService).Fabricar();
            compraService.Salvar(compra);
        }

        public Compra ComprarOferta(long idConsumidor, long idOferta, int quantidadeCupons)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            IOfertaService ofertaService = typeof (IOfertaService).Fabricar();
            ICompraService compraService = typeof(ICompraService).Fabricar();

            var consumidor = consumidorService.BuscarPorId(idConsumidor);
            var oferta = ofertaService.BuscarPorId(idOferta);
            return compraService.ComprarOferta(consumidor, oferta, quantidadeCupons);
        }

        public void PagarCompra(long idCompra, EnumFormaPagamento formaPagamento)
        {
            if (formaPagamento == EnumFormaPagamento.NaoDefinida)
            {
                throw new Exception("Forma de pagamento não definida.");
            }

            ICompraService compraService = typeof (ICompraService).Fabricar();
            var compra = compraService.BuscarPorId(idCompra);

            if (formaPagamento == EnumFormaPagamento.PayPal)
            {
                using (var pagamentoServiceClient = new PagamentoServiceClient())
                {
                    pagamentoServiceClient.Open();
                    if (pagamentoServiceClient.Pagar(compra.ValorTotal))
                    {
                        compraService.PagarCompra(compra, formaPagamento);
                    }
                }
            }
            else
            {

                using (var client = new ControladorPagamentoServiceClient())
                {
                    client.Open();

                    Juntos.WcfServiceApp.wsProxy.Pagamento pagto = new Juntos.WcfServiceApp.wsProxy.Pagamento();
                    pagto.Codigo = idCompra;
                    pagto.DataPagamento = DateTime.Now;
                    pagto.FormaPagamento = FormaPagamento.PagSeguro;
                    pagto.Valor = compra.ValorTotal;

                    client.PaymentRequest(pagto);

                    pagto = client.GetPaymentResult(pagto.Codigo);

                    if (pagto.Status==StatusPagamento.Aprovado) 
                    {
                        compraService.PagarCompra(compra, formaPagamento);
                    }
               
               }
            }
        }


        public void InformarUsoCupom(long idCupom) 
        {

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();


            ofertaService.UtilizarCupom(idCupom);
            
        
        }


        public void PublicarOferta(long idOferta) {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();

            ofertaService.Publicar(idOferta);
        
        
        }


        public List<Cupom> ListarCuponsNaoUtilizados(long ofertaid) {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            
            Oferta oferta = ofertaService.BuscarPorId(ofertaid);
            List<Cupom> result = new List<Cupom>();

            oferta.CuponsGerados.ForEach(c => {

                if (!c.IsUtilizado())
                {
                    result.Add(c);
                }
            
            });

            return result; 

        }



        public List<Cupom> ConsolidarOferta(long ofertaid)
        {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();

            Oferta oferta = ofertaService.BuscarPorId(ofertaid);
            List<Cupom> result = new List<Cupom>();

            oferta.CuponsGerados.ForEach(c =>
            {

                if (c.IsUtilizado())
                {
                    result.Add(c);
                }

            });

            return result; 
        }
    }
}
