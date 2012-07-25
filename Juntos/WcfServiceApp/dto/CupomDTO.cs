using System;
using System.Runtime.Serialization;
using Juntos.Model;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public class CupomDTO : EntidadeDTO
    {
        [DataMember]
        public OfertaDTO OfertaDto { get; set; }

        [DataMember]
        public DateTime DataValidade { get; set; }

        [DataMember]
        public DateTime? DataUtilizacao { get; set; }

        [DataMember]
        public decimal Valor { get; set; }
    }
}