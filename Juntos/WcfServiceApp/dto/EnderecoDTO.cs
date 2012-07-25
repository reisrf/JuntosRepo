using System.Runtime.Serialization;
using Juntos.Model;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public class EnderecoDTO : EntidadeDTO
    {
        [DataMember]
        public string Logradouro { get; set; }

        [DataMember]
        public int Numero { get; set; }

        [DataMember]
        public string Complemento { get; set; }

        [DataMember]
        public string Bairro { get; set; }

        [DataMember]
        public string Cidade { get; set; }

        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Pais { get; set; }

        [DataMember]
        public string Cep { get; set; }
    }
}