using System;
using System.Collections.Generic;
using System.ServiceModel;
using Juntos.Model;
using Juntos.Model.Enums;
using Juntos.Apresentacao.WcfServiceApp.dto;

namespace Juntos.WcfServiceApp
{
    [ServiceContract]
    public interface IJuntosService
    {
        [OperationContract]
        List<ConsumidorDTO> RetornarTodosConsumidores();

        [OperationContract]
        ConsumidorDTO ConsultarConsumidorPeloId(long id);

        [OperationContract]
        void SalvarConsumidor(ConsumidorDTO consumidor);

        [OperationContract]
        List<AnuncianteDTO> RetornarTodosAnunciantes();

        [OperationContract]
        AnuncianteDTO ConsultarAnunciantePeloId(long id);
        
        [OperationContract]
        AnuncianteDTO ConsultarAnunciantePeloEmail(string email);

        [OperationContract]
        void SalvarAnunciante(AnuncianteDTO anunciante);

        [OperationContract]
        List<OfertaDTO> RetornarTodasOfertasPorAnunciante(long anuncianteid);

        [OperationContract]
        OfertaDTO ConsultarOfertaPeloId(long id);

        [OperationContract]
        void SalvarOferta(OfertaDTO oferta, long idConsumidor);

        [OperationContract]
        List<CompraDTO> RetornarTodasComprasPorConsumidor(long consumidorid);
        
        [OperationContract]
        List<CompraDTO> RetornarTodasCompras();

        [OperationContract]
        CompraDTO ConsultarCompraPeloId(long id);

        [OperationContract]
        void SalvarCompra(CompraDTO compra);

        [OperationContract]
        CompraDTO ComprarOferta(long idConsumidor, long idOferta, int quantidadeCupons);

        [OperationContract]
        void PagarCompra(long idCompra, EnumFormaPagamento formaPagamento);

        [OperationContract]
        void InformarUsoCupom(long idCupom);

        [OperationContract]
        void PublicarOferta(long idOferta);

        [OperationContract]
        List<CupomDTO> ListarCuponsNaoUtilizados(long ofertaid);

        [OperationContract]
        List<CupomDTO> ConsolidarOferta(long ofertaid);
        
        [OperationContract]
        List<OfertaDTO> RetornarTodasOfertas();
    }
}
