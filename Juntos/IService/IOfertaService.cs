using System;
using Juntos.Model;

namespace Juntos.IService
{
    public interface IOfertaService : IBaseService<Oferta>
    {
        void Publicar(long idOferta);
        void Finalizar(long idOferta);
        void UtilizarCupom(long idCupom);
    }
}