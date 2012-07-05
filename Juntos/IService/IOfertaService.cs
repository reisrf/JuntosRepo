using System;
using Juntos.Model;

namespace Juntos.IService
{
    public interface IOfertaService : IBaseService<Oferta>
    {
        void Publicar(Guid idOferta);
        void Finalizar(Guid idOferta);
        void UtilizarCupom(Guid idCupom);
    }
}