using System.Runtime.Serialization;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public abstract class EntidadeDTO
    {
        [DataMember]
        public long Id { get; set; }
    }
}
