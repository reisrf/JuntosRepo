using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Juntos.Model;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public class CompraDTO : EntidadeDTO
    {
        [DataMember]
        public decimal ValorTotal { get; set; }

        [DataMember]
        public DateTime DataCompra { get; set; }

        [DataMember]
        public long ConsumidorId { get; set; }

        [DataMember]
        public List<CupomDTO> Cupons { get; set; }

        [DataMember]
        public List<PagamentoDTO> Pagamentos { get; set; }
    }
}