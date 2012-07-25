using System;
using System.Runtime.Serialization;
using Juntos.Model.Enums;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public class PagamentoDTO : EntidadeDTO
    {
        [DataMember]
        public EnumFormaPagamento FormaPagamento { get; set; }

        [DataMember]
        public long Codigo { get; set; }

        [DataMember]
        public DateTime DataPagamento { get; set; }

        [DataMember]
        public decimal Valor { get; set; }

        [DataMember]
        public EnumStatusPagamento Status { get; set; }
    }
}