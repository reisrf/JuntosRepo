using System;
using Framework;
using Juntos.IRepository;
using Juntos.IService;
using Juntos.Model;

namespace Juntos.Service
{
    public class CompraService : BaseService<Compra>, ICompraService
    {
        public CompraService(ICompraRepository compraRepository) : base(compraRepository)
        {
        }

        public Compra ComprarOferta(Guid idConsumidor, Guid idOferta, int quantidadeCupons)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            var consumidor = consumidorService.ConsultarPeloId(idConsumidor);

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            var oferta = ofertaService.ConsultarPeloId(idOferta);

            var compra = new Compra(consumidor);
            var cupons = oferta.GerarCupons(quantidadeCupons);
            compra.Cupons.AddRange(cupons);
            compra.DataCompra = DateTime.Now;

            this.Repository.Adicionar(compra);
            consumidorService.Atualizar(consumidor);
            ofertaService.Atualizar(oferta);

            return compra;
        }
    }
}
