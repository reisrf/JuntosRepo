using System;
using System.Collections.Generic;
using System.ServiceModel;
using Juntos.Model;
using Juntos.Model.Enums;

namespace Juntos.WcfServiceApp
{
    [ServiceContract]
    public interface IJuntosService
    {
        [OperationContract]
        List<Consumidor> RetornarTodosConsumidores();

        [OperationContract]
        Consumidor ConsultarConsumidorPeloId(long id);

        [OperationContract]
        void SalvarConsumidor(Consumidor consumidor);

        [OperationContract]
        List<Anunciante> RetornarTodosAnunciantes();

        [OperationContract]
        Anunciante ConsultarAnunciantePeloId(long id);
        
        [OperationContract]
        Anunciante ConsultarAnunciantePeloEmail(string email);

        [OperationContract]
        void SalvarAnunciante(Anunciante anunciante);

        [OperationContract]
        List<Oferta> RetornarTodasOfertas();

        [OperationContract]
        Oferta ConsultarOfertaPeloId(long id);

        [OperationContract]
        void SalvarOferta(Oferta oferta);

        [OperationContract]
        List<Compra> RetornarTodasCompras();

        [OperationContract]
        Compra ConsultarCompraPeloId(long id);

        [OperationContract]
        void SalvarCompra(Compra compra);

        [OperationContract]
        Compra ComprarOferta(long idConsumidor, long idOferta, int quantidadeCupons);

        [OperationContract]
        void PagarCompra(long idCompra, EnumFormaPagamento formaPagamento);

        [OperationContract]
        void InformarUsoCupom(long idCupom);

        [OperationContract]
        void PublicarOferta(long idOferta);

        [OperationContract]
        List<Cupom> ListarCuponsNaoUtilizados(long ofertaid);

        [OperationContract]
        List<Cupom> ConsolidarOferta(long ofertaid);
    }
}
