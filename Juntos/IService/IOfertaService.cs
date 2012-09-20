using System;
using System.Collections.Generic;
using Juntos.Model;
using Juntos.Model.Enums;

namespace Juntos.IService
{
    public interface IOfertaService : IBaseService<Oferta>
    {
        void Publicar(long idOferta);
        void Finalizar(long idOferta);
        void UtilizarCupom(long idCupom);
        List<Oferta> BuscarPorAnunciante(Anunciante anunciante);
        List<Oferta> BuscarPorAnuncianteEStatus(Anunciante anunciante, EnumStatusOferta status);
        List<Oferta> BuscarPorStatus(EnumStatusOferta status);
    }
}