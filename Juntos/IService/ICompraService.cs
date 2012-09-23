using System;
using Juntos.Model;
using Juntos.Model.Enums;

namespace Juntos.IService
{
    public interface ICompraService : IBaseService<Compra>
    {
        Compra ComprarOferta(Consumidor consumidor, Oferta oferta, int quantidadeCupons);
        void PagarCompra(Compra compra, EnumFormaPagamento formaPagamento);
        void RejeitarCompra(Compra compra, EnumFormaPagamento formaPagamento);
    }
}