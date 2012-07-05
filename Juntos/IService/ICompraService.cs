using System;
using Juntos.Model;

namespace Juntos.IService
{
    public interface ICompraService : IBaseService<Compra>
    {
        Compra ComprarOferta(Guid idConsumidor, Guid idOferta, int quantidadeCupons);
    }
}