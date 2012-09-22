using System;
using Framework;
using Juntos.IRepository;
using Juntos.IService;
using Juntos.Model;
using Juntos.Model.Enums;

namespace Juntos.Service
{
    public class CompraService : BaseService<Compra>, ICompraService
    {
        public CompraService(ICompraRepository compraRepository) : base(compraRepository)
        {
        }

        public Compra ComprarOferta(Consumidor consumidor, Oferta oferta, int quantidadeCupons)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            
            var compra = new Compra(consumidor);
            var cupons = oferta.GerarCupons(quantidadeCupons);
            compra.Consumidor = consumidor;
            compra.Cupons.AddRange(cupons);
            compra.DataCompra = DateTime.Now;

            this.Repository.Adicionar(compra);
            consumidorService.Atualizar(consumidor);
            ofertaService.Atualizar(oferta);

            return compra;
        }

        public void PagarCompra(Compra compra, EnumFormaPagamento formaPagamento)
        {
            if (compra.IsPaga())
            {
                throw new Exception("A compra já se encontra paga.");
            }

            Pagamento pagamento = compra.Pagar(formaPagamento);
            IPagamentoService pagamentoService = typeof (IPagamentoService).Fabricar();
            pagamentoService.Adicionar(pagamento);
            this.Repository.Atualizar(compra);
        }
    }
}
