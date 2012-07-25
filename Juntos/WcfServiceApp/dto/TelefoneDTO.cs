using System.Runtime.Serialization;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public class TelefoneDTO : EntidadeDTO
    {
        [DataMember]
        public int Numero { get; set; }

        [DataMember]
        public short DDD { get; set; }

        [DataMember]
        public short DDI { get; set; }
    }
}