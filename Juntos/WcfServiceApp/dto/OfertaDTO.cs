using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Juntos.Model.Enums;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public class OfertaDTO : EntidadeDTO
    {
        [DataMember]
        public AnuncianteDTO AnuncianteDto { get; set; }

        [DataMember]
        public EnumStatusOferta Status { get; set; }

        [DataMember]
        public DateTime? DataPublicacao { get; set; }

        [DataMember]
        public DateTime DataValidadeCupons { get; set; }

        [DataMember]
        public DateTime DataExpiracao { get; set; }

        [DataMember]
        public DateTime? DataInicioValidade { get; set; }

        [DataMember]
        public decimal ValorCupons { get; set; }

        [DataMember]
        public string Descricao { get; set; }

        [DataMember]
        public string Condicoes { get; set; }

        [DataMember]
        public List<CupomDTO> CuponsGerados { get; set; }

        [DataMember]
        public int NumeroMaximoCupons { get; set; }

        [DataMember]
        public string Endereco { get; set; }

        [DataMember]
        public string Telefone { get; set; }




    }
}