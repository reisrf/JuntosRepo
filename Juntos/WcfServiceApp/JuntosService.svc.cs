using Juntos.WcfServiceApp.PagamentoService;

namespace Juntos.WcfServiceApp
{
    using System;
    using System.Collections.Generic;
    using Framework;

    using IService;
    using Model;
    using Model.Enums;

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

        public void SalvarAnunciante(Anunciante anunciante)
        {
            IAnuncianteService anuncianteService = typeof (IAnuncianteService).Fabricar();
            anuncianteService.Salvar(anunciante);
        }

        public List<Oferta> RetornarTodasOfertas()
        {
            IOfertaService ofertaService = typeof (IOfertaService).Fabricar();
            return ofertaService.RetornarTodos();
        }

        public Oferta ConsultarOfertaPeloId(long id)
        {
            IOfertaService ofertaService = typeof (IOfertaService).Fabricar();
            return ofertaService.BuscarPorId(id);
        }

        public void SalvarOferta(Oferta oferta)
        {
            IOfertaService ofertaService = typeof (IOfertaService).Fabricar();
            ofertaService.Salvar(oferta);
        }

        public List<Compra> RetornarTodasCompras()
        {
            ICompraService compraService = typeof (ICompraService).Fabricar();
            return compraService.RetornarTodos();
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
            ICompraService compraService = typeof (ICompraService).Fabricar();
            var compra = compraService.BuscarPorId(idCompra);

            using (var pagamentoServiceClient = new PagamentoServiceClient())
            {
                pagamentoServiceClient.Open();
                if (pagamentoServiceClient.Pagar(compra.ValorTotal))
                {
                    compraService.PagarCompra(compra, formaPagamento);
                }
            }
        }
    }
}
