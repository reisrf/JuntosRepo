using System.Collections.Generic;
using System.Runtime.Serialization;
using Juntos.Model;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public class AnuncianteDTO : PessoaDTO
    {
        [DataMember]
        public List<OfertaDTO> Ofertas { get; set; }
    }
}